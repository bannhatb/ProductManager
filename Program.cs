
using Microsoft.EntityFrameworkCore;
using ProductManager.Models;
using ProductManager.Services;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var connectionString = builder.Configuration.GetConnectionString("Default");
 


// Add services to the container.
services.AddControllersWithViews();

// // connection MySQL
// var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
// // Replace 'YourDbContext' with the name of your own DbContext derived class.
// services.AddDbContext<DataContext>(
//     dbContextOptions => dbContextOptions
//         .UseMySql(connectionString, serverVersion)
//         .LogTo(Console.WriteLine, LogLevel.Information)
//         .EnableSensitiveDataLogging()
//         .EnableDetailedErrors()
// );

//Connection SQL server
services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(connectionString));


services.AddTransient<IProductService, ProductService>(); //ở đâu gọi ProductService là nó new 1 object
// services.AddSingleton<IProductService, ProductService>(); //chỉ được tạo 1 lần khi được request đầu tiên và sử dụng trong suốt quá trình tồn tại của ứng dụng
// services.AddScoped<IProductService, ProductService>(); //run là sẽ new 1 đối tượng, thực hiện xong request này rồi kết thúc mới thực hiện request khác
services.AddTransient<ICategoryService, CategoryService>();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
