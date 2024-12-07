using Microsoft.EntityFrameworkCore;
using Template.Infra;
using Template.Context;
using Template.Services;

var builder = WebApplication.CreateBuilder(args);

// Adiciona os serviços ao container
builder.Services.AddControllers();
builder.Services.AddHttpClient();

// Configura o Swagger
builder.Services.AddEndpointsApiExplorer(); // Explora os endpoints da API
builder.Services.AddSwaggerGen(); // Gera a documentação da API

// Configura o contexto do banco de dados SQLite
builder.Services.AddDbContext<AuditoriaContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Adiciona o serviço de Inventário ao container de dependências
builder.Services.AddScoped<AuditoriaService>();

// Configura CORS para permitir requisições de outras origens
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin() // Permite qualquer origem
              .AllowAnyMethod() // Permite qualquer método (GET, POST, etc.)
              .AllowAnyHeader(); // Permite qualquer cabeçalho
    });
});

// Configuração do GeradorDeServicos, se necessário
GeradorDeServicos.ServiceProvider = builder.Services.BuildServiceProvider();

var app = builder.Build();

// Configura o pipeline de requisições HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Gera a documentação do Swagger
    app.UseSwaggerUI(); // Interface visual do Swagger
}

// Adiciona o middleware de CORS
app.UseCors(); // Aplica a configuração de CORS antes de app.UseAuthorization()

app.UseHttpsRedirection(); // Redireciona para HTTPS (caso necessário)

app.UseAuthorization(); // Habilita a autorização para os endpoints (se necessário)

app.MapControllers(); // Mapeia os controladores da API

app.Run(); // Inicia a aplicação