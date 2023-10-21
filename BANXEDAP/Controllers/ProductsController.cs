using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using BANXEDAP.Models;

namespace BANXEDAP.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index(string search = "", string SortColumn = "Id", string IconClass = "fa-sort-asc", int page = 1)
        {
            mydataEntities db = new mydataEntities();
            List<Product> employees = db.Products.Where(row => row.Name.Contains(search)).ToList();
            ViewBag.Search = search;
            ViewBag.SortColumn = SortColumn;
            ViewBag.IconClass = IconClass;

            if (SortColumn == "Id")
            {
                if (IconClass == "fa-sort-asc")
                {
                    employees = employees.OrderBy(row => row.Id).ToList();
                }
                else
                {
                    employees = employees.OrderByDescending(row => row.Id).ToList();
                }
            }
            else if (SortColumn == "Name")
            {
                if (IconClass == "fa-sort-asc")
                {
                    employees = employees.OrderBy(row => row.Name).ToList();
                }
                else
                {
                    employees = employees.OrderByDescending(row => row.Name).ToList();
                }
            }
            else if (SortColumn == "Price")
            {
                if (IconClass == "fa-sort-asc")
                {
                    employees = employees.OrderBy(row => row.Price).ToList();
                }
                else
                {
                    employees = employees.OrderByDescending(row => row.Price).ToList();
                }
            }
            int NoOfRecordPerPage = 15;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(employees.Count) / Convert.ToDouble(NoOfRecordPerPage)));
            int NoOfRecordSkip = (page - 1) * NoOfRecordPerPage;
            ViewBag.NoOfPages = NoOfPages;
            ViewBag.Page = page;
            employees = employees.Skip(NoOfRecordSkip).Take(NoOfRecordPerPage).ToList();
            return View(employees);
            return View(employees);
        }

        public ActionResult Detail(int id)
        {
            mydataEntities db = new mydataEntities();
            Product product = db.Products.Where(row => row.Id == id).FirstOrDefault();
            ViewBag.Product = product;
            Deparment dep = db.Deparments.Where(cat => cat.Id == product.DepId).FirstOrDefault();
            ViewBag.dep = dep;
            return View(product);
        }
    }

}