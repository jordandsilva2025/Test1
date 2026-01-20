using MVC2.Models;

namespace MVC2.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly List<Course> _courses = new()
    {
        new Course { Id = 1, Title = "Maths", Credits = 4 },
        new Course { Id = 2, Title = "Physics", Credits = 3 }
    };

        public List<Course> GetAll()
        {
            return _courses;
        }

        public Course GetById(int id)
        {
            return _courses.FirstOrDefault(c => c.Id == id);
        }
    }
}
