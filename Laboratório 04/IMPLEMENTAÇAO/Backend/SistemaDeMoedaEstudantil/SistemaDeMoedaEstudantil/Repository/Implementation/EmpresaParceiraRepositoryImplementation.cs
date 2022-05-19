using SistemaDeMoedaEstudantil.Model;
using SistemaDeMoedaEstudantil.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaDeMoedaEstudantil.Repository.Implementation
{
    public class EmpresaParceiraRepositoryImplementation : IEmpresaParceiraRepository
    {
        private SistemaMoedaEstudantilContext _context;

        public EmpresaParceiraRepositoryImplementation(SistemaMoedaEstudantilContext context)
        {
            _context = context;
        }

        public EmpresaParceira Create(EmpresaParceira empresaParceira)
        {
            try
            {
                _context.Add(empresaParceira);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return empresaParceira;
        }

        public void Delete(long id)
        {
            var result = _context.EmpresaParceira.SingleOrDefault(p => p.Id.Equals(id));

            if (result != null)
            {
                try
                {
                    _context.EmpresaParceira.Remove(result);
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
            return _context.EmpresaParceira.Any(p => p.Id.Equals(id));
        }

        public List<EmpresaParceira> FindAll()
        {
            return _context.EmpresaParceira.ToList();
        }

        public EmpresaParceira FindByID(long id)
        {
            return _context.EmpresaParceira.SingleOrDefault(p => p.Id.Equals(id));
        }

        public EmpresaParceira Update(EmpresaParceira empresaParceira)
        {
            if (!Exists(empresaParceira.Id)) return null;

            var result = _context.EmpresaParceira.SingleOrDefault(p => p.Id.Equals(empresaParceira.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(empresaParceira);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return empresaParceira;
        }
    }
}
