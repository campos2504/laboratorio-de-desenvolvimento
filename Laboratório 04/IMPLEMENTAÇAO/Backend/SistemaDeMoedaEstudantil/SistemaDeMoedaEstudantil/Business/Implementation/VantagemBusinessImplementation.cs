using AutoMapper;
using SistemaDeMoedaEstudantil.Model;
using SistemaDeMoedaEstudantil.Repository;
using SistemaDeMoedaEstudantil.ViewModel;
using System;
using System.Collections.Generic;

namespace SistemaDeMoedaEstudantil.Business
{
    public class VantagemBusinessImplementation : IVantagemBusiness
    {
        private readonly IVantagemRepository _repository;
        private readonly IMapper _mapper;

        public VantagemBusinessImplementation(IVantagemRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Vantagem Create(VantagemViewModel vantagemViewModel)
        {
            return _repository.Create(_mapper.Map<Vantagem>(vantagemViewModel));
        }

        public void Delete(long id)
        {

            _repository.Delete(id);
        }

        public List<Vantagem> FindAll()
        {

            return _repository.FindAll();
        }

        public Vantagem FindByID(long id)
        {

            return _repository.FindByID(id);
        }

        public Vantagem Update(VantagemViewModel vantagemViewModel)
        {

            return _repository.Update(_mapper.Map<Vantagem>(vantagemViewModel));
        }
    }
}
