using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Core.Application.Interfaces.Repositories;
using SocialNetwork.Core.Application.Interfaces.Services;
using SocialNetwork.Middlewares;

namespace SocialNetwork.Controllers.Comentarios
{
    public class ComentariosController : Controller
    {
        private readonly IComentariosServices _service;
        private ValidateUserSession _validateUserSession;

        public ComentariosController(IComentariosServices service, ValidateUserSession validateUserSession)
        {
            _service = service;
            _validateUserSession = validateUserSession;
        }

        //public async Task<IActionResult> Index()
        //{
        //    if(!_validateUserSession.HasUser())
        //    {
        //        return RedirectToRoute(new {Controller = "Usuarios", Action = "Login"});
        //    }
        //    return View(await _service.());
        //}
    }
}
