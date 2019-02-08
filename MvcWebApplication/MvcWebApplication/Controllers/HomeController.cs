using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWebApplication.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        // Create Category Functionality
        public ActionResult Category()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Category(tbl_Category category)
        {
            // Creates a Database Object
            MVCWebAppDbContext db = new MVCWebAppDbContext();
            
            // Using Database object refrence select table on which you want to perform action such as add, select, update, delete
            // Action takes the whole Object 
            db.tbl_Category.Add(category);

            // After performing action you need to save changes to db using SaveChanges operation
            db.SaveChanges();
                 
            // --------------------------------------------
            //ViewBag.CategoryName = name;                 |
            //ViewBag.CategoryDesc = description;          |
            // --------------------------------------------
            return RedirectToAction("ListCategory");
        }


        // Showing List of Category
        [HttpGet]
        public ActionResult ListCategory()
        {
            MVCWebAppDbContext db = new MVCWebAppDbContext();

            var categoryList = db.tbl_Category.ToList();
            //ViewBag.CategoryList = db.tbl_Category.ToList();

            return View(categoryList);
        }


        //IMPLEMENTED EDIT FUNCTIONALITY
        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            MVCWebAppDbContext db = new MVCWebAppDbContext();

            var editCategory = db.tbl_Category.Find(id);

            return View(editCategory);
        }

        [HttpPost]
        public ActionResult EditCategory(tbl_Category category)
        {
            MVCWebAppDbContext db = new MVCWebAppDbContext();

            db.Entry(category).State = System.Data.Entity.EntityState.Modified;
            
            db.SaveChanges();

            return RedirectToAction("ListCategory");

        }


        // Implementing Delete Functionality

        public ActionResult DeleteCategory(int id)
        {
            MVCWebAppDbContext db = new MVCWebAppDbContext();

            var delCategoryID = db.tbl_Category.Find(id);

            db.tbl_Category.Remove(delCategoryID);

            db.SaveChanges();

            return RedirectToAction("ListCategory");
        }



    }
}
