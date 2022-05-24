using SistemaDeMoedaEstudantil.Model;
using SistemaDeMoedaEstudantil.Repository;
using System;
using System.Collections.Generic;

namespace SistemaDeMoedaEstudantil.Business
{
    public class UserBusinessImplementation : IUserBusiness
    {
        private readonly IUserRepository _repository;

        public UserBusinessImplementation(IUserRepository repository)
        {
            _repository = repository;
        }

        public User Create(User user)
        {
            return _repository.Create(user);
        }

        public void Delete(long id)
        {

            _repository.Delete(id);
        }

        public List<User> FindAll()
        {

            return _repository.FindAll();
        }

        public User FindByID(long id)
        {

            return _repository.FindByID(id);
        }

        public User FindByEmail(string email)
        {

            return _repository.FindByEmail(email);
        }

        public User Update(User user)
        {

            return _repository.Update(user);
        }
    }
}
