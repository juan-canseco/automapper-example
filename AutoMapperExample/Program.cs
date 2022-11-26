using AutoMapperExample.Repository;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Configurando Auto Mapper
// Esta linea agrega AutoMapper a DI y registra todos los mappers que existan en el ensamblado en este caso todo lo que se encuentre en la carpeta mappers
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
// Agregando repository a DI
builder.Services.AddTransient<CategoryRepository>();
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
