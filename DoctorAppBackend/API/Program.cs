using API.Extensiones;
using API.Middleware;
using Data.Inicializador;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AgregarServiciosAplicacion(builder.Configuration);
builder.Services.AgregarServiciosIdentidad(builder.Configuration);

builder.Services.AddScoped<IdbInicializador, DbInicializador>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseMiddleware<ExceptionMiddleware>();
app.UseStatusCodePagesWithReExecute("/errores/{0}");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod());
app.UseAuthentication();
app.UseAuthorization();


using(var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var loggerFactory = services.GetRequiredService<ILoggerFactory>();
	try
	{
		var inicializador = services.GetRequiredService<IdbInicializador>();
		inicializador.Inicializar();
	}
	catch (Exception ex)
	{

		var logger = loggerFactory.CreateLogger<Program>();
		logger.LogError(ex, "Un Error ocurrio al ejecutar la migracion");
	}
}

app.MapControllers();

app.Run();
