using MedicalCRM.Business;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using MedicalCRM.DataAccess.Context;
using MedicalCRM.Mappings;
using MedicalCRM.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.RegisterServices(connectionString);
builder.Services.AddAutoMapper(typeof(MappingProfile), typeof(MedicalCRM.Business.Mappings.MappingProfile));
builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseMigrationsEndPoint();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapHub<ChatHub>("/chatHub");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}");
app.MapDefaultControllerRoute();
app.MapRazorPages();

var scope = app.Services.CreateScope();
await scope.AddSeeds();

app.Run();


