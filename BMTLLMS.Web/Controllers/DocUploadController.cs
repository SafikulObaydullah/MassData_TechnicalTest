using BMTLLMS.Domain;
using BMTLLMS.Domain.Models.Configuration;
using BMTLLMS.Domain.ViewModel;
using BMTLLMS.Domain.ViewModel.Request;
using BMTLLMS.Domain.ViewModel.Response;
using BMTLLMS.Service.Contracts;
using MassData.Domain.ViewModel.Request; 
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace BMTLLMS.Web.Controllers
{
    public class DocUploadController : Controller
    {
      CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse("BlobEndpoint=https://ibosblobdata.blob.core.windows.net?sp=rw&st=2021-11-16T05:46:17Z&se=2023-11-16T13:46:17Z&spr=https&sv=2020-08-04&sr=c&sig=nvI%2Fa0NvK0FuTuwz8vLP%2FaSeipCwJhbGKvmIVj9%2BoJ4%3D");

      private readonly ILogger<DocUploadController> _logger;
      private readonly IWebHostEnvironment _environment;
      private readonly RavenDBContext _db;

      private readonly IDocUploadFacade _DocUploadFacade;

         public DocUploadController(IDocUploadFacade testStandardFacade)
         { 
            _DocUploadFacade = testStandardFacade;
         }
         [Authorize]
         public IActionResult Index()
         {
            return View();
         }
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
              catch(Exception ex)
              {
                   /// Log write 
                  response.StatusCode = "500";
                  response.StatusMessage = ex.ToString();
             }
             return Json(response);
         }
         [HttpPost]
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
         [HttpPost]
         [Route("UploadFile")]
         public async Task<IActionResult> UploadFile(IList<IFormFile> files, string ReferrenceNo, Int64 documentTypeId, long createdBy)
      {
         try
         {
            string filename = string.Empty;
            long maxFileSize = 1 * 1024 * 1024; // 1 MB
            List<FileValidationError> errors = new List<FileValidationError>();
            List<FileResponse> responses = new List<FileResponse>();

            foreach (var file in files)
            {
               if (file.Length > maxFileSize)
               {
                  long fileSize = file.Length / (1024 * 1024);
                  FileValidationError error = new FileValidationError
                  {
                     FileName = file.Name,
                     Message = "Maximum File Size Allowed (1MB) Your File Size (" + fileSize + "MB)"
                  };
                  errors.Add(error);
               }
            }

            if (errors.Count > 0)
            {
               return NotFound(errors);
            }
            else
            {
               foreach (var file in files)
               {
                  filename = DateTime.Now.Ticks.ToString() + "_" + (file.FileName == "blob" ? "blob.jpg" : file.FileName);

                  var cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
                  var cloudBlobContainer = cloudBlobClient.GetContainerReference("erpdata");

                  var cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(filename);
                  cloudBlockBlob.Properties.ContentType = file.ContentType;

                  await cloudBlockBlob.UploadFromStreamAsync(file.OpenReadStream()); 

                  CloudBlockBlob blockBlob = cloudBlobContainer.GetBlockBlobReference(filename);
                  await blockBlob.FetchAttributesAsync();

                  if (!string.IsNullOrEmpty(blockBlob.Name))
                  {
                     GlobalFileUrl obj = new GlobalFileUrl
                     { 
                        ReferrenceNo = ReferrenceNo,
                        ReferenceDescription = "Dcoument file for " + ReferrenceNo,
                        DocumentTypeId = documentTypeId,
                        FileServerId = blockBlob.Name,
                        DocumentName = file.FileName,
                        NumFileSize = Convert.ToDecimal(file.Length),
                        FileExtension = Path.GetExtension(file.FileName),
                        ServerLocation = "Azure File Server",
                        Creator = createdBy,
                        CreationDate = DateTime.Now,
                     };
                     _DocUploadFacade.GlobalFileUrl(obj);
                     //await _db.GlobalFileUrls.AddAsync(obj);
                     //await _context.SaveChangesAsync();

                     FileResponse response = new FileResponse
                     {
                        globalFileUrlId = obj.ID,
                        fileName = file.FileName
                     };
                     responses.Add(response);
                  };

               }
               return Ok(responses);
            }
         }
         catch (Exception e)
         {
            _logger.LogError(e, "Error");
            throw new Exception("internal server error");
         }
      }

    }

}
