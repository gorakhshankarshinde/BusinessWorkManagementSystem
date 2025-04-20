using BusinessWorkManagementSystem.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BusinessWorkDBContext>(option => option.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));



#region To read app setting

var binder = new ConfigurationBuilder().
                   SetBasePath(
                   Directory.GetCurrentDirectory()).
                   AddJsonFile("appsettings.json");

IConfiguration configuration = binder.Build();

//Below line is used to read the application settings
// those are available under "appsettings" section.
var appSettings = configuration.GetSection("appSettings").Get<AppSettings>();



#endregion

#region Serilog log object created
if (appSettings != null)
{ 
    Log.Logger = new LoggerConfiguration().
        WriteTo.File(appSettings.SerilogPath, rollingInterval: RollingInterval.Day).
        CreateLogger();
}
#endregion

#region Added settings for session
//builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(option =>
{
    option.IdleTimeout = TimeSpan.FromMinutes(10);
});

builder.Services.AddMemoryCache(); // This method add in memory implementation at server side to store session information.

//Below IHttpContextAccessor is use to access session variable on view page.
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

#endregion

var app = builder.Build();

//Below line added for session
app.UseSession();

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
    pattern: "{controller=UserLogin}/{action=UserLogin}/{id?}");

app.Run();


/// <summary>
/// Below class is added to read "AppSettings" section.
/// </summary>
public class AppSettings
{
    /// <summary>
    /// Below property is use to read "EnvironmentName" from the appsettings section.
    /// </summary>
    public string EnvironmentName { get; set; }

    public string SerilogPath { get; set; }
}
