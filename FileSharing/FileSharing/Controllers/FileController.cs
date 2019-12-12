using PagedList;
using PagedList.Mvc;
using FileSharing.Entities.Core;
using FileSharing.Entities.Models;
using FileSharing.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FileSharing.Business.Interfaces;
using FileSharing.Entities.Logging;

namespace FileSharing.Controllers
{
    public class FileController : Controller
    {
        private readonly IBusinessLogic _bl;

        private const int PAGE_SIZE = 2;

        public FileController(IBusinessLogic bl)
        {
            _bl = bl;
        }

        // GET: File
        [HttpGet]
        public ActionResult Index(int? page, string category, string expansion, string fileName, string access)
        {
            var categoryListDb = GetListCategories();

            List<string> categoryList = new List<string>()
            {
                "Выбрать категорию"
            };

            foreach(var dbCategory in categoryListDb)
            {
                categoryList.Add(dbCategory);
            }

            ViewBag.Categories = new SelectList(categoryList);

            var expansionListDb = GetListExpansions();

            List<string> expansionList = new List<string>()
            {
                "Выбрать расширение"
            };

            foreach(var dbExpansion in expansionListDb)
            {
                expansionList.Add(dbExpansion);
            }

            ViewBag.Expansions = new SelectList(expansionList);

            var accessListDb = GetListAccesses();

            List<string> accessList = new List<string>
            {
                "Выбрать доступ к файлу"
            };

            foreach(var dbAccess in accessListDb)
            {
                accessList.Add(dbAccess);
            }

            ViewBag.Accesses = new SelectList(accessList);

            int pageNumber = (page ?? 1);
            var files = _bl.Files.GetAll();

            if (fileName != "" && fileName != null)
            {
                files = files.Where(m => m.Name.Contains(fileName));
            }

            if (category != null && category != "Выбрать категорию")
            {
                var objCategory = _bl.Categories.GetElement(new Category { Name = category });

                files = files.Where(m => m.CategoryId == objCategory.Id);
            }


            var selectedFiles = new List<File>();

            if(expansion != null && expansion != "Выбрать расширение")
            {
                foreach (var file in files)
                {
                    var splitName = file.Name.Split('.');

                    if (splitName[splitName.Length - 1] == expansion)
                    {
                        selectedFiles.Add(file);
                    }
                }
            }
            else
            {
                selectedFiles = files.ToList();
            }

            var models = new List<IndexFileViewModel>();

            foreach(var file in selectedFiles)
            {
                var user = _bl.Users.GetItemById(file.UserId);

                models.Add(new IndexFileViewModel()
                {
                    Id = file.Id,
                    UserId = file.UserId,
                    FileAccessId = file.FileAccessId,
                    Name = file.Name,
                    UserLogin = user.Login,
                    Description = file.Description,
                    Size = Math.Round(file.Size, 2),
                    DownloadDate = file.DownloadDate
                });
            }

            return View(models.ToPagedList(pageNumber, PAGE_SIZE));
        }

        private List<string> GetListAccesses()
        {
            var accesses = _bl.FileAccesses.GetAll();

            var list = new List<string>();

            foreach(var access in accesses)
            {
                list.Add(access.Name);
            }

            return list;
        }

        private List<string> GetListExpansions()
        {
            var files = _bl.Files.GetAll();

            var list = new List<string>();

            foreach(var file in files)
            {
                var splitName = file.Name.Split('.');

                if(!list.Contains(splitName[splitName.Length - 1]))
                {
                    list.Add(splitName[splitName.Length - 1]);
                }
            }

            return list;
        }

        private List<string> GetListCategories()
        {
            var categories = _bl.Categories.GetAll();

            var list = new List<string>();

            foreach (var category in categories)
            {
                list.Add(category.Name);
            }

            return list;
        }

        #region Загрузка файлов 
        
        //GET: File/Upload
        [Auth]
        [HttpGet]
        public ActionResult Upload()
        {
            ViewBag.Categories = new SelectList(GetListCategories());

            return View(new UploadFileViewModel() { IsPublic = true });
        }

        //POST: File/Upload       
        [Auth]
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase upload, UploadFileViewModel file)
        {
            if(upload != null)
            {
                var files = Request.Files;

                string fileName = System.IO.Path.GetFileName(upload.FileName);

                var fileModel = new File
                {
                    UserId = Convert.ToInt32(HttpContext.Request.Cookies["Id"].Value),
                    Name = fileName,
                    Description = file.Description,
                    DownloadDate = DateTime.Now
                };

                if(file.Description == null)
                {
                    fileModel.Description = "";
                }

                var category = _bl.Categories.GetElement(new Category { Name = file.Category });

                if(category != null)
                {
                    fileModel.CategoryId = category.Id;
                }

                int size = upload.ContentLength;

                fileModel.Size = Math.Round(((double)size) / 1048576, 2);

                //fileModel.Url = "~/App_Data/" + fileName;

                _bl.Files.Create(fileModel);

                //upload.SaveAs(Server.MapPath(fileModel.Url));

                return RedirectToAction("ListOfUserFiles");
            }
            else
            {
                ModelState.AddModelError("", "Файл не найден");
            }
            return View(file);
        }

        #endregion

        //public ActionResult Download(int? id)
        //{
        //    if(id == null)
        //    {
        //        return RedirectToAction("Index");
        //    }

        //    var file = _bl.Files.GetItemById(id);

        //    if(file == null)
        //    {
        //        Logger.Log.Error("Download - file not found");
        //        return HttpNotFound();
        //    }

        //    string[] splitFullName = (file.Name).Split('.');

        //    string typeFile = "application/" + splitFullName[splitFullName.Length - 1];
        //    return File(Server.MapPath(file.Url), typeFile, file.Name);
        //}

        //[Auth]
        //public ActionResult ListOfUserFiles(int? id)
        //{
        //    var files = _bl.Files.GetAll();

        //    if(id == null)
        //    {
        //        id = Convert.ToInt32(HttpContext.Request.Cookies["Id"].Value);
        //    }

        //    files = files.Where(m => m.UserId == id);

        //    if (Request.Cookies["Admin"] == null && Request.Cookies["Moder"] == null && Request.Cookies["Id"].Value != id.ToString())
        //    {
        //        files = files.Where(m => m.Public == true);
        //    }            

        //    return View(files);
        //}

        //[Auth]
        //[HttpGet]
        //public ActionResult EditFile(int? id)
        //{
        //    ViewBag.Categories = new SelectList(GetListCategories());

        //    var file = _bl.Files.GetItemById(id);

        //    if(file == null)
        //    {
        //        Logger.Log.Error("EditFile - file not found");

        //        return HttpNotFound();
        //    }

        //    var category = _bl.Categories.GetItemById(file.CategoryId);

        //    var model = new EditFileViewModel()
        //    {
        //        Id = file.Id,
        //        Name = file.Name,
        //        Category = category.Name,
        //        Description = file.Description,
        //        IsPublic = file.Public
        //    };

        //    return View(model);
        //}

        //[Auth]
        //[HttpPost]
        //public ActionResult EditFile(EditFileViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var file = _bl.Files.GetItemById(model.Id);

        //        if (file == null)
        //        {
        //            Logger.Log.Error("EditFile - file not found");

        //            return HttpNotFound();
        //        }

        //        var category = _bl.Categories.GetElement(new Category { Name = model.Category });

        //        file.CategoryId = category.Id;
        //        file.Description = model.Description;
        //        file.Public = model.IsPublic;

        //        _bl.Files.Update(file);

        //        return RedirectToAction("Index");
        //    }

        //    return View(model);
        //}

        //[Auth]
        //public ActionResult DeleteFile(int? id)
        //{
        //    var file = _bl.Files.GetItemById(id);

        //    if(file == null)
        //    {
        //        Logger.Log.Error("DeleteFile - file not found");

        //        return HttpNotFound();
        //    }

        //    System.IO.File.Delete(Server.MapPath(file.Url));

        //    _bl.Files.Delete(file);

        //    return RedirectToAction("Index");
        //}
    }
}