using Microsoft.EntityFrameworkCore;
namespace Clase.Models
{
    public class UsersContextPostgres : DbContext
    {
        public UsersContextPostgres(DbContextOptions<UsersContextPostgres>options)
        : base(options)
        {
        }
        public DbSet<Animales> Animales {get; set;} = null!;
    }
}