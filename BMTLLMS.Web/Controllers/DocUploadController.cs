using BMTLLMS.Common;
using BMTLLMS.Domain;
using BMTLLMS.Domain.Models.Configuration;
using BMTLLMS.Domain.ViewModel;
using BMTLLMS.Domain.ViewModel.Request;
using BMTLLMS.Domain.ViewModel.Response;
using BMTLLMS.Service.Contracts;
using MassData.Domain.ViewModel.Request; 
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.WindowsAzure.Storage;
//using Microsoft.WindowsAzure.Storage.Blob;
using System.Dynamic;
using System.Net.Http.Headers;

namespace BMTLLMS.Web.Controllers
{
   [EnableCors("Powersoft")]
   public class DocUploadController : Controller
   {
      //CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse("BlobEndpoint=https://ibosblobdata.blob.core.windows.net?sp=rw&st=2021-11-16T05:46:17Z&se=2023-11-16T13:46:17Z&spr=https&sv=2020-08-04&sr=c&sig=nvI%2Fa0NvK0FuTuwz8vLP%2FaSeipCwJhbGKvmIVj9%2BoJ4%3D");

      private readonly ILogger<DocUploadController> _logger;
      private readonly IWebHostEnvironment _environment;

      private readonly IDocUploadFacade _DocUploadFacade;
      public DocUploadController(IDocUploadFacade testStandardFacade, IWebHostEnvironment webHost)
      {
         _DocUploadFacade = testStandardFacade;
         _environment = webHost;
      }
      [Authorize]
      public IActionResult Index()
      {
         return View();
      }
      //[Authorize]
      //public IActionResult FileUpload()
      //{
      //   return View();
      //}
      [Authorize]
      public JsonResult GetDocUpload()
      {
         var response = new DocUploadResponseVM();
         try
         {
            var result = _DocUploadFacade.GetDocUpload(0);
            response.Data = result;
            response.StatusCode = "200";
            response.StatusMessage = "OK";
         }
         catch (Exception ex)
         {
            /// Log write 
            response.StatusCode = "500";
            response.StatusMessage = ex.ToString();
         }
         return Json(response);
      }
      //[HttpPost]
      [Authorize]
      public IActionResult DocUploadSave(DocUploadVM obj)
      {
         var user = User.Claims.ToList();
         obj.Creator = Convert.ToInt64(user[1].Value);
         if (ModelState.IsValid)
         {
            var result = _DocUploadFacade.SaveDocUpload(obj);
            return Json(result);
         };
         return Json(obj);
      }
      public class FileValidationError
      {
         public string? FileName { get; set; }
         public string? Message { get; set; }
      }
      public class FileResponse
      {
         public long globalFileUrlId { get; set; }
         public string? fileName { get; set; }
      }
      public class BaseSixtyFourDTO
      {
         public string Data { get; set; }
         public string FileName { get; set; }
      }
      //[HttpPost]
      //public async Task<IActionResult> UploadFile(IList<IFormFile> files)
      //{
      //   var user = User.Claims.ToList();
      //   //model.Creator = Convert.ToInt64(user[1].Value);
      //   try
      //   {
      //      string filename = string.Empty;
      //      long maxFileSize = 5 * 1024 * 1024; // 1 MB
      //      List<FileValidationError> errors = new List<FileValidationError>();
      //      List<FileResponse> responses = new List<FileResponse>();

      //      foreach (var file in files)
      //      {
      //         if (file.Length > maxFileSize)
      //         {
      //            long fileSize = file.Length / (1024 * 1024);
      //            FileValidationError error = new FileValidationError
      //            {
      //               FileName = file.Name,
      //               Message = "Maximum File Size Allowed (1MB) Your File Size (" + fileSize + "MB)"
      //            };
      //            errors.Add(error);
      //         }
      //      }

      //      if (errors.Count > 0)
      //      {
      //         return NotFound(errors);
      //      }
      //      else
      //      {
      //         foreach (var file in files)
      //         {
      //            filename = DateTime.Now.Ticks.ToString() + "_" + (file.FileName == "blob" ? "blob.jpg" : file.FileName);

      //            var cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
      //            var cloudBlobContainer = cloudBlobClient.GetContainerReference("erpdata");

      //            var cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(filename);
      //            cloudBlockBlob.Properties.ContentType = file.ContentType;

      //            await cloudBlockBlob.UploadFromStreamAsync(file.OpenReadStream());

      //            CloudBlockBlob blockBlob = cloudBlobContainer.GetBlockBlobReference(filename);
      //            await blockBlob.FetchAttributesAsync();

      //            if (!string.IsNullOrEmpty(blockBlob.Name))
      //            {
      //               GlobalFileUrl obj = new GlobalFileUrl
      //               {
      //                  ReferrenceNo = "refer12",
      //                  ReferenceDescription = "Dcoument file for " + "refer12",
      //                  DocumentTypeId = 1,
      //                  FileServerId = blockBlob.Name,
      //                  DocumentName = file.FileName,
      //                  NumFileSize = Convert.ToDecimal(file.Length),
      //                  FileExtension = Path.GetExtension(file.FileName),
      //                  ServerLocation = "Azure File Server",
      //                  Creator = 1,
      //                  CreationDate = DateTime.Now,
      //               };
      //               _DocUploadFacade.GlobalFileUrl(obj);
      //               //await _db.GlobalFileUrls.AddAsync(obj);
      //               //await _context.SaveChangesAsync();

      //               FileResponse response = new FileResponse
      //               {
      //                  globalFileUrlId = obj.ID,
      //                  fileName = file.FileName
      //               };
      //               responses.Add(response);
      //            };

      //         }
      //         return Ok(responses);
      //      }
      //   }
      //   catch (Exception e)
      //   {
      //      _logger.LogError(e, "Error");
      //      throw new Exception("internal server error");
      //   }
      //}
      public IActionResult FileUpload()
      {
         return View();
      }
      [HttpPost]
      public IActionResult FileUpload(IList<IFormFile> files)
      {
         long size = 0;
         foreach (var file in files)
         {
            var filename = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            filename = _environment.WebRootPath + String.Format(filename); 
            //var fPath = Path.Combine(HttpContext.Current.Server.MapPath("~/"), "Images/StdPic");
            //if (!Directory.Exists(filename))
            //{
            //   Directory.CreateDirectory(filename);
            //}

            size += file.Length;
            using (FileStream fs = System.IO.File.Create(filename))
            {
               file.CopyTo(fs);
               fs.Flush();
               //_DocUploadFacade.GlobalFileUrl(obj);
            }
         }
         ViewBag.Message = $"{files.Count} file(s) / {size}bytes uploaded successfully!";
         return View();
      }
      [HttpPost]
      public IActionResult UploadFilesAjax(GlobalFileUrl model)
      {
         long size = 0;
         var files = Request.Form.Files;
         foreach (var file in files)
         {
            var filename = ContentDispositionHeaderValue
                            .Parse(file.ContentDisposition)
                            .FileName
                            .Trim('"');
            filename = _environment.WebRootPath + "/Images" + $@"\{filename}";
            size += file.Length;
            using (FileStream fs = System.IO.File.Create(filename))
            {
               GlobalFileUrl obj = new GlobalFileUrl 
               {  
                  ID = model.ID,
                  ReferrenceNo = "Reference No 123",
                  ReferenceDescription = "Dcoument file for " + "refer12",
                  DocumentTypeId = 321,
                  FileServerId = "ddd", 
                  DocumentName = file.FileName,
                  NumFileSize = Convert.ToDecimal(file.Length),
                  FileExtension = Path.GetExtension(file.FileName),
                  ServerLocation = "Azure File Server",
                  Creator = 1,
                  CreationDate = DateTime.Now,
               };
               _DocUploadFacade.GlobalFileUrl(obj);

               file.CopyTo(fs);
               fs.Flush();
            }
         }
         string message = $"{files.Count} file(s) /{size}bytes uploaded successfully!";
         return Json(message);
      }
      //[HttpGet]
      //[Authorize]
      //public JsonResult GetLoginUserData()
      //{
      //   var user = User.Claims.ToList();
      //   var Creator = Convert.ToInt64(user[1].Value);
      //   dynamic result = new ExpandoObject();
      //   try
      //   {
      //      result.usersList = user;
      //      result.statusMessage = StatusMessage.Success;
      //   }
      //   catch (Exception ex)
      //   {
      //      result.StatusCode = ProjectCodes.Error;
      //      result.StatusMessage = StatusMessage.Error;
      //   }
      //   return Json(result);
      //}
      [HttpGet]
      [Authorize]
      public JsonResult GetInitialData()
      {
         var user = User.Claims.ToList();
         var Creator = Convert.ToInt64(user[1].Value);
         dynamic result = new ExpandoObject();
         try
         {
            result.usersList = user;
            result.globalFileUrl = _DocUploadFacade.GetGlobalFileUrl(0).Where(x => x.IsActive == true).ToList();
            result.statusMessage = StatusMessage.Success;
         }
         catch (Exception ex)
         {
            result.StatusCode = ProjectCodes.Error;
            result.StatusMessage = StatusMessage.Error;
         }
         return Json(result);
      }
      
      [HttpPost]
      [Authorize]
      public IActionResult DeleteGlobalFileUrl(long id)
      {
         //string message = "";
         //var UserName = "";
         //var UserTypeId = "";
         //var UserId = "";
         //var UserDesignation = "";
         //var UserSectionId = "";
         //var user = User.Claims.ToList();
         //var Creator = Convert.ToInt64(user[1].Value);
         
         //if (user.Count > 0)
         //{
         //   UserName = user[0].Value;
         //   UserId = user[1].Value;
         //   UserDesignation = user[2].Value;
         //   UserTypeId = user[3].Value;
         //   UserSectionId = user[4].Value;
         //}
         //if(UserTypeId == "2")
         //{
         //   message = "You can not perimitted";
         //   throw new Exception("You can not permited");
         //}
         return Json(_DocUploadFacade.DeleteGlobalFileUrl(id));
      }
   }
}
