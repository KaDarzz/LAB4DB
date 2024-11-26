using Microsoft.EntityFrameworkCore;
using Lab4.Data;
using Lab4.Service;
using Lab4.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Регистрация кэширования
builder.Services.AddMemoryCache();
builder.Services.AddScoped<CachedDataService>();

// Регистрация сессий
builder.Services.AddSession();

// Регистрация контекста базы данных с использованием строки подключения
builder.Services.AddDbContext<HairdressingContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

// Включение сессии
app.UseSession();

// Включение инициализации базы данных через middleware
app.UseDbInitializer();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
