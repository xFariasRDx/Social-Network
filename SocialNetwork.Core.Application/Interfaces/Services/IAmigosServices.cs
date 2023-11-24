﻿using SocialNetwork.Core.Application.ViewModels.Amigos;
using SocialNetwork.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Core.Application.Interfaces.Services
{
    public interface IAmigosServices : IGenericServices< Amigos, AmigosViewModel, SaveAmigosViewModel>
    {
    }
}
