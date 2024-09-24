using Microsoft.EntityFrameworkCore;
using WebApplication1.Domain;

namespace WebApplication1.Repository
{
    public class PersonRepository(PersonContext context) : IPersonRepository
    {
        public async Task<Person> GetPersonById(int Id)
        {
            var person = await context.Persons.FirstOrDefaultAsync(x => x.Id == Id);
            return person ?? throw new ArgumentException($"Person with Id {Id} does not exists");
        }
        public async Task<IEnumerable<Person>> GetAllPersons() => await context.Persons.ToArrayAsync();
        public async Task AddPerson (Person person)
        {
            var newPerson = await context.Persons.FirstOrDefaultAsync(x => x.Id == person.Id) ??
                throw new ArgumentException($"Person with Id {person.Id} does exists");
            await context.Persons.AddAsync(person);
            await context.SaveChangesAsync();
        }
        public async Task UpdatePerson(int Id)
        {
            var person = await context.Persons.FirstOrDefaultAsync(x => x.Id == Id) ?? 
                throw new ArgumentException($"Person with Id {Id} does not exists");
            context.Persons.Update(person);
            await context.SaveChangesAsync();
        }
        public async Task DeletePerson(int Id)
        {
            var person = await context.Persons.FirstOrDefaultAsync(x => x.Id == Id) ??
                throw new ArgumentException($"Person with Id {Id} does not exists");
            context.Persons.Remove(person);
            await context.SaveChangesAsync();
        }
    }
}
