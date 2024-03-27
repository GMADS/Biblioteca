using System.Collections.Generic;
using Biblioteca.Domain.Entities;

namespace Biblioteca.Domain.Repositories
{
    public interface IBibliotecaRepository
    {
        //Métodos que nossa class terá que implementar.
        void Adicionar(Livro biblioteca);
        void Alterar(Livro biblioteca);
        IEnumerable<Livro> ListarBibliotecas();
        Livro ObterPorId(int id);
        void RemoverBiblioteca(Livro biblioteca);
    }
}