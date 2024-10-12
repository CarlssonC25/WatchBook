using Microsoft.EntityFrameworkCore;
using System.IO;
using WatchBook.Data;
using WatchBook.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure SQLite DbContext
MyService.Initialize(builder.Configuration);

string dbPath = MyService.DbPath();
builder.Services.AddDbContext<MyDbContext>(options =>
	options.UseSqlite(dbPath));


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

// Controller einstellung start seizte
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=WatchBook}/{action=Index}");   // <-- {controller= ****** }

app.Run();
