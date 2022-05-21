using SistemaDeMoedaEstudantil.Model;
using System.Collections.Generic;

namespace SistemaDeMoedaEstudantil.Repository
{
    public interface IVantagemRepository
    {
        Vantagem Create(Vantagem vantagem);
        Vantagem FindByID(long id);
        List<Vantagem> FindAll();
        Vantagem Update(Vantagem vantagem);
        void Delete(long id);
        bool Exists(long id);
    }
}
