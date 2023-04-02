using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Demo_Product.Controllers
{
    public class JobController : Controller
    {
        JobManager JobManager = new JobManager(new EntityFrameworkJobDal());
        public IActionResult Index()
        {
            var values = JobManager.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddJob()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddJob(Job job)
        {
            JobManager.TInsert(job);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteJob(int id)
        {
            var values = JobManager.GetById(id);
            JobManager.Tdelete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateJob(int id)
        {
            var values = JobManager.GetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateJob(Job job)
        {
            JobManager.Tupdate(job);
            return RedirectToAction("Index");
        }
    }
}
