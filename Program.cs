using GymApp;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// used to generate Model from Visual studion CLI terminal:
// dotnet ef dbcontext scaffold Name=GymDB Npgsql.EntityFrameworkCore.PostgreSQL --output-dir Models --context GymDBContext  --force

// Configure DbContext with PostgreSQL
builder.Services.AddDbContext<GymDBContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("GymDB")));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
