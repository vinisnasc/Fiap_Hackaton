using Fiap_Hackaton.Identity.API.Models;
using Fiap_Hackaton.Identity.API.Models.Constantes;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Fiap_Hackaton.Identity.API.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<UsuarioAplicacao> UsuariosAplicacao { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<UsuarioAplicacao>()
            .HasIndex(u => u.Identificacao)
            .IsUnique();

        builder.Entity<IdentityRole>().HasData(
            new IdentityRole { Id = "1d7c3e7b-2fbc-4a1b-8a45-1e2eae6f9d8a", Name = Perfil.Medico, NormalizedName = Perfil.Medico.ToUpper() },
            new IdentityRole { Id = "2e8b9d3c-3fac-4c2b-9d56-2f4c4e7e8d9b", Name = Perfil.Paciente, NormalizedName = Perfil.Paciente.ToUpper() }
        );
    }
}