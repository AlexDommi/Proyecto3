using Microsoft.EntityFrameworkCore;
using Proyecto3.Data;
using Proyecto3.Services.Interfaces;
using Proyecto3.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);

var connection = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connection));

#region Servicios
builder.Services.AddScoped<IAgreementsService,AgreementsService>();
builder.Services.AddScoped<ICustomersService, CustomersService>();
#endregion Servicios

// Add services to the container.
builder.Services.AddControllersWithViews();

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
