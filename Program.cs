var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//CORS service
var corsOrigins = builder.Configuration["Cors:AllowedOrigins"].Split(';');  //in "appsettings.json"
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins(corsOrigins) // Porta del tuo frontend
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});

var app = builder.Build();

app.UseCors("AllowSpecificOrigin");

// Configure the HTTP request pipeline.

app.MapGet(
    "/api/do-something",
    () =>
        {
            return Results.Ok("Did something");
        });

app.Run();