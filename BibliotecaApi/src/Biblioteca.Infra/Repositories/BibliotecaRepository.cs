using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Repositories;
using Microsoft.Data.SqlClient;

namespace Biblioteca.Infra.Repositories
{
    using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

public class BibliotecaRepository : IBibliotecaRepository
{
    private readonly string _connectionString;

    public BibliotecaRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("connectionString");
    }

    public void Adicionar(Livro biblioteca)
    {
        using (var conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            var cmd = new SqlCommand(
                "INSERT INTO Livros (NomeDoAutor, NomeDoLivro, NumeroDePaginas) VALUES (@NomeoDoAutor, @NomeDoLivro, @NumeroDePaginas)", conn);

            cmd.Parameters.AddWithValue("@NomeoDoAutor", biblioteca.NomeDoAutor);
            cmd.Parameters.AddWithValue("@NomeDoLivro", biblioteca.NomeDoLivro);
            cmd.Parameters.AddWithValue("@NumeroDePaginas", biblioteca.NumeroDePaginas);

            cmd.ExecuteNonQuery();
        }
    }

    public void Alterar(Livro biblioteca)
    {
        using (var conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            var cmd = new SqlCommand(
                @"UPDATE Livros 
                            SET NomeDoAutor=@NomeoDoAutor, NomeDoLivro=@NomeDoLivro, NumeroDePaginas=@NumeroDePaginas
                        WHERE Id=@Id", conn);

            cmd.Parameters.AddWithValue("@Id", biblioteca.Id);
            cmd.Parameters.AddWithValue("@NomeoDoAutor", biblioteca.NomeDoAutor);
            cmd.Parameters.AddWithValue("@NomeDoLivro", biblioteca.NomeDoLivro);
            cmd.Parameters.AddWithValue("@NumeroDePaginas", biblioteca.NumeroDePaginas);

            cmd.ExecuteNonQuery();
        }
    }

    public IEnumerable<Livro> ListarBibliotecas()
    {
        var lista = new List<Livro>();

        using (var conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            var cmd = new SqlCommand("SELECT Id, NomeDoAutor, NomeDoLivro, NumeroDePaginas FROM Livros", conn);

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    lista.Add(new Livro
                    {
                        Id = reader.GetInt32(0),
                        NomeDoAutor = reader.GetString(1),
                        NomeDoLivro = reader.GetString(2),
                        NumeroDePaginas = reader.GetInt32(3)
                    });
                }
            }
        }

        return lista;
    }

    public Livro ObterPorId(int id)
    {
        using (var conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            var cmd = new SqlCommand("SELECT Id, NomeDoAutor, NomeDoLivro, NumeroDePaginas FROM Livros WHERE Id=@Id", conn);
            cmd.Parameters.AddWithValue("@Id", id);

            using (var reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    return new Livro
                    {
                        Id = reader.GetInt32(0),
                        NomeDoAutor = reader.GetString(1),
                        NomeDoLivro = reader.GetString(2),
                        NumeroDePaginas = reader.GetInt32(3)
                    };
                }
            }
        }

        return null;
    }

    public void RemoverBiblioteca(Livro biblioteca)
    {
        using (var conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            var cmd = new SqlCommand("DELETE FROM Livros WHERE Id=@Id", conn);
            cmd.Parameters.AddWithValue("@Id", biblioteca.Id);

            cmd.ExecuteNonQuery();
        }
    }
}

}