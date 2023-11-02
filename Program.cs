using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;
using MVC.Areas.ProductManage.Services;
using MVC.ExtendMethods;
using MVC.Models;
using MVC.Services;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppMVCConnectionString"));
});

builder.Services.Configure<RazorViewEngineOptions>(options =>
{
    // {0} - ten Action
    // {1} - ten Controller
    // {2} - ten Area

    options.ViewLocationFormats.Add("/MyViews/{1}/{0}" + RazorViewEngine.ViewExtension);
});

builder.Services.AddSingleton<ProductService, ProductService>();
builder.Services.AddSingleton<PlanetService>();

builder.Services.AddLogging();

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
app.AddStatusCodePage(); //Tuy bien respone loi : 404-599

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
    {


        endpoints.MapControllers();

        endpoints.MapControllerRoute(
                name: "first",
                pattern: "{url:regex(^((xemsanpham)|(viewproduct))$)}/{id:range(2,4)}",
                defaults: new
                {
                    controller = "First",
                    action = "ViewProduct"
                }
    //            constraints: new
    //            {
    //                url = new RegexRouteConstraint(@"^((xemsanpham)|(viewproduct))$"),
    //                id = new RangeRouteConstraint(2,4)
    //}
            );

        endpoints.MapAreaControllerRoute(
                name:"product",
                pattern: "/{controller}/{action=Index}/{id?}",
                areaName: "ProductManage"
            );


        endpoints.MapControllerRoute(
                name: "default",
                pattern: "/{controller=Home}/{action=Index}/{id?}"
                //defaults: new
                //{
                //    controller = "First",
                //    action = "ViewProduct",
                //}
            );

        endpoints.MapRazorPages();
    });
app.Run();
