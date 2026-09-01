using System.Security.Cryptography;
using ejmabunda_web_api.Models;
using ejmabunda_web_api.Repositories;
using ejmabunda_web_api.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<ApiSettings>(builder.Configuration.GetSection("ApiSettings"));

// Only the deployed frontend origin may call this API from a browser.
const string FrontendCorsPolicy = "FrontendCorsPolicy";

builder.Services.AddCors(options =>
{
    options.AddPolicy(FrontendCorsPolicy, policy =>
    {
        policy.WithOrigins(
            builder.Configuration.GetSection("ApiSettings")["FrontendUrl"]!.ToString())
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

using var rsa = RSA.Create(2048);
var publicKey = new RsaSecurityKey(rsa.ExportParameters(false));
var secretKey = new RsaSecurityKey(rsa.ExportParameters(true));

builder.Services.AddKeyedSingleton("public", publicKey);
builder.Services.AddKeyedSingleton("private", secretKey);

// JWT bearer authentication, required by default on controllers (see [Authorize] in
// ProfileController) and opted out of per-action with [AllowAnonymous] for public reads.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration.GetSection("ApiSettings")["ApiUrl"]!.ToString(),
            ValidAudience = builder.Configuration.GetSection("ApiSettings")["ApiUrl"]!.ToString(),
            IssuerSigningKey = publicKey
        };
    });

builder.Services.AddAuthorization();

builder.Services.AddControllers();

// EF Core against SQL Server; connection string comes from "ConnectionStrings:DefaultConnection"
// in appsettings.json (or the environment/user-secrets equivalent).
builder.Services.AddDbContext<PortfolioContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Controller -> Service -> Repository per feature; see Repositories/ and Services/.
builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
builder.Services.AddScoped<IProfileService, ProfileService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ISkillRepository, SkillRepository>();
builder.Services.AddScoped<ISkillService, SkillService>();
builder.Services.AddScoped<IExperienceRepository, ExperienceRepository>();
builder.Services.AddScoped<IExperienceService, ExperienceService>();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUi(options =>
    {
        options.DocumentPath = "/openapi/v1.json";
    });
}

app.UseHttpsRedirection();

app.UseCors(FrontendCorsPolicy);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
