using Microsoft.EntityFrameworkCore;
using PetApp.Data;
using PetApp.Services;
using PetApp.Services.Pet;
using PetApp.Services.User; // Add this line

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register DbContext
builder.Services.AddDbContext<PetAppContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PetApp")));

// Register application services
builder.Services.AddScoped<IPetService, PetService>(); // Add this line
builder.Services.AddScoped<IUserService, UserService>(); // Add this line

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
