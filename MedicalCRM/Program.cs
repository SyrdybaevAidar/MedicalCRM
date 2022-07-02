using MedicalCRM.Business;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using MedicalCRM.Mappings;
using MedicalCRM.Hubs;
using MedicalCRM.Business.Models.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("TestConnection");
builder.Services.RegisterServices(connectionString);
builder.Services.AddAutoMapper(typeof(MappingProfile), typeof(MedicalCRM.Business.Mappings.MappingProfile));
builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();
builder.Services.Configure<OrganizationEmailConfiguration>(builder.Configuration.GetSection("OrganizationEmail"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseMigrationsEndPoint();
} else {
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapHub<ChatHub>("/chatHub");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Patient}/{action=Login}");
app.MapDefaultControllerRoute();
app.MapRazorPages();

var scope = app.Services.CreateScope();
await scope.AddSeeds();

app.Run();


