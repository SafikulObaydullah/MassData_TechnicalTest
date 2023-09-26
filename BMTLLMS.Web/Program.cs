using BMTLLMS.Domain;
using BMTLLMS.Repository.Contracts;
using BMTLLMS.Repository.Implementations;
using BMTLLMS.Service.Contracts;
using BMTLLMS.Service.Implementations;
using BMTLLMS.Web.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.FileProviders;
//using NuGet.Packaging.Signing;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
var conStr = builder.Configuration.GetConnectionString("conStr");
Services.RegisterDependencies(builder.Services, conStr);
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(o => o.LoginPath = new PathString("/account/login"));


builder.Services.AddCors(m =>
{
   m.AddPolicy("Powersoft", b =>
    b.AllowAnyHeader()
    .AllowAnyMethod()
    .AllowAnyOrigin()
   );
});
builder.Services.Configure<FormOptions>(o =>
{
   o.ValueLengthLimit = int.MaxValue;
   o.MultipartBodyLengthLimit = int.MaxValue;
   o.MemoryBufferThreshold = int.MaxValue;
});

var app = builder.Build();
var config = app.Configuration;

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseCors(op =>
{
   op.AllowAnyOrigin();
   op.AllowAnyHeader();
   op.AllowAnyMethod();
});

app.UseHttpsRedirection();
app.UseStaticFiles(new StaticFileOptions
{
   //FileProvider = new PhysicalFileProvider(
   //        Path.Combine(builder.Environment.ContentRootPath, "DocUpload")),
   //RequestPath = "/DocUpload"
});
//app.UseStaticFiles(new StaticFileOptions
//{
//   FileProvider = new PhysicalFileProvider
//   (Path.Combine(app.Environment.ContentRootPath, "DocUpload")),
//   RequestPath = "/DocUpload"
//});

app.UseAuthentication();
app.UseRouting();
app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
   endpoints.MapControllers();
});


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
