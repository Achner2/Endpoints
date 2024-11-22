using API.Configuration.MappingProfile;
using API.Dto.Request;
using API.Dto.Response;
using WebApplication2.Models.DB;
using WebApplication2.Services;
using WebApplication2.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Registrar servicios antes de construir la aplicación
builder.Services.AddControllers();

// Configurar Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Registro de base de datos
builder.Services.AddScoped<BaseDatos>();

// Registrar la interfaz y el servicio
builder.Services.AddScoped<ICrudService<UserRequest, UserResponse>, UserService>();

// Registrar el mapeo de DTO
builder.Services.AddAutoMapper(typeof(UserProfile)); // Especificar el tipo del perfil

var app = builder.Build();

// Configurar el pipeline de solicitudes HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

