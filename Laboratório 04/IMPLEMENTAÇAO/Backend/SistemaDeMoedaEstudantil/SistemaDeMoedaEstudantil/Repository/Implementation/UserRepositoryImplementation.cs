using SistemaDeMoedaEstudantil.Model;
using SistemaDeMoedaEstudantil.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaDeMoedaEstudantil.Repository.Implementation
{
    public class UserRepositoryImplementation : IUserRepository
    {
        private SistemaMoedaEstudantilContext _context;

        public UserRepositoryImplementation(SistemaMoedaEstudantilContext context)
        {
            _context = context;
        }

        public User Create(User user)
        {
            try
            {
                _context.Add(user);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return user;
        }

        public void Delete(long id)
        {
            var result = _context.User.SingleOrDefault(p => p.Id.Equals(id));

            if (result != null)
            {
                try
                {
                    _context.User.Remove(result);
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
            return _context.User.Any(p => p.Id.Equals(id));
        }

        public List<User> FindAll()
        {
            return _context.User.ToList();
        }

        public User FindByID(long id)
        {
            return _context.User.SingleOrDefault(p => p.Id.Equals(id));
        }

        public User Update(User user)
        {
            if (!Exists(user.Id)) return null;

            var result = _context.User.SingleOrDefault(p => p.Id.Equals(user.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(user);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return user;
        }
    }
}
