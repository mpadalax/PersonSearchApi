using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using PersonSearchApi.Data.Dtos;
using PersonSearchApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PersonSearchApi.Data.Commands
{
  public class UpsertPersonCommand : IRequest<int>
  {
    public PersonDto PersonDtoReq { get; set; }
    public UpsertPersonCommand(PersonDto person)
    {
      PersonDtoReq = person;
    }

    public class CreatePersonCommandHandler : IRequestHandler<UpsertPersonCommand, int>
    {
      private readonly PersonDbContext _context;
      public CreatePersonCommandHandler(PersonDbContext context)
      {
        _context = context;
      }
      public async Task<int> Handle(UpsertPersonCommand request, CancellationToken cancellationToken)
      {
        Person entity;
        Address entityAddress;
        PersonInterest entityPersonInterest;

        if (request.PersonDtoReq.PersonId.HasValue)
        {
          entity = await _context.Persons.FindAsync(request.PersonDtoReq.PersonId);
          _context.Entry(entity).State = EntityState.Modified;
        }
        else
        {
          entity = new Person();

          _context.Persons.Add(entity);
        }

        entity.FirstName = request.PersonDtoReq.FirstName;
        entity.LastName = request.PersonDtoReq.LastName;
        entity.Email = request.PersonDtoReq.Email;
        entity.DateOfBirth = request.PersonDtoReq.DateOfBirth;
        entity.Picture = request.PersonDtoReq.Picture;

        foreach (var item in request.PersonDtoReq.Addresses)
        {
          if (item.AddressId.HasValue)
          {
            entityAddress = await _context.Addresses.FindAsync(item.AddressId.Value);
          }
          else
          {
            entityAddress = new Address();
            _context.Addresses.Add(entityAddress);
          }
          entityAddress.Street1 = item.Street1;
          entityAddress.Street2 = item.Street2;
          entityAddress.City = item.City;
          entityAddress.State = item.State;
          entityAddress.Country = item.Country;
          entityAddress.ZipCode = item.ZipCode;
          entity.Addresses.Add(entityAddress);
        }

        await _context.SaveChangesAsync(cancellationToken);

        foreach (var item in request.PersonDtoReq.Interests)
        {
          entityPersonInterest=await _context.PersonInterests.FindAsync(entity.PersonId,item.InterestId);

          if (entityPersonInterest==null)
          {
            entityPersonInterest = new PersonInterest();
            _context.PersonInterests.Add(entityPersonInterest);
            entityPersonInterest.PersonId = entity.PersonId;
            entityPersonInterest.InterestId = item.InterestId;
          }
        }

        await _context.SaveChangesAsync(cancellationToken);

        return entity.PersonId;
      }
    }

  }
}
