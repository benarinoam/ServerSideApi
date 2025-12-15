using Microsoft.EntityFrameworkCore;
using WebApirestful.DataAccess;
var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("PostgreSQLConnection")!;

Console.WriteLine($"Environment: {builder.Environment.EnvironmentName}");                      
Console.WriteLine($"Using connection string: {connectionString}");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowAngularClient",
        policy =>
        {
            // During development, allow all origins/methods/headers for simplicity
            // In production, change this to your NAS IP/domain for better security
            policy.AllowAnyOrigin() 
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

builder.Services.AddControllers(); 
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.MapOpenApi();
}


app.UseCors("AllowAngularClient");
app.UseAuthorization();
//app.UseHttpsRedirection();
app.UseDefaultFiles();
app.UseStaticFiles();

app.MapControllers();
// Fallback to index.html for Angular routing
app.MapFallbackToFile("index.html");

app.Run();