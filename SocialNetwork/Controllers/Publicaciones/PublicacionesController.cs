using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Middlewares;
using SocialNetwork.Core.Application.Interfaces.Services;
using SocialNetwork.Core.Application.ViewModels.Publicaciones;
using SocialNetwork.Core.Application.ViewModels.Login;
using SocialNetwork.Core.Application.ViewModels.Usuarios;
using System.Collections.Generic;

namespace SocialNetwork.Controllers.Publicaciones
{
    public class PublicacionesController : Controller
    {

        private readonly IPublicacionesServices _service;
        private readonly ValidateUserSession _validateUserSession;

        public PublicacionesController(IPublicacionesServices service, ValidateUserSession validateUserSession)
        {
            _service = service;
            _validateUserSession = validateUserSession;
        }

        public async Task<IActionResult> Index()
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { Controller = "Usuarios", Action = "Login" });
            }
            return View(await _service.GetAllAsyncWithInclude());
        }
        [HttpPost]
        public async Task<IActionResult> Index(SavePublicacionesViewModel spvm)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { Controller = "Usuarios", Action = "Login" });
            }

            if (!ModelState.IsValid)
            {
                return View(spvm);
            }

            SavePublicacionesViewModel sspvm = await _service.Add(spvm);

            if (sspvm.Id != 0 && sspvm != null)
            {
                sspvm.Picture_Caption = UploadFile(spvm.Img_Upload, sspvm.Id);
                await _service.Update(sspvm, sspvm.Id);
            }

            return RedirectToRoute(new { Controller = "Publicaciones", Action = "Index" });
        }

        public async Task<IActionResult> Update (int Id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { Controller = "Usuarios", Action = "Login" });
            }
            return View(await _service.GetByIdSaveViewModels(Id));
        }

        [HttpPost]
        public async Task<IActionResult> Update(SavePublicacionesViewModel vm)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { Controller = "User", Action = "Login" });
            }

            //if (!ModelState.IsValid)
            //{
            //    return View("Modified", vm);
            //}

            SavePublicacionesViewModel Publicationvm = await _service.GetByIdSaveViewModels(vm.Id);
            vm.Img_Miniatura = Publicationvm.Img_Miniatura;

            vm.Picture_Caption = UploadFile(vm.Img_Upload, Publicationvm.Id, true, Publicationvm.Picture_Caption);
            await _service.Update(vm, vm.Id);
            return RedirectToRoute(new { Controller = "Publicaciones", Action = "Index" });
        }


        public async Task<IActionResult> Delete(int Id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { Controller = "Usuarios", Action = "Login" });
            }
            return View(await _service.GetByIdSaveViewModels(Id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int Id)
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { Controller = "Usuarios", Action = "Login" });
            }

            await _service.Delete(Id);

            string basePath = $"/Images/Publicaciones/{Id}";
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{basePath}");
            if (!Directory.Exists(path))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(path);
                foreach (FileInfo file in directoryInfo.GetFiles())
                {
                    file.Delete();

                }

                foreach (DirectoryInfo folder in directoryInfo.GetDirectories())
                {
                    folder.Delete(true);
                }

                Directory.Delete(path);
            }

            return RedirectToRoute(new { Controller = "Publicaciones", Action = "Index" });

        }

        private string UploadFile(IFormFile file, int id, bool isEditMode = false, string ImageUrl = "")
        {
            if (isEditMode && file == null)
            {
                return ImageUrl;
            }
            //Get Directory Path
            string basePath = $"/Images/Publicaciones/{id}";
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{basePath}");

            //Create Folder If Not Exist
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            //Get File Path
            Guid guid = Guid.NewGuid();
            FileInfo fileInfo = new(file.FileName);
            string filename = guid + fileInfo.Extension;

            string fileNameWithPath = Path.Combine(path, filename);

            using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            if (isEditMode)
            {
                string[] oldImagePart = ImageUrl.Split('/');
                string oldImageName = oldImagePart[^1];
                string CompleteImageOldPath = Path.Combine(path, oldImageName);

                if (System.IO.File.Exists(CompleteImageOldPath))
                {
                    System.IO.File.Delete(CompleteImageOldPath);
                }
            }
            return $"{basePath}/{filename}";
        }








    }
}