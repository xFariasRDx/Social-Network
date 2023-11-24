using Microsoft.EntityFrameworkCore;
using SocialNetwork.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Infrastructure.Persistence.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> dbContextOptions) : base(dbContextOptions) { } //DEPENDECY INJECTION.

        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Amigos> Amigos { get; set; }
        public DbSet<Publicaciones> Publicaciones { get; set;}
        public DbSet<Comentarios> Comentarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region "FLUENT API"
            


            #region "TABLAS"
            modelBuilder.Entity<Usuarios>().ToTable("Usuarios");
            modelBuilder.Entity<Publicaciones>().ToTable("Publicaciones");
            modelBuilder.Entity<Amigos>().ToTable("Amigos");
            modelBuilder.Entity<Comentarios>().ToTable("Comentarios");
            #endregion

            #region "Primary Keys"
            modelBuilder.Entity<Usuarios>().HasKey(u => u.Id);
            modelBuilder.Entity<Publicaciones>().HasKey(p => p.Id);
            modelBuilder.Entity<Amigos>().HasKey(a => a.Id);
            modelBuilder.Entity<Comentarios>().HasKey(c => c.Id);
            #endregion

            #region "RelationShips"

            modelBuilder.Entity<Usuarios>().HasMany(a => a.Amigos).WithOne(a => a.Usuarios).HasForeignKey(a => a.Id_Usuarios).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Usuarios>().HasMany(p => p.Publicaciones).WithOne(u => u.Usuarios).HasForeignKey(a => a.Id_Usuarios).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Usuarios>().HasMany(a => a.Amigos2).WithOne(a => a.Usuarios2).HasForeignKey(a => a.Id_Usuarios2).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Usuarios>().HasMany(c => c.Comentarios).WithOne(u => u.Usuarios).HasForeignKey(c => c.Id_Usuario).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Publicaciones>().HasMany(c => c.Pcomentarios).WithOne(p => p.Publicaciones).HasForeignKey(c => c.Id).OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region "Property Configuration"


            #region "Amigos"
            #endregion

            #region "Usuarios"
            #endregion

            #region "Publicaciones"
            #endregion

            #region "Comentarios"
            #endregion


            #endregion



            #endregion

        }
    }
}
