using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Core.Application.Interfaces.Repositories;
using SocialNetwork.Core.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Application.Services
{
    public class GenericService <Model, ViewModel, SaveViewModel>  : IGenericServices <Model, ViewModel, SaveViewModel>
        where Model : class
        where ViewModel : class
        where SaveViewModel : class
    {

        private readonly IGenericRepository<Model> _repository;
        private readonly IMapper _mapper;

        public GenericService(IGenericRepository<Model> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //-----------------Metodo para Extraer----------------//
        public virtual async Task<List<ViewModel>> GetAllVM()
        {
            var modelList = await _repository.GetAllAsync();
            
            return _mapper.Map<List<ViewModel>>(modelList);
        }

        //-----------------Metodo para Agregar----------------//

        public virtual async Task<SaveViewModel> Add(SaveViewModel manda)
        {
            Model entity = _mapper.Map<Model>(manda);

            entity = await _repository.AddAsync(entity);

            SaveViewModel saveVm = _mapper.Map<SaveViewModel>(entity);

            return saveVm;

        }


        //-----------------Metodo para Actualizar----------------//

        public virtual async Task Update(SaveViewModel trae, int id)
        {
            Model entity = _mapper.Map<Model>(trae);

            await _repository.UpdateAsync(entity, id);
        }

        //-----------------Metodo para Eliminar----------------//

        public virtual async Task Delete(int Id)
        {
            Model entity = await _repository.GetByIdAsync(Id);

            await _repository.DeleteAsync(entity);
        }

        //-----------------Metodo para Extraer by ID-------------------//

        public virtual async Task<SaveViewModel> GetByIdSaveViewModels(int Id)
        {
            Model entity = await _repository.GetByIdAsync(Id);

            SaveViewModel svm = _mapper.Map<SaveViewModel>(entity);

            return svm;
        }

    }
}
