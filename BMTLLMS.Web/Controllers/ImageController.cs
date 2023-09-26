using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using BMTLLMS.Domain.Models.Request;
using BMTLLMS.Service.Contracts;
using BMTLLMS.Common.Security;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using BMTLLMS.Domain.ViewModel.Request;
using System.Dynamic;
using BMTLLMS.Common;
using BMTLLMS.Domain.ViewModel.Response.Login;
using BMTLLMS.Domain;
using MassData.Domain.ViewModel.Request;

namespace BMTLLMS.Web.Controllers
{
   public class ImageController : Controller
   {
      private readonly IWebHostEnvironment _hostEnvironment;
      private readonly RavenDBContext _context;

      public ImageController(RavenDBContext context, IWebHostEnvironment hostEnvironment)
      {
         _context = context;
         this._hostEnvironment = hostEnvironment;
      }

      // GET: Image
      public async Task<IActionResult> Index()
      {
         //return View(await _context.Images.ToListAsync());
         return View();
      } 
      public async Task<IActionResult> Details(int? id)
      {
         //if (id == null)
         //{
         //   return NotFound();
         //}

         //var imageModel = await _context.Images
         //    .FirstOrDefaultAsync(m => m.ImageId == id);
         //if (imageModel == null)
         //{
         //   return NotFound();
         //}

         return View();
      } 
      public IActionResult Create()
      {
         return View();
      }
      [HttpPost]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> Create(CreateFileUploadVM imageModel)
      {
         if (ModelState.IsValid)
         { 
            string wwwRootPath = _hostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(imageModel.imagefile.FileName);
            string extension = Path.GetExtension(imageModel.imagefile.FileName);
            imageModel.ReferrenceNo = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            string path = Path.Combine(wwwRootPath + "/Image/", fileName);

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
               await imageModel.imagefile.CopyToAsync(fileStream);
            } 
            _context.Add(imageModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
         }
         return View(imageModel);
      }

      // GET: Image/Edit/5
      public async Task<IActionResult> Edit(int? id)
      {
         //if (id == null)
         //{
         //   return NotFound();
         //}

         //var imageModel = await _context.Images.FindAsync(id);
         //if (imageModel == null)
         //{
         //   return NotFound();
         //}
         return View();
      } 
      public async Task<IActionResult> Delete(int? id)
      {
         //if (id == null)
         //{
         //   return NotFound();
         //}

         //var imageModel = await _context.Images
         //    .FirstOrDefaultAsync(m => m.ImageId == id);
         //if (imageModel == null)
         //{
         //   return NotFound();
         //} 
         //return View(imageModel);
         return View();
      } 
      [HttpPost, ActionName("Delete")]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> DeleteConfirmed(int id)
      {
         //var imageModel = await _context.Images.FindAsync(id);

         ////delete image from wwwroot/image
         //var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "image", imageModel.ImageName);
         //if (System.IO.File.Exists(imagePath))
         //   System.IO.File.Delete(imagePath);
         ////delete the record
         //_context.Images.Remove(imageModel);
         //await _context.SaveChangesAsync();
         return RedirectToAction(nameof(Index));
      }

      private int ImageModelExists(int id)
      {
         return 0;// _context.Images.Any(e => e.ImageId == id);
      }
   }
}
