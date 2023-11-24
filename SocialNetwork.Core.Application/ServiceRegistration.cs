using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.DependencyInjection;
using SocialNetwork.Core.Application.Interfaces.Services;
using SocialNetwork.Core.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Application
{
    public static class ServiceRegistration
    {
        public static void AppApplicationLayer(this IServiceCollection services)
        {
            #region "Services"

            
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddTransient<IUsuariosServices, UsuariosService>();
            services.AddTransient<IPublicacionesServices, PublicacionesService>();
            //services.AddTransient<IComentariosService, ComentariosService>();
            //services.AddTransient<IAmigosServices, AmigosService>();


            #endregion
        }
    }
}
