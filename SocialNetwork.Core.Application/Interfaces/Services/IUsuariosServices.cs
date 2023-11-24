using SocialNetwork.Core.Application.ViewModels.Login;
using SocialNetwork.Core.Application.ViewModels.Usuarios;
using SocialNetwork.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SocialNetwork.Core.Application.Interfaces.Services
{
    public interface IUsuariosServices : IGenericServices<Usuarios, UsuariosViewModel, SaveUsuariosViewModel>
    {
        Task<UsuariosViewModel> Login(LoginViewModel trae);
        Task<List<UsuariosViewModel>> GetAllAsyncWithInclude();
        Task<bool> ConfirmExist(string username);
        Task restorePassword(string usuario);

    }
}
