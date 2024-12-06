using Microsoft.Extensions.DependencyInjection;
using Template.Context;

namespace Template.Infra
{
    public static class GeradorDeServicos
    {
        // Provedor de serviços para injeção de dependências
        public static ServiceProvider ServiceProvider;

        // Método para carregar o contexto do aluguel
        public static AluguelContext CarregarContexto()
        {
            return ServiceProvider.GetService<AluguelContext>();
        }
    }
}
