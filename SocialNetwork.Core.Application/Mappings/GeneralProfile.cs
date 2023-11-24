using AutoMapper;
using Microsoft.CodeAnalysis;
using SocialNetwork.Core.Application.ViewModels.Amigos;
using SocialNetwork.Core.Application.ViewModels.Comentarios;
using SocialNetwork.Core.Application.ViewModels.Publicaciones;
using SocialNetwork.Core.Application.ViewModels.Usuarios;
using SocialNetwork.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Usuarios, UsuariosViewModel>()
            .ReverseMap();

            CreateMap<Usuarios, SaveUsuariosViewModel>()
            .ForMember(dest => dest.Confirm_Password, opt => opt.Ignore())
            .ForMember(dest => dest.Img_Upload, opt => opt.Ignore())
            .ForMember(dest => dest.Existing, opt => opt.Ignore())
                .ReverseMap()
            .ForMember(dest => dest.Comentarios, opt => opt.Ignore())
            .ForMember(dest => dest.Amigos, opt => opt.Ignore())
            .ForMember(dest => dest.Amigos2, opt => opt.Ignore())
            .ForMember(dest => dest.Publicaciones, opt => opt.Ignore());


            CreateMap<Comentarios, ComentariosViewModel>()
            .ReverseMap();

            CreateMap<Comentarios, SaveComentariosViewModel>()
            .ReverseMap();

            CreateMap<Amigos, AmigosViewModel>()
            .ReverseMap();

            CreateMap<Amigos, SaveAmigosViewModel>()
            .ReverseMap();

            CreateMap<Publicaciones, PublicacionesViewModel>()
            .ForMember(dest => dest.Username, opt => opt.Ignore())
                .ReverseMap();


            CreateMap<Publicaciones, SavePublicacionesViewModel>()
            .ForMember(dest => dest.Img_Upload, opt => opt.Ignore())
                .ReverseMap()
            .ForMember(dest => dest.Usuarios, opt => opt.Ignore())
            .ForMember(dest => dest.Pcomentarios, opt => opt.Ignore());
            
        }

    }
}
