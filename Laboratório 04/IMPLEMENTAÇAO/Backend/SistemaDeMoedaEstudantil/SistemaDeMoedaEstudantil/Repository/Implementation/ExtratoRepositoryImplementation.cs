using Microsoft.EntityFrameworkCore;
using SistemaDeMoedaEstudantil.Model;
using SistemaDeMoedaEstudantil.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaDeMoedaEstudantil.Repository.Implementation
{
    public class ExtratoRepositoryImplementation : IExtratoRepository
    {
        private SistemaMoedaEstudantilContext _context;

        public ExtratoRepositoryImplementation(SistemaMoedaEstudantilContext context)
        {
            _context = context;
        }

        public Extrato Create(Extrato extrato)
        {
            try
            {
                _context.Add(extrato);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return extrato;
        }

        public void Delete(long id)
        {
            var result = _context.Extrato.SingleOrDefault(p => p.Id.Equals(id));

            if (result != null)
            {
                try
                {
                    _context.Extrato.Remove(result);
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
            return _context.Extrato.Any(p => p.Id.Equals(id));
        }

        public List<Extrato> FindAll()
        {
            return _context.Extrato.Include(p => p.Conta).ToList();
        }

        public Extrato FindByID(long id)
        {
            return _context.Extrato.SingleOrDefault(p => p.Id.Equals(id));
        }

        public List<Extrato> GetExtratoConta(long id)
        {
            return _context.Extrato.Where(p => p.ContaId.Equals(id)).Include(p => p.Conta).ToList();
        }

        public Extrato Update(Extrato extrato)
        {
            if (!Exists(extrato.Id)) return null;

            var result = _context.Extrato.SingleOrDefault(p => p.Id.Equals(extrato.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(extrato);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return extrato;
        }
    }
}
