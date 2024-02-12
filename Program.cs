using Hotel_Booking.Data;
using Hotel_Booking.Models;
using Hotel_Booking.Repository.AdminRepo;
using Hotel_Booking.Repository.FacilitiesRepo;
using Hotel_Booking.Repository.FeaturesRepo;
using Hotel_Booking.Repository.FoodDrinksRepo;
using Hotel_Booking.Repository.FunProgramsRepo;
using Hotel_Booking.Repository.HomesRepo;
using Hotel_Booking.Repository.HotelRepo;
using Hotel_Booking.Repository.RoomImageRepo;
using Hotel_Booking.Repository.RoomsRepo;
using Hotel_Booking.Repository.ServicesRepo;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

// options => options.SignIn.RequireConfirmedAccount = true
builder.Services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>();


builder.Services.AddScoped<IAdminRepo, AdminRepo>();
builder.Services.AddScoped<IHomeRepo, HomeRepo>();
builder.Services.AddScoped<IHotelRepo, HotelRepo>();
builder.Services.AddScoped<IRoomRepo, RoomRepo>();
builder.Services.AddScoped<IRoomImageRepo, RoomImageRepo>();
builder.Services.AddScoped<IFeatureRepo, FeatureRepo>();
builder.Services.AddScoped<IFacilityRepo, FacilityRepo>();
builder.Services.AddScoped<IFoodDrinkRepo, FoodDrinkRepo>();
builder.Services.AddScoped<IFunProgramRepo, FunProgramRepo>();
builder.Services.AddScoped<IServiceRepo, ServiceRepo>();

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
    pattern: "{controller=Route}/{action=Index}/{id?}");

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

