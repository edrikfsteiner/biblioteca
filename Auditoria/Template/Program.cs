using Microsoft.EntityFrameworkCore;
using Template.Infra;
using Template.Context;
using Template.Services;

var builder = WebApplication.CreateBuilder(args);

// Adiciona os servi�os ao container
builder.Services.AddControllers();
builder.Services.AddHttpClient();

// Configura o Swagger
builder.Services.AddEndpointsApiExplorer(); // Explora os endpoints da API
builder.Services.AddSwaggerGen(); // Gera a documenta��o da API

// Configura o contexto do banco de dados SQLite
builder.Services.AddDbContext<AuditoriaContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Adiciona o servi�o de Invent�rio ao container de depend�ncias
builder.Services.AddScoped<AuditoriaService>();

// Configura CORS para permitir requisi��es de outras origens
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin() // Permite qualquer origem
              .AllowAnyMethod() // Permite qualquer m�todo (GET, POST, etc.)
              .AllowAnyHeader(); // Permite qualquer cabe�alho
    });
});

// Configura��o do GeradorDeServicos, se necess�rio
GeradorDeServicos.ServiceProvider = builder.Services.BuildServiceProvider();

var app = builder.Build();

// Configura o pipeline de requisi��es HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Gera a documenta��o do Swagger
    app.UseSwaggerUI(); // Interface visual do Swagger
}

// Adiciona o middleware de CORS
app.UseCors(); // Aplica a configura��o de CORS antes de app.UseAuthorization()

app.UseHttpsRedirection(); // Redireciona para HTTPS (caso necess�rio)

app.UseAuthorization(); // Habilita a autoriza��o para os endpoints (se necess�rio)

app.MapControllers(); // Mapeia os controladores da API

app.Run(); // Inicia a aplica��o