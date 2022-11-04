using System.Reflection;
using WebProjectOnAzure.Data;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Common.Mappings;
using Shop.Application.Interfaces;
using Shop.Persistence;
using Shop.Application;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new AssemblyMappingProfile(typeof(IShopDbContext).Assembly));
});
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddApplication();
var connectionString = builder.Configuration.GetConnectionString("IdentityContextConnection");
builder.Services.AddDbContext<IdentityContext>(options =>
    options.UseSqlServer(connectionString));


builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
        .AddEntityFrameworkStores<IdentityContext>();


builder.Services.AddControllersWithViews()
    .AddRazorOptions(options =>
    {
        options.ViewLocationFormats.Add("/{0}.cshtml");
    });

builder.Services
    .AddConfig(builder.Configuration)
    .AddDependencyGroup();

builder.Services.AddSession();

builder.Services.AddSignalR();


builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication();
var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStaticFiles();
app.UseRouting();
app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();
app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Use(async (context, next) =>
{
    Console.WriteLine($"1. Endpoint: {context.GetEndpoint()?.DisplayName ?? "(null)"}");
    await next(context);
});
app.Run();
