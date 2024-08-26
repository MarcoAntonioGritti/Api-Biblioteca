using ApiBiblioteca.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<BibliotecaContext>
    (options => options.UseSqlServer
    ("Data Source=DESKTOP-65RMKMV\\SQLEXPRESS;Initial Catalog=Biblioteca;Integrated Security=True;Encrypt=False;Trust Server Certificate=True"));
builder.Services.AddControllers().AddNewtonsoftJson();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
