using MediatR;
using PersonSearchApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Threading;
using System.Threading.Tasks;

namespace PersonSearchApi.Data.Commands
{
  public class DeletePersonCommand : IRequest
  {
    public int PersonId { get; set; }

    public DeletePersonCommand(int personId)
    {
      PersonId = personId;
    }

    public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand>
    {
      private readonly PersonDbContext _context;
      public DeletePersonCommandHandler(PersonDbContext context)
      {
        _context = context;
      }
      public async Task<Unit> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
      {
        var entity = await _context.Persons.FindAsync(request.PersonId);

        if (entity == null)
        {
          throw new Exception($"{ nameof(Person) } not found.");
        }  

        _context.Persons.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
      }
    }
  }
}
