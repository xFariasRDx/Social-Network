using Microsoft.EntityFrameworkCore;
using SocialNetwork.Core.Application.Helpers;
using SocialNetwork.Core.Application.Interfaces.Repositories;
using SocialNetwork.Core.Application.Interfaces.Services;
using SocialNetwork.Core.Application.ViewModels.Login;
using SocialNetwork.Core.Domain.Entities;
using SocialNetwork.Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Infrastructure.Persistence.Repositories
{
    public class UsuariosRepository : GenericRepository<Usuarios>, IUsuariosRepository
    {
        private readonly ApplicationContext _dbcontext;

        public UsuariosRepository(ApplicationContext dbcontext) : base(dbcontext)
        {
            _dbcontext = dbcontext;
        }
        
        public async Task<Usuarios> LoginAsync(LoginViewModel loginVm)
        {
            string passwordEncryption = PasswordEncryption.ComputeSha256Hash(loginVm.Password);
            Usuarios usuarios = await _dbcontext.Set<Usuarios>()
                .FirstOrDefaultAsync(usuarios => usuarios.Usuario == loginVm.Usuario && usuarios.Password == passwordEncryption);

            return usuarios;
        }

        public override async Task<Usuarios> AddAsync(Usuarios entity)
        {
            entity.Password = PasswordEncryption.ComputeSha256Hash(entity.Password);
            await base.AddAsync(entity);
            return entity;
        }

        public async Task<Usuarios> GetByUserAsync(string usuario)
        {
            return _dbcontext.Usuarios.FirstOrDefault(p => p.Usuario == usuario);
        }

    }
}
