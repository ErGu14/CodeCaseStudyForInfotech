using AutoMapper;
using Commercium.Data.Classes;
using Commercium.Data.DbContexts;
using Commercium.Data.Interfaces;
using Commercium.Entity.User.Account;
using Commercium.Service.Classes;
using Commercium.Service.Configs;
using Commercium.Service.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CommerciumDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SQLServer")));

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
/**********/
#region AddScopeds
builder.Services.AddScoped<ITransactionManager, TransactionManager>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IActivityLogService, ActivityLogService>();
builder.Services.AddScoped<IBusinessService, BusinessService>();
builder.Services.AddScoped<ICampaignService, CampaignService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IFavoriteService, FavoriteService>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IMessageService, MessageService>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<ISearchService, SearchService>();
builder.Services.AddScoped<ITagService, TagService>();
builder.Services.AddScoped<IUserFollowService, UserFollowService>();

builder.Services.AddScoped(typeof(IGenericManager<>), typeof(GenericManager<>));
builder.Services.AddScoped<ITransactionManager, TransactionManager>();

builder.Services.AddAutoMapper(typeof(AppMappingProfile));
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
