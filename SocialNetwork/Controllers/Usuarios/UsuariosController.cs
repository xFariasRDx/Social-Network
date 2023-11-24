using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Core.Application.Helpers;
using SocialNetwork.Core.Application.Interfaces.Services;
using SocialNetwork.Core.Application.ViewModels.Login;
using SocialNetwork.Core.Application.ViewModels.Usuarios;
using SocialNetwork.Middlewares;
using Microsoft.AspNetCore.Identity;

namespace SocialNetwork.Controllers.Usuarios
{
    public class UsuariosController : Controller
    {
        private readonly IUsuariosServices _usuarioService;
        private readonly ValidateUserSession _validateUserSession;

        public UsuariosController(IUsuariosServices usuarioService, ValidateUserSession validateUserSession)
        {
            _usuarioService = usuarioService;
            _validateUserSession = validateUserSession;
        }

        public async Task<IActionResult> Index()
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { Controller = "Usuarios", Action = "Login" });
            }
            return View(await _usuarioService.GetAllAsyncWithInclude());
        }

        public IActionResult Create()
        {
            return View(new SaveUsuariosViewModel());
        }


        [HttpPost]
        public async Task<IActionResult> Create(SaveUsuariosViewModel suvm)
        {
            
            if (!ModelState.IsValid)
            {
                return View(suvm);
            }

            if (_usuarioService.ConfirmExist(suvm.Usuario).Result)
            {
                return View(new SaveUsuariosViewModel { Existing = "Este usuario ya existe"});
            }

            SaveUsuariosViewModel ssuvm = await _usuarioService.Add(suvm);
            
            if(ssuvm.Id != 0 && ssuvm != null)
            {
                ssuvm.Img_Profile = UploadFile(suvm.Img_Upload, ssuvm.Id);
                await _usuarioService.Update(ssuvm, ssuvm.Id);
            }

            return RedirectToRoute(new { Controller = "Usuarios", Action = "Login" });
          
        }

        public IActionResult Login()
        {
            if (_validateUserSession.HasUser())
            {
              return RedirectToRoute(new { Controller = "Publicaciones", Action = "Index" });
            }
            return View();
        }


        public async Task<IActionResult> Verificacion(int Id)
        {
            SaveUsuariosViewModel viewModel= await _usuarioService.GetByIdSaveViewModels(Id);
            viewModel.Verificado = true;

            await _usuarioService.Update(viewModel, Id);
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginVm)
        {
            if (_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { Controller = "Publicaciones", Action = "Index" });
            }
            if (!ModelState.IsValid)
            {
                return View(loginVm);
            }
            UsuariosViewModel userVm = await _usuarioService.Login(loginVm);

            if (userVm != null)
            {
                if(!userVm.Verificado)
                {
                    ModelState.AddModelError("ConfirmEmail", "Debe validar cuenta en el correo");
                    return View(loginVm);
                }


                HttpContext.Session.Set<UsuariosViewModel>("Usuarios", userVm);
                return RedirectToRoute(new { Controller = "Publicaciones", Action = "Index" });
            }
            else
            {
                ModelState.AddModelError("userValidation", "Datos de acceso incorrectos");
            }
            return View(loginVm);
        }


        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("Usuarios");
            return RedirectToRoute(new { Controller = "Usuarios", Action = "Login" });
        }
        
        public async Task<IActionResult> ForgetPassword(string Usuario)
        {
            if (_usuarioService.ConfirmExist(Usuario).Result)
            {
                await _usuarioService.restorePassword(Usuario);
                return View("Login");
            }
            return View();
        }


        private string UploadFile(IFormFile file, int id)
        {
            //GET DIRECTORY PATH
            string basePath = $"/Images/Usuarios/{id}";
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{basePath}");

            //CREATE FOLDER IF NOT EXIST
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            //GET FILE PATH
            Guid guid = Guid.NewGuid();
            FileInfo fileInfo = new(file.FileName);
            string filename = guid + fileInfo.Extension;

            string filenameWithPath = Path.Combine(path, filename);

            using (var stream = new FileStream(filenameWithPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return Path.Combine(basePath, filename);
        }
    }
}
