using Microsoft.EntityFrameworkCore;
using backend.Data;
using backend.Services.Interfaces;
using backend.Services;


var builder = WebApplication.CreateBuilder(args);

// Ativa Controllers e Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddDbContext<ClinicaContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    )
);

builder.Services.AddScoped<PacienteService>();
builder.Services.AddScoped<ConsultaService>();

// 👈 Registramos o serviço ResponsavelLegalService como a implementação da interface IResponsavelLegalService
// Por que fizemos isso?
// Para que o sistema saiba que sempre que alguém pedir IResponsavelLegalService, o ASP.NET Core deve entregar uma instância de ResponsavelLegalService.
builder.Services.AddScoped<IResponsavelLegalService, ResponsavelLegalService>();
builder.Services.AddScoped<IPsiquiatraService, PsiquiatraService>();
builder.Services.AddScoped<IMedicamentoService, MedicamentoService>();
builder.Services.AddScoped<IPacienteMedicamentoService, PacienteMedicamentoService>();
builder.Services.AddScoped<ITarefaService, TarefaService>();
builder.Services.AddScoped<IPsicologoService, PsicologoService>();



var app = builder.Build();

// Ativa Swagger em ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthorization();
app.MapControllers();

app.Run();
