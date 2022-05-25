using Microsoft.EntityFrameworkCore;
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

        public User FindByEmail(string email)
        {
            var user = _context.User.SingleOrDefault(p => p.Email.Equals(email));

            if(user.UserType == UserType.PROFESSOR)
            {
                Professor userProf = _context.Professor.SingleOrDefault(p => p.Email.Equals(email));

                Professor userByEmail = new Professor();
                userByEmail.Email = userProf.Email;
                userByEmail.Senha = userProf.Senha;
                userByEmail.UserType = userProf.UserType;
                userByEmail.Id = userProf.Id;
                userByEmail.ContaId = userProf.ContaId;
                userByEmail.InstituicaoEnsinoId = userProf.InstituicaoEnsinoId;

                return userByEmail;
            }

            if (user.UserType == UserType.EMPRESAPARCEIRA)
            {
                EmpresaParceira userEmpresa = _context.EmpresaParceira.SingleOrDefault(p => p.Email.Equals(email));

                EmpresaParceira userByEmail = new EmpresaParceira();
                userByEmail.Email = userEmpresa.Email;
                userByEmail.Senha = userEmpresa.Senha;
                userByEmail.UserType = userEmpresa.UserType;
                userByEmail.Id = userEmpresa.Id;               

                return userByEmail;
            }

            if (user.UserType == UserType.ALUNO)
            {
                Aluno userAluno = _context.Aluno.SingleOrDefault(p => p.Email.Equals(email));

                Aluno userByEmail = new Aluno();
                userByEmail.Email = userAluno.Email;
                userByEmail.Senha = userAluno.Senha;
                userByEmail.UserType = userAluno.UserType;
                userByEmail.Id = userAluno.Id;
                userByEmail.ContaId = userAluno.ContaId;

                return userByEmail;
            }

            return user;

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
