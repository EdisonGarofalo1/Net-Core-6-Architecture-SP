using CARRITO.Appication.Interface;
using CARRITO.Appication.Service;
using CARRITO.Infrastructure.Data;
using CARRITO.Infrastructure.Interface;
using CARRITO.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ConnectionService>();

builder.Services.AddSingleton<ICategoriaService, CategoriaService>();
builder.Services.AddSingleton<ICategoriaRepository, CategoriaRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
