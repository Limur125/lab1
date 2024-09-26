﻿using Microsoft.EntityFrameworkCore;
using WebApplication1.Domain;

namespace WebApplication1.Repository
{
    public class PersonRepository(PersonContext context) : IPersonRepository
    {
        public async Task<Person> GetPersonById(int Id)
        {
            var person = await context.persons.FirstOrDefaultAsync(x => x.id == Id);
            return person ?? throw new ArgumentException($"Person with Id {Id} does not exists");
        }
        public async Task<IEnumerable<Person>> GetAllPersons() => await context.persons.ToArrayAsync();
        public async Task AddPerson (Person person)
        {
            var newPerson = await context.persons.FirstOrDefaultAsync(x => x.id == person.id);
            if (newPerson != null)
                throw new ArgumentException($"Person with Id {person.id} does exists");
            await context.persons.AddAsync(person);
            await context.SaveChangesAsync();
        }
        public async Task UpdatePerson(int Id)
        {
            var person = await context.persons.FirstOrDefaultAsync(x => x.id == Id) ?? 
                throw new ArgumentException($"Person with Id {Id} does not exists");
            context.persons.Update(person);
            await context.SaveChangesAsync();
        }
        public async Task DeletePerson(int Id)
        {
            var person = await context.persons.FirstOrDefaultAsync(x => x.id == Id) ??
                throw new ArgumentException($"Person with Id {Id} does not exists");
            context.persons.Remove(person);
            await context.SaveChangesAsync();
        }
    }
}
