using Microsoft.EntityFrameworkCore;
using Statly.API.Services;
using Statly.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// ======================
// SERVICES (AVANT Build)
// ======================

// Controllers
builder.Services.AddControllers();

// DbContext
builder.Services.AddDbContext<StatlyDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddHttpClient<FootballApiService>(client =>
{
    client.BaseAddress = new Uri("https://v3.football.api-sports.io/");
});


// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ======================
// PIPELINE HTTP
// ======================

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
