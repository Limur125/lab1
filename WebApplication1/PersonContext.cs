using Microsoft.EntityFrameworkCore;
using WebApplication1.Domain;

namespace WebApplication1
{
    public class PersonContext : DbContext
    {

        public PersonContext()
        {
        }
        public PersonContext(DbContextOptions<PersonContext> options) : base(options)
        {
        } 

        public DbSet<Person> persons { get; set; }
    }
}
