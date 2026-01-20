using MVC2.Models;
using MVC2.Repositories;

namespace MVC2.Services
{
    public class CourseService
    {
        private readonly ICourseRepository _repository;

        public CourseService(ICourseRepository repository)
        {
            _repository = repository;
        }

        public List<Course> GetCourses()
        {
            return _repository.GetAll();
        }

        public Course GetCourse(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid course id");

            return _repository.GetById(id);
        }
    }
}
