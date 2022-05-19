using SistemaDeMoedaEstudantil.Model;
using SistemaDeMoedaEstudantil.Repository;
using System;
using System.Collections.Generic;

namespace SistemaDeMoedaEstudantil.Business
{
    public class ContaBusinessImplementation : IContaBusiness
    {
        private readonly IContaRepository _repository;

        public ContaBusinessImplementation(IContaRepository repository)
        {
            _repository = repository;
        }

        public Conta Create(Conta conta)
        {
            return _repository.Create(conta);
        }

        public void Delete(long id)
        {

            _repository.Delete(id);
        }

        public List<Conta> FindAll()
        {

            return _repository.FindAll();
        }

        public Conta FindByID(long id)
        {

            return _repository.FindByID(id);
        }

        public Conta Update(Conta conta)
        {

            return _repository.Update(conta);
        }
    }
}
