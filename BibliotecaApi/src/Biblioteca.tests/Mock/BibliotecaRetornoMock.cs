using Biblioteca.Domain.Entities;

namespace Biblioteca.tests.Mock
{
    public static class BibliotecaRetornoMock
    {
        public static IEnumerable<Livro> ListarBibliotecaMock()
        {
            return new List<Livro>()
            {
                new Livro()
                {
                    Id = 1,
                    NomeDoAutor = "Teste01",
                    NomeDoLivro = "Testando02",
                    NumeroDePaginas = 350
                }
            };
        }
    }
}
