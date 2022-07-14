using Microsoft.EntityFrameworkCore;
using natura_process_api.Models;
namespace natura_process_api.Data;
public class Context : DbContext
{
    public Context(DbContextOptions<Context> options)
        : base(options)
    {

    }
    public DbSet<User> User { get; set; }
}
