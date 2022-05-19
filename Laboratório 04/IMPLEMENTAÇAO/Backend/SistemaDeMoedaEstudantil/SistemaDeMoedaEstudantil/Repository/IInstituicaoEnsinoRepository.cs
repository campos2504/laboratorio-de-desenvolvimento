using SistemaDeMoedaEstudantil.Model;
using System.Collections.Generic;

namespace SistemaDeMoedaEstudantil.Repository
{
    public interface IInstituicaoEnsinoRepository
    {
        InstituicaoEnsino Create(InstituicaoEnsino instituicaoEnsino);
        InstituicaoEnsino FindByID(long id);
        List<InstituicaoEnsino> FindAll();
        InstituicaoEnsino Update(InstituicaoEnsino instituicaoEnsino);
        void Delete(long id);
        bool Exists(long id);
    }
}
