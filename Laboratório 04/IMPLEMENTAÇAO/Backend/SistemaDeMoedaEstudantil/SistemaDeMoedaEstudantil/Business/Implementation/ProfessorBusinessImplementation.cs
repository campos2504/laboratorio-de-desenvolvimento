using SistemaDeMoedaEstudantil.Model;
using SistemaDeMoedaEstudantil.Repository;
using System;
using System.Collections.Generic;

namespace SistemaDeMoedaEstudantil.Business
{
    public class ProfessorBusinessImplementation : IProfessorBusiness
    {
        private readonly IProfessorRepository _repository;
        private IContaBusiness _contaBusiness;

        public ProfessorBusinessImplementation(IProfessorRepository repository, IContaBusiness conta)
        {
            _repository = repository;
            _contaBusiness = conta;
        }

        public Professor Create(Professor professor)
        {
            //Criar uma conta para o aluno
            var conta = new Conta();
            conta.Saldo = 1000;
            var novaConta = _contaBusiness.Create(conta);

            professor.UserType = UserType.PROFESSOR;
            professor.ContaId = novaConta.Id;

            return _repository.Create(professor);
        }

        public void Delete(long id)
        {

            _repository.Delete(id);
        }

        public List<Professor> FindAll()
        {

            return _repository.FindAll();
        }

        public Professor FindByID(long id)
        {

            return _repository.FindByID(id);
        }

        public Professor Update(Professor professor)
        {

            return _repository.Update(professor);
        }
    }
}
