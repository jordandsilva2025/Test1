using MVC2.Models;
using MVC2.Repositories;
using MVC2.Services;
using MVC2.Models;
using Moq;
using Xunit;

namespace MVC2.Tests
{
    public class CourseServiceTests
    {
        private readonly Mock<ICourseRepository> _mockRepo;
        private readonly CourseService _service;

        public CourseServiceTests()
        {
            _mockRepo = new Mock<ICourseRepository>();
            _service = new CourseService(_mockRepo.Object);
        }

        [Fact]
        public void GetCourses_ShouldReturnListOfCourses()
        {
            // Arrange
            _mockRepo.Setup(r => r.GetAll())
                     .Returns(new List<Course>
                     {
                     new Course { Id = 1, Title = "Maths", Credits = 4 },
                     new Course { Id = 2, Title = "Physics", Credits = 3 }
                     });

            // Act
            var result = _service.GetCourses();

            // Assert
            Assert.Equal(2, result.Count);
            _mockRepo.Verify(r => r.GetAll(), Times.Once);
        }

        [Fact]
        public void GetCourse_ShouldThrowException_WhenIdIsInvalid()
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => _service.GetCourse(0));
        }

        [Fact]
        public void GetCourse_ShouldReturnCourse_WhenIdIsValid()
        {
            // Arrange
            _mockRepo.Setup(r => r.GetById(1))
                     .Returns(new Course
                     {
                         Id = 1,
                         Title = "Maths",
                         Credits = 4
                     });

            // Act
            var result = _service.GetCourse(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Maths", result.Title);
            Assert.Equal(4, result.Credits);
            _mockRepo.Verify(r => r.GetById(1), Times.Once);
        }

        [Fact]
        public void GetCourse_ShouldReturnNull_WhenCourseDoesNotExist()
        {
            // Arrange
            _mockRepo.Setup(r => r.GetById(99))
                     .Returns((Course)null);

            // Act
            var result = _service.GetCourse(99);

            // Assert
            Assert.Null(result);
        }
    }
}
