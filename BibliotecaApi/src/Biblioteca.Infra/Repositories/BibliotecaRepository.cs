using System;
using System.Collections.Generic;
using System.Linq;
using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Repositories;
using Biblioteca.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Infra.Repositories
{
    public class BibliotecaRepository :IBibliotecaRepository
    {
        private readonly BibliotecaContext _context;


        public BibliotecaRepository(BibliotecaContext context)
        {
            _context = context;
        }

        public void Adicionar(Livro biblioteca)
        {
            _context.Add(biblioteca);
            _context.SaveChanges();
        }

        public void Alterar(Livro biblioteca)
        {
            _context.Entry(biblioteca).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public IEnumerable<Livro> ListarBibliotecas()
        {
            return _context.Bibliotecas.ToList();
        }

        public Livro ObterPorId(int id)
        {
            try
            {
                return _context.Bibliotecas.FirstOrDefault(x => x.Id == id);
            }
            catch (System.Exception ex)
            {
                
                throw new ArgumentException("Erro ao obter livro");
            }
        }
        public void RemoverBiblioteca(Livro biblioteca)
        {
            _context.Remove(biblioteca);
            _context.SaveChanges();
        }
    }
}