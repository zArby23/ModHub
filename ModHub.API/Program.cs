using Microsoft.EntityFrameworkCore;
using ModHub.API.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();


//Inyecciones de dependencias

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(x=>x.UseSqlServer("name=DefaultConnection"));



var app = builder.Build();

//Midlewares

app.UseSwagger();
app.UseSwaggerUI();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
