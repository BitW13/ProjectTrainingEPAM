using PagedList;
using PagedList.Mvc;
using FileSharing.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FileSharing.Entities.Core;
using FileSharing.Business.Interfaces;
using FileSharing.Entities.Logging;

namespace FileSharing.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IBusinessLogic _bl;

        private const int PAGE_SIZE = 2;

        public CategoryController(IBusinessLogic bl)
        {
            _bl = bl;
        }

        // GET: Category
        [AdminModer]
        public ActionResult ListOfCategories(int? page, string categoryName)
        {
            int pageNumber = (page ?? 1);

            var categories = _bl.Categories.GetAll();

            return View(categories.ToPagedList(pageNumber, PAGE_SIZE));
        }

        [AdminModer]
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View(new Category());
        }

        [AdminModer]
        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                _bl.Categories.Create(category);

                return RedirectToAction("Index", "Home");
            }

            return View(category);
        }

        [AdminModer]
        [HttpGet]
        public ActionResult EditCategory(int? id)
        {
            if (id == null)
            {
                Logger.Log.Error("EditCategory - id == null");
                return HttpNotFound();
            }

            var category = _bl.Categories.GetItemById(id);

            if (category == null)
            {
                Logger.Log.Error("EditCategory - category not found");
                return HttpNotFound();
            }

            return View(category);
        }

        [AdminModer]
        [HttpPost]
        public ActionResult EditCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                _bl.Categories.Update(category);

                return RedirectToAction("ListOfCategories");
            }
            return View(category);
        }

        [AdminModer]
        public ActionResult DeleteCategory(int? id)
        {
            if (id == null)
            {
                Logger.Log.Error("DeleteCategory - id == null");

                return HttpNotFound();
            }

            var category = _bl.Categories.GetItemById(id);

            if (category == null)
            {
                Logger.Log.Error("DeleteCategory - category not found");

                return HttpNotFound();
            }

            var files = _bl.Files.GetAll();

            bool exist = false;

            foreach(var file in files)
            {
                if(file.CategoryId == category.Id)
                {
                    exist = true;
                    break;
                }
            }

            if (exist)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                _bl.Categories.Delete(category);
            }
            return RedirectToAction("ListOfCategories");
        }
    }
}