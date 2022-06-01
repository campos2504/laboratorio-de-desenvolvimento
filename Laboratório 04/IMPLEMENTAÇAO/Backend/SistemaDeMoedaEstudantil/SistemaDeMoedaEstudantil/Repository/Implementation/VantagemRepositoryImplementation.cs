using Microsoft.EntityFrameworkCore;
using SistemaDeMoedaEstudantil.Model;
using SistemaDeMoedaEstudantil.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaDeMoedaEstudantil.Repository.Implementation
{
    public class VantagemRepositoryImplementation : IVantagemRepository
    {
        private SistemaMoedaEstudantilContext _context;

        public VantagemRepositoryImplementation(SistemaMoedaEstudantilContext context)
        {
            _context = context;
        }

        public Vantagem Create(Vantagem vantagem)
        {
            try
            {
                _context.Add(vantagem);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return vantagem;
        }

        public void Delete(long id)
        {
            var result = _context.Vantagem.SingleOrDefault(p => p.Id.Equals(id));

            if (result != null)
            {
                try
                {
                    _context.Vantagem.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public bool Exists(long id)
        {
            return _context.Vantagem.Any(p => p.Id.Equals(id));
        }

        public List<Vantagem> FindAll()
        {
            return _context.Vantagem.ToList();

        }

        public Vantagem FindByID(long id)
        {
            return _context.Vantagem.SingleOrDefault(p => p.Id.Equals(id));
        }

        public Vantagem Update(Vantagem vantagem)
        {
            if (!Exists(vantagem.Id)) return null;

            var result = _context.Vantagem.SingleOrDefault(p => p.Id.Equals(vantagem.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(vantagem);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return vantagem;
        }
    }
}
