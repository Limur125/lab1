using Microsoft.AspNetCore.Mvc;
using WebApplication1.Domain;
using WebApplication1.Repository;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/v1/persons")]
public class PersonController(IPersonRepository personRepository) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Person>>> GetPersons()
    {
        var result = await personRepository.GetAllPersons();
        return Ok(result);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Person>> GetPersonById(int id)
    {
        try
        {
            var result = await personRepository.GetPersonById(id);
            return Ok(result);
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }
    
    [HttpPost]
    public async Task<ActionResult> PostPerson(Person person)
    {
        try
        {
            await personRepository.AddPerson(person);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        var personId = person.id;
        return Created($"api/v1/persons/{personId}", null);
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeletePerson(int id)
    {
        try
        {
            await personRepository.DeletePerson(id);
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
        return StatusCode(StatusCodes.Status204NoContent);

    }
    
    [HttpPatch("{id}")]
    public async Task<ActionResult> PatchPerson(int id, [FromBody] Person person)
    {
        try
        {
            var res = await personRepository.UpdatePerson(id, person);
            return Ok(res);
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }
}