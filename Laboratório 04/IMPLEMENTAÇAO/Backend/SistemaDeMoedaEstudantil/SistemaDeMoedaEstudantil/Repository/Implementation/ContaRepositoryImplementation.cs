using SistemaDeMoedaEstudantil.Model;
using SistemaDeMoedaEstudantil.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaDeMoedaEstudantil.Repository.Implementation
{
    public class ContaRepositoryImplementation : IContaRepository
    {
        private SistemaMoedaEstudantilContext _context;

        public ContaRepositoryImplementation(SistemaMoedaEstudantilContext context)
        {
            _context = context;
        }

        public Conta Create(Conta conta)
        {
            try
            {
                _context.Add(conta);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return conta;
        }

        public void Delete(long id)
        {
            var result = _context.Conta.SingleOrDefault(p => p.Id.Equals(id));

            if (result != null)
            {
                try
                {
                    _context.Conta.Remove(result);
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
            return _context.Conta.Any(p => p.Id.Equals(id));
        }

        public List<Conta> FindAll()
        {
            return _context.Conta.ToList();
        }

        public Conta FindByID(long id)
        {
            return _context.Conta.SingleOrDefault(p => p.Id.Equals(id));
        }

        public Conta Update(Conta conta)
        {
            if (!Exists(conta.Id)) return null;

            var result = _context.Conta.SingleOrDefault(p => p.Id.Equals(conta.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(conta);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return conta;
        }
    }
}
