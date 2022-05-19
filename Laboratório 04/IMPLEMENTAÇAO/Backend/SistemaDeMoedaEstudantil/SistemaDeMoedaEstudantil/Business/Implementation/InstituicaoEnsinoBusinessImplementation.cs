using SistemaDeMoedaEstudantil.Model;
using SistemaDeMoedaEstudantil.Repository;
using System;
using System.Collections.Generic;

namespace SistemaDeMoedaEstudantil.Business
{
    public class InstituicaoEnsinoBusinessImplementation : IInstituicaoEnsinoBusiness
    {
        private readonly IInstituicaoEnsinoRepository _repository;

        public InstituicaoEnsinoBusinessImplementation(IInstituicaoEnsinoRepository repository)
        {
            _repository = repository;
        }

        public InstituicaoEnsino Create(InstituicaoEnsino instituicaoEnsino)
        {
            return _repository.Create(instituicaoEnsino);
        }

        public void Delete(long id)
        {

            _repository.Delete(id);
        }

        public List<InstituicaoEnsino> FindAll()
        {

            return _repository.FindAll();
        }

        public InstituicaoEnsino FindByID(long id)
        {

            return _repository.FindByID(id);
        }

        public InstituicaoEnsino Update(InstituicaoEnsino instituicaoEnsino)
        {

            return _repository.Update(instituicaoEnsino);
        }
    }
}
