using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection;
using NToastNotify;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddNToastNotifyToastr(new NToastNotify.ToastrOptions
{
    ProgressBar = true, 
    PositionClass = ToastPositions.TopRight, 
    CloseButton = true, 
    TimeOut = 5000, 
    ShowDuration = 1000, 
    HideDuration = 1000, 
    ShowEasing = "swing", 
    HideEasing = "linear", 
    ShowMethod = "fadeIn",
    HideMethod = "fadeOut" 
});
#region AddScoped

#endregion

builder
    .Services
    .AddHttpClient(
        "ECommerceAPI",
        client => client.BaseAddress = new Uri("http://localhost:5009/api/")
    );
builder
    .Services
    .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme) 
    .AddCookie(options => 
    {
        options.Cookie.Name = "Commercium.Account"; 
        options.LoginPath = "/Account/Login"; 
        options.AccessDeniedPath = "/Account/AccessDenied"; 
        options.ExpireTimeSpan = TimeSpan.FromHours(3); 
        options.Cookie.HttpOnly = true; 
    });
builder.Services.AddAuthorization();
#region DataProtection
builder.Services.AddDataProtection() 
    .PersistKeysToFileSystem(new DirectoryInfo(Path.Combine(builder.Environment.ContentRootPath, "keys"))) 
    .SetApplicationName("CommerciumWeb") 
    .SetDefaultKeyLifetime(TimeSpan.FromDays(21)); 

builder.Services.AddDistributedMemoryCache(); 
#endregion
var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    
    app.UseHsts();
}

app.UseHttpsRedirection();  

app.UseStaticFiles(); 

app.UseRouting(); 

app.UseAuthentication(); 

app.UseAuthorization(); 

app.UseNToastNotify(); 


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
