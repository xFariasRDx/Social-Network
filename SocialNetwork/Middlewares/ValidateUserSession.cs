using SocialNetwork.Core.Application.ViewModels.Usuarios;
using SocialNetwork.Core.Application.Helpers;
using SocialNetwork.Core.Application.ViewModels.Login;
using Microsoft.AspNetCore.Http;

namespace SocialNetwork.Middlewares
{
    public class ValidateUserSession
    {
        private readonly IHttpContextAccessor _httpcontextAccessor;

        public ValidateUserSession(IHttpContextAccessor httpcontextAccessor)
        {
            _httpcontextAccessor = httpcontextAccessor;
        }
    
        public bool HasUser()
        {
            UsuariosViewModel usuarioViewModel = _httpcontextAccessor.HttpContext.Session.Get<UsuariosViewModel>("Usuarios");
            if (usuarioViewModel == null)
            {
                return false;
            }
            return true;
        }

    }
}
