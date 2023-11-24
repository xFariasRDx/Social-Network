using SocialNetwork.Core.Application.ViewModels.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Application.Interfaces.Services
{
    public interface IGenericServices <Model, ViewModel, SaveViewModel>
        where Model : class
        where ViewModel : class
        where SaveViewModel : class
    {
        Task<List<ViewModel>> GetAllVM();
        Task<SaveViewModel> Add(SaveViewModel manda);
        Task Update(SaveViewModel trae, int id);
        Task Delete(int Id);
        Task<SaveViewModel> GetByIdSaveViewModels(int Id);

    }
}
