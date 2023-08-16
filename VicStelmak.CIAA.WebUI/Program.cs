using VicStelmak.CIAA.WebUI.Data;
using VicStelmak.CIAA.Infrastructure.DataAccess;
using VicStelmak.CIAA.Infrastructure.Identity;
using VicStelmak.CIAA.Infrastructure;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDefaultIdentity<CustomIdentityUser>(options => {
    options.SignIn.RequireConfirmedAccount = true;
    options.User.RequireUniqueEmail = true;
})
    .AddRoles<CustomIdentityRole>()
    .AddEntityFrameworkStores<CustomIdentityDbContext>();

builder.Services.AddIdentityCore<CustomIdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.User.RequireUniqueEmail = true;
})
    .AddRoles<CustomIdentityRole>()
    .AddEntityFrameworkStores<IdentityManagementDbContext>();

// Add services to the container.
builder.Services.ConfigureDependencyInjection(builder.Configuration);
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.UseAuthentication();
app.UseAuthorization();

app.Run();
