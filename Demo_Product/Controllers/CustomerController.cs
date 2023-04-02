using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Demo_Product.Controllers
{
    public class CustomerController : Controller
    {
        CustomerManager customerManager = new CustomerManager(new EntityFrameworkCustomerDal());
        JobManager jobManager = new JobManager(new EntityFrameworkJobDal());
        public IActionResult Index()
        {
            var values = customerManager.GetCustomersListWithJob();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddCustomer() 
        {
            
            List<SelectListItem> values = (from X in jobManager.TGetList()
            select new SelectListItem
            {
                Text=X.JobName,Value=X.JobID.ToString()
            }).ToList();
            ViewBag.V =values;
            return View();
        }
        [HttpPost]
        public IActionResult AddCustomer(Customer P) 
        {
            CustomerValidator validationRules = new CustomerValidator();
            ValidationResult results = validationRules.Validate(P);
            if (results.IsValid)
            {
                customerManager.TInsert(P);
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
        public IActionResult DeleteCustomer(int id) 
        {
            var values = customerManager.GetById(id);
            customerManager.Tdelete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateCustomer(int id)
        {
            List<SelectListItem> value = (from X in jobManager.TGetList()
                                           select new SelectListItem
                                           {
                                               Text = X.JobName,
                                               Value = X.JobID.ToString()
                                           }).ToList();
            ViewBag.V = value;
            var values = customerManager.GetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateCustomer(Customer P)
        {
            customerManager.Tupdate(P);
            return RedirectToAction("Index");
        }
    }
}
