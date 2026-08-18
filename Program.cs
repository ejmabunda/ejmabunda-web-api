using ejmabunda_web_api.Models;
using ejmabunda_web_api.Repositories;
using ejmabunda_web_api.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Only the deployed frontend origin may call this API from a browser.
const string FrontendCorsPolicy = "FrontendCorsPolicy";

builder.Services.AddCors(options =>
{
    options.AddPolicy(FrontendCorsPolicy, policy =>
    {
        policy.WithOrigins("https://ejmabunda.dev")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// JWT bearer authentication, required by default on controllers (see [Authorize] in
// ProfileController) and opted out of per-action with [AllowAnonymous] for public reads.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => {});

builder.Services.AddControllers();

// EF Core against SQL Server; connection string comes from "ConnectionStrings:DefaultConnection"
// in appsettings.json (or the environment/user-secrets equivalent).
builder.Services.AddDbContext<PortfolioContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Controller -> Service -> Repository per feature; see Repositories/ and Services/.
builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
builder.Services.AddScoped<IProfileService, ProfileService>();

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
