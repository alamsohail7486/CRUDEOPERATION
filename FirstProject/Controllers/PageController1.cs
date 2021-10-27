using FirstProject.Interface;
using FirstProject.Models;
using FirstProject.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FirstProject.Controllers
{
    public class PageController : Controller
    {

        private readonly IPage _Ipage;       /* here i call Interface  */

        private readonly IWebHostEnvironment webHostEnvironment;
        public PageController(IPage Ipage, IWebHostEnvironment hostEnvironment)    /* here i call parameterized constructor  */
        {
            //this._Ipage = Ipage;
            
            _Ipage = Ipage;

            webHostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }
        public void InsertPage(Page page)
        {
            _Ipage.InsertPage(page);
        }

        public JsonResult GetAllMyPage()
        {

            var page = _Ipage.GetAllMyPage();
            return Json(page);
        }

        public JsonResult SelectPageById(int id)
        {

            var page = _Ipage.SelectPageById(id);
            return Json(page);
        }
        public IActionResult UpdatePage(Page page)
        {
            string uniqueFileName = UploadedFile(page);
            page.Image = uniqueFileName;
            _Ipage.UpdatePage(page);
            return RedirectToAction("Index", "Page");
        }


        [HttpPost("UploadedFile")]
        public IActionResult New(Page model)      /* here  image upload  code */
        {

            string uniqueFileName = UploadedFile(model);

            model.Image = uniqueFileName;
            if (model.Id == 0)
            {
                _Ipage.InsertPage(model);
            }
            else
            {
                _Ipage.UpdatePage(model);

            }
            return RedirectToAction("Index", "Page");
        }

        private  string UploadedFile(Page model)
        {
            string uniqueFileName = null;

            if (model.ProfileImage != null)
            {
                //foreach (var file in model.ProfileImage)
                
                    string uploadsFolder =  Path.Combine(webHostEnvironment.WebRootPath, "Images");
                    uniqueFileName =  Guid.NewGuid().ToString() + "_" + model.ProfileImage.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);


                //using thread
                using (var filestream = new FileStream(filePath, FileMode.Create))
                {
                    model.ProfileImage.CopyTo(filestream);


                }




            }
            return uniqueFileName;
        }

        private void imgStreamer(string filepath,IFormFile prfimg)
        {
          
        }


        ///multiple files uploaded code are done from here////
       // [HttpPost]
       // public IActionResult Index(List<IFormFile> files)
       // {
       //     if (files != null)
       //     {
       //         foreach (var file in files)
       //         {
       //             if (file.Length > 0)
       //             {
       //                 var fileName = Path.GetFileName(file.FileName);
       //                 var myUniqueFileName = Convert.ToString(Guid.NewGuid());
       //                 var fileExtension = Path.GetExtension(fileName);
       //                 var newFileName = String.Concat(myUniqueFileName, fileExtension);
       //                 var filepath =
       //new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images")).Root + $@"\{newFileName}";
       //                 using (FileStream fs = System.IO.File.Create(filepath))
       //                 {
       //                     file.CopyTo(fs);
       //                     fs.Flush();
       //                 }

       //             }
       //         }
       //     }
       //     return View();
       // }


        //here  deletePage code and also image delete code are written //
        public class img {
            public int id { get; set; }
            public string imgdel { get; set; }
        }
        public IActionResult DeletePage(img a)
        {
            _Ipage.DeletePage(a.id);

            a.imgdel = Path.Combine(webHostEnvironment.WebRootPath, "Images", a.imgdel);
            FileInfo f1 = new FileInfo(a.imgdel);
            if(f1 != null)
            {
                System.IO.File.Delete(a.imgdel);
         

            }
            return RedirectToAction("Index", "Page");
        }
    }
}
