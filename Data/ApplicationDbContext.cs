using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ExamenParcial.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<ExamenParcial.Models.Remesa> DataRemesa {get; set; }
    public DbSet<ExamenParcial.Models.Conversiones> DataConversion {get; set; }
}
