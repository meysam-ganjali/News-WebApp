using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using News.Web.Data;

#region Variables

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DatabaseContextConnection") ?? throw new InvalidOperationException("Connection string 'DatabaseContextConnection' not found.");

#endregion

#region Register Services

builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddEntityFrameworkStores<DatabaseContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

#endregion

#region Piplines


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
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.Run();


#endregion
