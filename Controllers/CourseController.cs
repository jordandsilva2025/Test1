using Microsoft.AspNetCore.Mvc;
using MVC2.Services;

namespace MVC2.Controllers
{
    public class CourseController : Controller
    {
        private readonly CourseService _service;

        public CourseController(CourseService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var courses = _service.GetCourses();
            return View(courses);
        }

        public IActionResult Details(int id)
        {
            var course = _service.GetCourse(id);
            return View(course);
        }
    }
}
