using AutoMapper;
using SocialNetwork.Core.Application.Interfaces.Repositories;
using SocialNetwork.Core.Application.ViewModels.Amigos;
using SocialNetwork.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Application.Services
{
    public class AmigosService : GenericService<Amigos, AmigosViewModel, SaveAmigosViewModel>
    {
        private readonly IAmigosRepository _repository;
        private readonly IMapper _imapper;

        public AmigosService(IAmigosRepository repository, IMapper imapper) : base(repository, imapper)
        {
            _imapper = imapper;
            _repository = repository;
        }
    }
}   
