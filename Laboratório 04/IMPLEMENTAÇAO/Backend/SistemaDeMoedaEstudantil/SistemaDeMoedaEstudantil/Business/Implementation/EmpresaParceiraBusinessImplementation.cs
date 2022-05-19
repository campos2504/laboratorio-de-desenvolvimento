using SistemaDeMoedaEstudantil.Model;
using SistemaDeMoedaEstudantil.Repository;
using System;
using System.Collections.Generic;

namespace SistemaDeMoedaEstudantil.Business
{
    public class EmpresaParceiraBusinessImplementation : IEmpresaParceiraBusiness
    {
        private readonly IEmpresaParceiraRepository _repository;

        public EmpresaParceiraBusinessImplementation(IEmpresaParceiraRepository repository)
        {
            _repository = repository;
        }

        public EmpresaParceira Create(EmpresaParceira empresaParceira)
        {
            return _repository.Create(empresaParceira);
        }

        public void Delete(long id)
        {

            _repository.Delete(id);
        }

        public List<EmpresaParceira> FindAll()
        {

            return _repository.FindAll();
        }

        public EmpresaParceira FindByID(long id)
        {

            return _repository.FindByID(id);
        }

        public EmpresaParceira Update(EmpresaParceira empresaParceira)
        {

            return _repository.Update(empresaParceira);
        }
    }
}
