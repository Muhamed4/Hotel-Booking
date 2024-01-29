using Hotel_Booking.Data;
using Hotel_Booking.Models;
using Hotel_Booking.Repository.FeaturesRepo;
using Hotel_Booking.Repository.HotelRepo;
using Hotel_Booking.Repository.RoomImageRepo;
using Hotel_Booking.Repository.RoomsRepo;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>();


builder.Services.AddScoped<IHotelRepo, HotelRepo>();
builder.Services.AddScoped<IRoomRepo, RoomRepo>();
builder.Services.AddScoped<IRoomImageRepo, RoomImageRepo>();
builder.Services.AddScoped<IFeatureRepo, FeatureRepo>();

var app = builder.Build();

// // Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// app.MapRazorPages();


// Seed roles during application startup
using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    ConfigureRoles(roleManager);
}

// Method to seed roles
static void ConfigureRoles(RoleManager<IdentityRole> roleManager)
{
    string[] roleNames = { "NUser", "Admin" };

    foreach (var roleName in roleNames)
    {
        if (!roleManager.RoleExistsAsync(roleName).Result)
        {
            roleManager.CreateAsync(new IdentityRole(roleName)).Wait();
        }
    }
}

app.Run();

