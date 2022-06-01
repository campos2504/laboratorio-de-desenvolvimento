using Microsoft.EntityFrameworkCore;
using SistemaDeMoedaEstudantil.Model;
using SistemaDeMoedaEstudantil.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaDeMoedaEstudantil.Repository.Implementation
{
    public class VantagemUserRepositoryImplementation : IVantagemUserRepository
    {
        private SistemaMoedaEstudantilContext _context;

        public VantagemUserRepositoryImplementation(SistemaMoedaEstudantilContext context)
        {
            _context = context;
        }

        public VantagemUser Create(VantagemUser vantagemUser)
        {
            try
            {
                _context.Add(vantagemUser);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return vantagemUser;
        }

        public void Delete(long id)
        {
            var result = _context.VantagemUser.SingleOrDefault(p => p.Id.Equals(id));

            if (result != null)
            {
                try
                {
                    _context.VantagemUser.Remove(result);
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
            return _context.VantagemUser.Any(p => p.Id.Equals(id));
        }

        public List<VantagemUser> FindAll()
        {
            return _context.VantagemUser.Include(p => p.Aluno).Include(p => p.Vantagem).ToList();
        }

        public VantagemUser FindByID(long id)
        {
            return _context.VantagemUser.Include(p => p.Aluno).Include(p => p.Vantagem).SingleOrDefault(p => p.Id.Equals(id));
        }

        public VantagemUser Update(VantagemUser vantagemUser)
        {
            if (!Exists(vantagemUser.Id)) return null;

            var result = _context.VantagemUser.SingleOrDefault(p => p.Id.Equals(vantagemUser.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(vantagemUser);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return vantagemUser;
        }
    }
}
