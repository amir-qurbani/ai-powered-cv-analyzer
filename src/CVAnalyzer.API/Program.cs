using CVAnalyzer.Core.Interfaces;
using CVAnalyzer.Infrastructure.Repositories;
using CVAnalyzer.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using CVAnalyzer.Application.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<ICvRepository, CvRepository>();
builder.Services.AddScoped<CvService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
