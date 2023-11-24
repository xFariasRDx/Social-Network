using SocialNetwork.Core.Application.ViewModels.Comentarios;
using SocialNetwork.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Application.Interfaces.Services
{
    public interface IComentariosServices : IGenericServices<Comentarios, ComentariosViewModel, SaveComentariosViewModel>
    {
    }
}
