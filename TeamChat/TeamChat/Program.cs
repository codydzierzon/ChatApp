using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using NorthwindDemo.Services.Data;
using NorthwindDemo.Services.Data.EF;
using TeamChat.Models.Interfaces.Authentication;
using TeamChat.Models.Interfaces.Cryptography;
using TeamChat.Models.Interfaces.Data;
using TeamChat.Services.Authentication;
using TeamChat.Services.Cryptography;
using TeamChat.Services.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();


// Add services to the container.
builder.Services.AddRazorPages();

// Authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
       .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
                  options =>
                  {
                      options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
                      options.SlidingExpiration = true;
                      options.LoginPath = "/Account/Login";
                      options.LogoutPath = "/Account/Logout";
                  });

builder.Services.AddSession();
builder.Services.AddMemoryCache();
builder.Services.AddMvc();
builder.Services.AddHttpContextAccessor();

// data context
var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<TeamChatDataContext>(options => options.UseSqlServer(connection));

// custom services
builder.Services.AddScoped<IUserAuthService, CookieUserAuthService>();
builder.Services.AddScoped<IHasher, HashProvider>();
builder.Services.AddScoped<IUserService, EFUserService>();
//builder.Services.AddScoped<IMessageInformationService, EFMessageInformationService>();
builder.Services.AddScoped<IMessageService, EFMessages>();

// end custom

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

//add these - for custom authentication
app.UseSession();
app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
