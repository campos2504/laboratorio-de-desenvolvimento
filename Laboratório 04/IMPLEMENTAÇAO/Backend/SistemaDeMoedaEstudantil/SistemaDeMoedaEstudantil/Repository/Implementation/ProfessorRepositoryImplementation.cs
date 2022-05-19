using Microsoft.EntityFrameworkCore;
using SistemaDeMoedaEstudantil.Model;
using SistemaDeMoedaEstudantil.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaDeMoedaEstudantil.Repository.Implementation
{
    public class ProfessorRepositoryImplementation : IProfessorRepository
    {
        private SistemaMoedaEstudantilContext _context;

        public ProfessorRepositoryImplementation(SistemaMoedaEstudantilContext context)
        {
            _context = context;
        }

        public Professor Create(Professor professor)
        {
            try
            {
                _context.Add(professor);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return professor;
        }

        public void Delete(long id)
        {
            var result = _context.Professor.SingleOrDefault(p => p.Id.Equals(id));

            if (result != null)
            {
                try
                {
                    _context.Professor.Remove(result);
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
            return _context.Professor.Any(p => p.Id.Equals(id));
        }

        public List<Professor> FindAll()
        {
            return _context.Professor.Include(p => p.Conta).Include(p => p.InstituicaoEnsino).ToList();
        }

        public Professor FindByID(long id)
        {
            return _context.Professor.SingleOrDefault(p => p.Id.Equals(id));
        }

        public Professor Update(Professor professor)
        {
            if (!Exists(professor.Id)) return null;

            var result = _context.Professor.SingleOrDefault(p => p.Id.Equals(professor.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(professor);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return professor;
        }
    }
}
