using SocialNetwork.Core.Application.ViewModels.Publicaciones;
using SocialNetwork.Core.Application.ViewModels.Usuarios;
using SocialNetwork.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Application.Interfaces.Services
{
    public interface IPublicacionesServices : IGenericServices<Publicaciones, PublicacionesViewModel, SavePublicacionesViewModel>
    {
        Task<List<PublicacionesViewModel>> GetAllAsyncWithInclude();
    }
}
