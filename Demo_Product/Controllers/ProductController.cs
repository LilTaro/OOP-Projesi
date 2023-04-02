using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Demo_Product.Controllers
{
    public class ProductController : Controller
    {
        ProductManager productManager = new ProductManager(new EntityFrameworkProductDal());
        public IActionResult Index()
        {
            var values = productManager.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddProduct() 
        { 
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(Product P)
        {
            ProductValidator validationRules = new ProductValidator();
            ValidationResult results = validationRules.Validate(P);
            if (results.IsValid)
            {
                productManager.TInsert(P);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public IActionResult DeleteProduct(int id) 
        {
            var values= productManager.GetById(id);
            productManager.Tdelete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateProduct(int id) 
        {
            var values = productManager.GetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            productManager.Tupdate(product);
            return RedirectToAction("Index");
        }
    }
}
