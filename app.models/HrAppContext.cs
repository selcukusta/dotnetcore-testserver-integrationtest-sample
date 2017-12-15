using app.models.Entities;
using Microsoft.EntityFrameworkCore;

namespace app.models
{
    public class HrAppContext : DbContext
    {
        public HrAppContext(DbContextOptions<HrAppContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Person> Persons { get; set; }
    }
}
