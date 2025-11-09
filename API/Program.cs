using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1️⃣ Đăng ký DbContext
builder.Services.AddDbContext<StoreContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2️⃣ Đăng ký Repository pattern
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

// 3️⃣ Các service mặc định
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// using AutoMapper; using System.Reflection; (nếu cần)
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// hoặc chỉ rõ assembly: typeof(MappingProfiles).Assembly

var app = builder.Build();
// ✅ Thêm đoạn seed
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<StoreContext>();
    await context.Database.MigrateAsync(); // Tự migrate DB nếu chưa có
    await StoreContextSeed.SeedAsync(context); // Gọi seed
}

// 4️⃣ Middleware pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
