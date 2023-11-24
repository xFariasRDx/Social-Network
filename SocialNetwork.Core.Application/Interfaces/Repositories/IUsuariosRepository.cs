using SocialNetwork.Core.Application.ViewModels.Login;
using SocialNetwork.Core.Application.ViewModels.Usuarios;
using SocialNetwork.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Application.Interfaces.Repositories
{
    public interface IUsuariosRepository : IGenericRepository<Usuarios>
    { 
        Task<Usuarios> LoginAsync(LoginViewModel loginVm);
        Task<List<Usuarios>> GetAllAsyncWithInclude(List<string> properties);
        Task<Usuarios> GetByUserAsync(string usuario);
    }
}
