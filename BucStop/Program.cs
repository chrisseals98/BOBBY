using BucStop;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BucStop.Areas.Identity.Data;



/*
 * This is the base program which starts the project.
 */

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("BucStopContextConnection") ?? throw new InvalidOperationException("Connection string 'BucStopContextConnection' not found.");

builder.Services.AddDbContext<BucStopContext>(options =>
    options.UseSqlite(connectionString));

builder.Services.AddDefaultIdentity<BucStopUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<BucStopContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var provider=builder.Services.BuildServiceProvider();
var configuration=provider.GetRequiredService<IConfiguration>();

builder.Services.AddHttpClient<MicroClient>(client =>
{
    var baseAddress = new Uri(configuration.GetValue<string>("Micro"));

    client.BaseAddress = baseAddress;
});

builder.Services.AddAuthentication().AddMicrosoftAccount(options =>
{
    options.ClientId = configuration["ClientId"];
    options.ClientSecret = configuration["Secret"];
});

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

//Handles routing to "separate" game pages by setting the Play page to have subpages depending on ID
app.MapControllerRoute(
    name: "Games",
    pattern: "Games/{action}/{id?}",
    defaults: new { controller = "Games", action = "Index" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.Run();
