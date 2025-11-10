using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ===============================
// 1. Đăng ký DbContext
// ===============================
builder.Services.AddDbContext<StoreContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// ===============================
// 2. Đăng ký Repository Pattern
// ===============================
// Dùng chung cho Course, Category, Lecture,...
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

// ===============================
// 3. Đăng ký AutoMapper
// ===============================
builder.Services.AddAutoMapper(typeof(MappingProfiles).Assembly);

// ===============================
// 4. Đăng ký Controller + Swagger
// ===============================
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ===============================
// 5. Middleware xử lý Exception
// ===============================
// PHẢI đặt TRÊN MapControllers()
app.UseMiddleware<API.Middleware.ExceptionMiddleware>();

// ===============================
// 6. Swagger (DEV environment)
// ===============================
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// ===============================
// 7. Http
// ===============================
app.UseHttpsRedirection();

app.UseAuthorization();

// ===============================
// 8. Map API routes
// ===============================
app.MapControllers();

// ===============================
// 9. Seed database + Migration (nếu cần)
// ===============================
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<StoreContext>();

    await context.Database.MigrateAsync(); // chạy migration
    await StoreContextSeed.SeedAsync(context); // chạy seed nếu có
}

// ===============================
// 10. Run app
// ===============================
app.Run();
