var builder = WebApplication.CreateBuilder(args);

// Add YARP from configuration
builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

var app = builder.Build();

// Optional: CORS (if requests come from browsers)
app.UseCors(policy =>
    policy.AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader());

// Enable reverse proxy
app.MapReverseProxy();

app.Run();
