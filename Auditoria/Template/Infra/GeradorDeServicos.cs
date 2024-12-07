using Microsoft.Extensions.DependencyInjection;
using Template.Context;

namespace Template.Infra
{
    public static class GeradorDeServicos
    {
        // Provedor de serviços para injeção de dependências
        public static ServiceProvider ServiceProvider;

        // Método para carregar o contexto de auditoria
        public static AuditoriaContext CarregarContexto()
        {
            return ServiceProvider.GetService<AuditoriaContext>();
        }
    }
}
