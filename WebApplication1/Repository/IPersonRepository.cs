using WebApplication1.Domain;

namespace WebApplication1.Repository
{
    public interface IPersonRepository
    {
        Task<Person> GetPersonById(int Id);
        Task<IEnumerable<Person>> GetAllPersons();
        Task AddPerson(Person person);
        Task<Person> UpdatePerson(int Id, Person person);
        Task DeletePerson(int Id);
      
    }
}
