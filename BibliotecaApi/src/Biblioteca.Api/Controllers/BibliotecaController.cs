using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaApi.Controllers;

[ApiController]
[Route("[controller]")]
public class BibliotecaController : ControllerBase
{
    private readonly IBibliotecaRepository _repositorio;

    public BibliotecaController(IBibliotecaRepository repositorio)
    {
        _repositorio = repositorio;
    }

    [HttpGet("{id:int}")]
    public IActionResult ObterBiblioteca(int id)
    {
        var livro = _repositorio.ObterPorId(id);
        return livro is null ? NotFound() : Ok(livro);
    }

    [HttpGet]
    public IActionResult ObterBiblioteca()
    {
        return Ok(_repositorio.ListarBibliotecas());
    }

    [HttpPost]
    public IActionResult AdicionarLivro([FromBody] Livro livro)
    {
        if (!ModelState.IsValid)
        {
            return ValidationProblem(ModelState);
        }

        _repositorio.Adicionar(livro);
        return Ok();
    }

    [HttpPut("{id:int}")]
    public IActionResult AlterarLivro(int id, [FromBody] Livro livro)
    {
        if (!ModelState.IsValid)
        {
            return ValidationProblem(ModelState);
        }

        var livroExistente = _repositorio.ObterPorId(id);
        if (livroExistente is null)
        {
            return NotFound();
        }

        livroExistente.NomeDoLivro = livro.NomeDoLivro;
        livroExistente.NomeDoAutor = livro.NomeDoAutor;
        livroExistente.NumeroDePaginas = livro.NumeroDePaginas;
        livroExistente.Id = id;

        _repositorio.Alterar(livroExistente);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult ExcluirLivro(int id)
    {
        var livro = _repositorio.ObterPorId(id);
        if (livro is null)
        {
            return NotFound();
        }

        _repositorio.RemoverBiblioteca(livro);
        return NoContent();
    }
}
