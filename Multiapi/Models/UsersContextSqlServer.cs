using Microsoft.EntityFrameworkCore;
namespace Clase.Models
{
    public class UsersContextSqlServer : DbContext
    {
        public UsersContextSqlServer(DbContextOptions<UsersContextSqlServer>options)
        : base(options)
        {
        }
        public DbSet<Juegos> Juegos {get; set;} = null!;
    }
}