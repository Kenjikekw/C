using Microsoft.EntityFrameworkCore;
namespace Clase.Models
{
    public class UsersContextMySql : DbContext
    {
        public UsersContextMySql(DbContextOptions<UsersContextMySql>options)
        : base(options)
        {
        }
        public DbSet<Enfermedades> Enfermedades {get; set;} = null!;
    }
}