using CsvStoreApi.Configuration;
using CsvStoreApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Bind CsvSettings from appsettings.json
builder.Services.Configure<CsvSettings>(
    builder.Configuration.GetSection("CsvSettings"));

// Register services
builder.Services.AddScoped<IProductService, CsvProductService>();

// Add controllers + Swagger/OpenAPI
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // Enable Swagger UI in development so root URL can be used to discover endpoints
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Redirect root to Swagger UI so visiting https://localhost:7138/ shows API docs
app.MapGet("/", () => Results.Redirect("/swagger"));

app.MapControllers();

app.Run();
