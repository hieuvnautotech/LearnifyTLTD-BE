using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Đăng ký DbContext
builder.Services.AddDbContext<StoreContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// 2. Đăng ký Repository Pattern
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>(); // <- THÊM DÒNG NÀY
// 3. Đăng ký AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfiles).Assembly);

// 4. Đăng ký Controller + Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 5. Middleware xử lý Exception
app.UseMiddleware<API.Middleware.ExceptionMiddleware>();

// 6. Swagger cho Dev
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 7. Http
app.UseHttpsRedirection();
app.UseAuthorization();

// 8. Map API routes
app.MapControllers();

// 9. Seed database + Migration
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<StoreContext>();

    await context.Database.MigrateAsync();     // chạy migration
    await StoreContextSeed.SeedAsync(context); // chạy seed
}

// 10. Run app
app.Run();
