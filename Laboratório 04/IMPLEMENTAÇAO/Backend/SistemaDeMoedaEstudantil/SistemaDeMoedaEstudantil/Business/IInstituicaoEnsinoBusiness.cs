using SistemaDeMoedaEstudantil.Model;
using System.Collections.Generic;

namespace SistemaDeMoedaEstudantil.Business
{
    public interface IInstituicaoEnsinoBusiness
    {
        InstituicaoEnsino Create(InstituicaoEnsino instituicaoEnsino);
        InstituicaoEnsino FindByID(long id);
        List<InstituicaoEnsino> FindAll();
        InstituicaoEnsino Update(InstituicaoEnsino instituicaoEnsino);
        void Delete(long id);
    }
}
