using Microsoft.EntityFrameworkCore;

namespace Proyecto3.Data.Migration
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    }
}
