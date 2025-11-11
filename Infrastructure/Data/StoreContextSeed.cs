using Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public static class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context)
        {
            // ✅ Seed Categories trước
            if (!context.Categories.Any())
            {
                var categories = new List<Category>
                {
                    new Category { Name = "IT & Software" },
                    new Category { Name = "Business" },
                    new Category { Name = "Design" }
                };

                await context.Categories.AddRangeAsync(categories);
                await context.SaveChangesAsync();
            }

            // ✅ Lấy lại CategoryId vừa seed
            var itCategoryId = context.Categories.First(x => x.Name == "IT & Software").Id;

            // ✅ Seed Courses
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
                        Language = "English",
                        CategoryId = itCategoryId,   // ✅ BẮT BUỘC CÓ
                        LastUpdated = DateTime.UtcNow,
                        Published = true
                    },
                    new Course
                    {
                        Title = "ASP.NET Core Clean Architecture",
                        Description = "Build enterprise APIs with Clean Architecture",
                        Price = 149,
                        Instructor = "Jane Smith",
                        Rating = 4.9m,
                        Image = "https://learnify-assets.s3.amazonaws.com/Images/aspnet-course.png",
                        Level = "Advanced",
                        Language = "English",
                        CategoryId = itCategoryId,   // ✅ BẮT BUỘC CÓ
                        LastUpdated = DateTime.UtcNow,
                        Published = true
                    }
                };

                await context.Courses.AddRangeAsync(courses);
                await context.SaveChangesAsync();
            }
        }
    }
}
