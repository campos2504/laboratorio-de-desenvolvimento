using SistemaDeMoedaEstudantil.Model;
using SistemaDeMoedaEstudantil.Repository;
using System;
using System.Collections.Generic;

namespace SistemaDeMoedaEstudantil.Business
{
    public class AlunoBusinessImplementation : IAlunoBusiness
    {
        private readonly IAlunoRepository _repository;
        private IContaBusiness _contaBusiness;

        public AlunoBusinessImplementation(IAlunoRepository repository, IContaBusiness conta)
        {
            _repository = repository;
            _contaBusiness = conta;
        }

        public Aluno Create(Aluno aluno)
        {
            //Criar uma conta para o aluno
            var conta = new Conta();
            conta.Saldo = 0;
            var novaConta = _contaBusiness.Create(conta);

            aluno.UserType = UserType.ALUNO;
            aluno.ContaId = novaConta.Id;

            return _repository.Create(aluno);
        }

        public void Delete(long id)
        {

            _repository.Delete(id);
        }

        public List<Aluno> FindAll()
        {

            return _repository.FindAll();
        }

        public Aluno FindByID(long id)
        {

            return _repository.FindByID(id);
        }

        public List<Aluno> GetAlunoIe(long ie)
        {
            return _repository.GetAlunoIe(ie);
        }

        public Aluno Update(Aluno aluno)
        {

            return _repository.Update(aluno);
        }
    }
}
