using Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public static class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context)
        {
            if (!context.Courses.Any())
            {
                var courses = new List<Course>
                {
                    new Course
                    {
                        Title = "React for Beginners",
                        Description = "Learn the basics of React step by step",
                        Price = 99,
                        Instructor = "John Doe",
                        Rating = 4.8m,
                        Image = "https://learnify-assets.s3.amazonaws.com/Images/react-course.png",
                        Level = "Beginner",
                        Language = "English"
                    },
                    new Course
                    {
                        Title = "ASP.NET Core Clean Architecture",
                        Description = "Build enterprise-grade APIs with Clean Architecture",
                        Price = 149,
                        Instructor = "Jane Smith",
                        Rating = 4.9m,
                        Image = "https://learnify-assets.s3.amazonaws.com/Images/aspnet-course.png",
                        Level = "Advanced",
                        Language = "English"
                    }
                };

                await context.Courses.AddRangeAsync(courses);
                await context.SaveChangesAsync();
            }
        }
    }
}
