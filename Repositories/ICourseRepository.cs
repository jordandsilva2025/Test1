using MVC2.Models;

namespace MVC2.Repositories
{
    public interface ICourseRepository
    {
        List<Course> GetAll();
        Course GetById(int id);
    }
}
