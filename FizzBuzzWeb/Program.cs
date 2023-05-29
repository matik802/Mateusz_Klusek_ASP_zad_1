using Microsoft.EntityFrameworkCore;
using FizzBuzzWeb.Data;
using Microsoft.AspNetCore.Identity;
using FizzBuzzWeb.Services;
using FizzBuzzWeb.Utilities;
using System.Configuration;
using LearnASPNETCoreRazorPagesWithRealApps.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10); //czas trwania sesji
    options.Cookie.HttpOnly = true; //domyslne (dostep do cookie tylko przez http)
    options.Cookie.IsEssential = true; //domyslne (jezeli uwywamy cookie to true)
});
builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("EFDemoDB")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddProjectService();

//builder.Services.AddMvc(options =>
//{
//    options.Filters.Add(new CustomPageFilter(builder.Configuration));
//});
//builder.Services.AddTransient<IGeoService, GeoService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseBrowserMiddleware();
app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();
app.UseSession();

app.MapRazorPages();

app.Run();
