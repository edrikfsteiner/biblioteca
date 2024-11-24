using Microsoft.Extensions.DependencyInjection;
using Template.Context;

namespace MicroserviceLivro.Infra
{
    public static class GeradorDeServicos
    {
        // Provedor de serviços para injeção de dependências
        public static ServiceProvider ServiceProvider;

        // Método para carregar o contexto do livro
        public static LivroContext CarregarContexto()
        {
            return ServiceProvider.GetService<LivroContext>();
        }
    }
}
