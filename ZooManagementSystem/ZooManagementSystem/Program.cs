using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ZMS.Databases.Data;
using ZMS.Services.Abstractions;
using ZMS.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    string connectionString = "Server=MOHAMMAD-IMRAN;Database=ZooManagementSystem;User Id=sa;Password=imran;TrustServerCertificate=True;MultipleActiveResultSets=true";
    options.UseSqlServer(connectionString);
});
builder.Services.AddTransient<IAnimalFoodService,AnimalFoodService>();
builder.Services.AddTransient<IAnimalService, AnimalService>();
builder.Services.AddTransient<IFoodService, FoodService>();


builder.Services.AddMvc();
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
