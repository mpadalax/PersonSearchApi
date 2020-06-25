using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PersonSearchApi.Data.Dtos;
using PersonSearchApi.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonSearchApi.Controllers
{
  [ApiVersion("1.0")]
  [EnableCors("AllowOrigin")]
  [Route("person")]
  [ApiController]
  public class PeopleController : ControllerBase
  {
    private readonly IPersonService _service;

    public PeopleController(IPersonService service)
    {
      _service = service;
    }

    // GET: People
    [HttpGet("getall/{searchText?}")]
    public async Task<ActionResult<List<PersonDto>>> GetPersonAsync(string searchText = null)
    {
      var result = await _service.GetPeople(searchText);
      return result != null ? (ActionResult)Ok(result) : NotFound();
    }

    [HttpPost("add")]
    public async Task<ActionResult<int>> AddPersonAsync([FromBody] PersonDto person)
    {
      return await _service.AddUpdatePerson(person);
    }

    [HttpPut("{personId}")]
    public async Task<ActionResult<int>> UpsertPersonAsync([FromRoute] int personId, [FromBody] PersonDto person)
    {
      if (personId != person.PersonId)
      {
        return BadRequest();
      }
      return await _service.AddUpdatePerson(person);
    }

    [HttpDelete("{personId}")]
    public async Task DeletePersonAsync([FromRoute] int personId)
    {
      await _service.DeletePerson(personId);
    }
  }
}
