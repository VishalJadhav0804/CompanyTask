using Microsoft.AspNetCore.Mvc;
using CompanyTask.Models;
using CompanyTask.Data;
using System.Diagnostics;

namespace CompanyTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly AppDbContext context;

        public HomeController(ILogger<HomeController> logger1, AppDbContext context1)
        {
            logger = logger1;
            context = context1;
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpGet]
        public IActionResult DisplayAllProducts()
        {
            var Data=context.products.ToList();
            return View(Data);
        }

        public IActionResult UpdateView()
        {
            var data = context.products.ToList();
            return View("UpdateView",data);
        }

        public IActionResult DeleteView()
        {
            var data=context.products.ToList();
            return View(data);
        }
        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            Product p1 = context.products.Find(product.ProductId);
            if(p1!=null)
            {
                p1.ProductName = product.ProductName;
                p1.CategoryName = product.CategoryName;
                p1.CategoryID = product.CategoryID;
                context.products.Update(p1);
                context.SaveChanges();
                return View("CrudeOption");
            }
            return View("Error");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Product p1=context.products.Find(id);

            if(p1!=null)
            {
                context.products.Remove(p1);
                context.SaveChanges();
            }
             return RedirectToAction("DeleteView");
        }

        [HttpPost]
        public IActionResult Submit(Product p)
        {
            if (ModelState.IsValid) 
            {
                context.products.Add(p);
                context.SaveChanges();
                return View("CrudeOption");
            }
            else
            {
         
                return View("Error");
            }
        }

        [HttpGet]
        public IActionResult CrudeOption()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
