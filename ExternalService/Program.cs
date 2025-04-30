using ExternalService.Repository.ExternalTicketConfig;
using ExternalService.Repository.ExternalTicketConfigRepo;
using ExternalService.Service.ExternalTicketConfig;
using ExternalService.Domain.Data;

using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configure DbContext
builder.Services.AddDbContext<ExternalServiceDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register Repositories and Services
builder.Services.AddScoped<IExternalTicketConfigRepo, ExternalTicketConfigRepo>();
builder.Services.AddScoped<IExternalTicketConfigService, ExternalTicketConfigService>();

// Add controllers
builder.Services.AddControllers();

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});

// Swagger setup
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "External Service API",
        Version = "v1"
    });
});

var app = builder.Build();

// Enable CORS
app.UseCors("AllowAll");

// Enable Swagger only in dev/staging/production
if (app.Environment.IsDevelopment() || app.Environment.IsStaging() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "External Service API V1");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
