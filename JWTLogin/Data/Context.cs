using Microsoft.EntityFrameworkCore;
using JWTLogin.Models;
namespace JWTLogin.Data;
public class Context : DbContext
{
    public Context(DbContextOptions<Context> options)
        : base(options)
    {

    }
    public DbSet<User> User { get; set; }
}
