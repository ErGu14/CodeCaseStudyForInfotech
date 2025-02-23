using Commercium.Data.DbContexts;
using Commercium.Entity.User.Account;
using Commercium.Service.Configs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CommerciumDbContext>(x=>x.UseSqlServer(builder.Configuration.GetConnectionString("MsSqlServer")));

#region Identity & Configs
//Identity 
builder.Services.AddIdentity<AppUser, AppRole>(x =>
{
    x.SignIn.RequireConfirmedEmail = true;


    x.User.RequireUniqueEmail = true;


    x.Password.RequiredLength = 8;
    x.Password.RequireUppercase = true;
    x.Password.RequireNonAlphanumeric = true;
    x.Password.RequireDigit = true;
    x.Password.RequireLowercase = true;
}).AddEntityFrameworkStores<CommerciumDbContext>().AddDefaultTokenProviders(); 

builder.Services.Configure<JWTConfig>(builder.Configuration.GetSection("JwtConfig")); 
var jwtConfig = builder.Configuration.GetSection("JwtConfig").Get<JWTConfig>();


builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtConfig?.Issuer,
        ValidAudience = jwtConfig?.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig?.Secret ?? ""))
    };
});

#endregion
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthorization();

app.UseAuthentication();

app.MapControllers();

app.Run();
