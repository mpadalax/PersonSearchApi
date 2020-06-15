using MediatR;
using PersonSearchApi.Data.Commands;
using PersonSearchApi.Data.Dtos;
using PersonSearchApi.Data.Queries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonSearchApi.Services
{
  public class PersonService : IPersonService
  {
    private readonly IMediator _mediator;

    public PersonService(IMediator mediator)
    {
      _mediator = mediator;
    }

    public async Task DeletePerson(int personId)
    {
      await _mediator.Send(new DeletePersonCommand(personId));
    }

    public async Task<int> AddUpdatePerson(PersonDto person)
    {
      return await _mediator.Send(new UpsertPersonCommand(person));
    }

    public async Task<List<PersonDto>> GetPeople(string searchText)
    {
      return await _mediator.Send(new GetAllPersonsQuery(searchText));
    }
  }
}
