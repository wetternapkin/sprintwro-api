using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Sprintwro.Infrastructure;
using Sprintwro.Interface;
using Sprintwro.Interface.Authentication;
using Sprintwro.Service;
using Sprintwro.Service.Session;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables();

builder.Services.AddOptions<AuthConfig>().BindConfiguration("Authentication");

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
builder.Services.ConfigureOptions<ConfigureJwtBearerOptions>();

builder.Services.AddHttpContextAccessor();

builder.Services.AddTransient<ISessionService, SessionService>();
builder.Services.AddSingleton<ISessionRepository, MemorySessionRepository>();
builder.Services.AddTransient<ICurrentUserAccessor, HttpCurrentUserAccessor>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
