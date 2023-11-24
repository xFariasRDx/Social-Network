using SocialNetwork.Core.Application.Interfaces.Repositories;
using SocialNetwork.Core.Domain.Entities;
using SocialNetwork.Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Infrastructure.Persistence.Repositories
{
    public class ComentariosRepository : GenericRepository<Comentarios>, IComentariosRepository
    {
        private readonly ApplicationContext _dbcontext;

        public ComentariosRepository(ApplicationContext dbcontext) : base (dbcontext)
        {
            _dbcontext = dbcontext;
        }
    }
}
