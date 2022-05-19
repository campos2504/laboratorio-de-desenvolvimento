using SistemaDeMoedaEstudantil.Model;
using SistemaDeMoedaEstudantil.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaDeMoedaEstudantil.Repository.Implementation
{
    public class InstituicaoEnsinoRepositoryImplementation : IInstituicaoEnsinoRepository
    {
        private SistemaMoedaEstudantilContext _context;

        public InstituicaoEnsinoRepositoryImplementation(SistemaMoedaEstudantilContext context)
        {
            _context = context;
        }

        public InstituicaoEnsino Create(InstituicaoEnsino instituicaoEnsino)
        {
            try
            {
                _context.Add(instituicaoEnsino);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return instituicaoEnsino;
        }

        public void Delete(long id)
        {
            var result = _context.InstituicaoEnsino.SingleOrDefault(p => p.Id.Equals(id));

            if (result != null)
            {
                try
                {
                    _context.InstituicaoEnsino.Remove(result);
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
            return _context.InstituicaoEnsino.Any(p => p.Id.Equals(id));
        }

        public List<InstituicaoEnsino> FindAll()
        {
            return _context.InstituicaoEnsino.ToList();
        }

        public InstituicaoEnsino FindByID(long id)
        {
            return _context.InstituicaoEnsino.SingleOrDefault(p => p.Id.Equals(id));
        }

        public InstituicaoEnsino Update(InstituicaoEnsino instituicaoEnsino)
        {
            if (!Exists(instituicaoEnsino.Id)) return null;

            var result = _context.InstituicaoEnsino.SingleOrDefault(p => p.Id.Equals(instituicaoEnsino.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(instituicaoEnsino);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return instituicaoEnsino;
        }
    }
}
