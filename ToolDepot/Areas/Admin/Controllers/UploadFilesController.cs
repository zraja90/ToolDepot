﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;
using ToolDepot.Areas.Admin.Models.UploadImages;
using ToolDepot.Filters;

namespace ToolDepot.Areas.Admin.Controllers
{
    [AdminAuthorize]
    public class UploadFilesController : Controller
    {
        //
        // GET: /UploadFiles/

        public ActionResult Index()
        {
            return View();
        }
       [ChildActionOnly]
        public ActionResult AllPictures()
       {
           var model = new List<UploadImageModel>();
           var path = Server.MapPath("/content/images/products/");

           var folder = new DirectoryInfo(path);
           var images = folder.GetFiles();
           
           string[] sizes = { "B", "KB", "MB", "GB" };
           

           for (int i = 0; i < images.Length; i++)
           {
               if (images[i].Extension != ".db")
               {
                   double len = images[i].Length;
                   int order = 0;
                   while (len >= 1024 && order + 1 < sizes.Length)
                   {
                       order++;
                       len = len/1024;
                   }
                   
                   string result = String.Format("{0:0.##} {1}", len, sizes[order]);
                   var item = new UploadImageModel
                                  {
                                      Name = images[i].Name,
                                      FileSize = result,
                                      ImageUrl = images[i].DirectoryName 
                                  };
                   model.Add(item);
                   
               }
           }
           
           return PartialView(model);
        }

        private string StorageRoot
        {
            get { return Path.Combine(Server.MapPath("~/Content/Images/Products/")); }
        }
        
        
        [HttpGet]
        public void Delete(string id)
        {
            var filename = id;
            var filePath = Path.Combine(Server.MapPath("~/Content/Images/Products/"), filename);

            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
        }

        
        [HttpGet]
        public void Download(string id)
        {
            var filename = id;
            var filePath = Path.Combine(Server.MapPath("~/Content/Images/Products/"), filename);

            var context = HttpContext;

            if (System.IO.File.Exists(filePath))
            {
                context.Response.AddHeader("Content-Disposition", "attachment; filename=\"" + filename + "\"");
                context.Response.ContentType = "application/octet-stream";
                context.Response.ClearContent();
                context.Response.WriteFile(filePath);
            }
            else
                context.Response.StatusCode = 404;
        }

        
        [HttpPost]
        public ActionResult UploadFiles()
        {
            var r = new List<ViewDataUploadFilesResult>();

            foreach (string file in Request.Files)
            {
                var statuses = new List<ViewDataUploadFilesResult>();
                var headers = Request.Headers;

                if (string.IsNullOrEmpty(headers["X-File-Name"]))
                {
                    UploadWholeFile(Request, statuses);
                }
                else
                {
                    UploadPartialFile(headers["X-File-Name"], Request, statuses);
                }

                JsonResult result = Json(statuses);
                result.ContentType = "text/plain";

                return result;
            }

            return Json(r);
        }

        private string EncodeFile(string fileName)
        {
            return Convert.ToBase64String(System.IO.File.ReadAllBytes(fileName));
        }

        private void UploadPartialFile(string fileName, HttpRequestBase request, List<ViewDataUploadFilesResult> statuses)
        {
            if (request.Files.Count != 1) throw new HttpRequestValidationException("Attempt to upload chunked file containing more than one fragment per request");
            var file = request.Files[0];
            var inputStream = file.InputStream;

            var fullName = Path.Combine(StorageRoot, Path.GetFileName(fileName));

            using (var fs = new FileStream(fullName, FileMode.Append, FileAccess.Write))
            {
                var buffer = new byte[1024];

                var l = inputStream.Read(buffer, 0, 1024);
                while (l > 0)
                {
                    fs.Write(buffer, 0, l);
                    l = inputStream.Read(buffer, 0, 1024);
                }
                fs.Flush();
                fs.Close();
            }
            statuses.Add(new ViewDataUploadFilesResult()
            {
                Name = fileName,
                Size = file.ContentLength,
                Type = file.ContentType,
                Url = "/Home/Download/" + fileName,
                DeleteUrl = "/Home/Delete/" + fileName,
                ThumbnailUrl = @"data:image/png;base64," + EncodeFile(fullName),
                DeleteType = "GET",
            });
        }

        private void UploadWholeFile(HttpRequestBase request, List<ViewDataUploadFilesResult> statuses)
        {
            for (int i = 0; i < request.Files.Count; i++)
            {
                var file = request.Files[i];

                var fullPath = Path.Combine(StorageRoot, Path.GetFileName(file.FileName));

                file.SaveAs(fullPath);

                statuses.Add(new ViewDataUploadFilesResult()
                {
                    Name = file.FileName,
                    Size = file.ContentLength,
                    Type = file.ContentType,
                    Url = "/Home/Download/" + file.FileName,
                    DeleteUrl = "/Home/Delete/" + file.FileName,
                    ThumbnailUrl = @"data:image/png;base64," + EncodeFile(fullPath),
                    DeleteType = "GET",
                });
            }
        }
    }

    
}

