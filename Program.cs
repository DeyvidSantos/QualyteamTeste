using Microsoft.EntityFrameworkCore;
using QualyteamTeste.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DbConection>(options => options.UseMySql("server=localhost;initial catalog=qualyteam2;uid=admin;pwd=123456;", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.34-mysql")));


var app = builder.Build();

//builder.Services.AddDbContext<DbConection>(options => options.UseMySql("server=localhost;initial catalog=qualyteam2;uid=admin;pwd=123456;",Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.34-mysql")));



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
    pattern: "{controller=Documentoes}/{action=Index}/{id?}");

app.Run();
