using System;
using System.Runtime.Caching;
using System.Web.Mvc;
using System.Web.UI;
using WebApplication1.Bl;

namespace WebApplication1.Controllers
{
    public class StudentsController : Controller
    {
        private readonly StudentsService _studentsService = new StudentsService();

        // GET: Students
        [OutputCache(Duration = 15, Location = OutputCacheLocation.Client)]//Location = 
        public ActionResult Index()
        {
            return View(_studentsService.GetStudents());
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(string student)
        {
            _studentsService.AddStudent(student);
            MemoryCache.Default.Remove("Count");
            return RedirectToAction("Index");
        }

        public int Count()
        {
            if (MemoryCache.Default.Contains("Count"))
                return (int)MemoryCache.Default["Count"];

            int result = _studentsService.StudentsCount();
            MemoryCache.Default.Add("Count", result, DateTime.Now.AddSeconds(10));

            return result;
        }
    }
}