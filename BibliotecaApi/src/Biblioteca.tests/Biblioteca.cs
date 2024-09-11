using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Repositories;
using Biblioteca.tests.Mock;
using BibliotecaApi.Controllers;
using Moq;
using System.Collections.Generic;

namespace Biblioteca.tests
{
    public class Biblioteca
    {
        BibliotecaController _bibliotecaController;
        Mock<IBibliotecaRepository> _bibliotecaRepositoryMock;

        public Biblioteca()
        {
            _bibliotecaRepositoryMock = new Mock<IBibliotecaRepository>();
            _bibliotecaController = new BibliotecaController(_bibliotecaRepositoryMock.Object);

        }

        [Fact(DisplayName = "Retornar Objeto Preenchido")]
        public void Retornar_Objeto_Preenchido()
        {
            _bibliotecaRepositoryMock.Setup(x => x.ListarBibliotecas()).Returns(BibliotecaRetornoMock.ListarBibliotecaMock());

            var livros = _bibliotecaController.ObterBiblioteca();

            Assert.NotNull(livros);
        }
    }
}