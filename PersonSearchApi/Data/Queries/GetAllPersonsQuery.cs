using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PersonSearchApi.Data.Dtos;
using PersonSearchApi.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PersonSearchApi.Data.Queries
{
  public class GetAllPersonsQuery : IRequest<List<PersonDto>>
  {
    public string SearchText { get; set; }

    public GetAllPersonsQuery(string searchText)
    {
      SearchText = searchText;
    }

    public class GetAllPersonsHandler : IRequestHandler<GetAllPersonsQuery, List<PersonDto>>
    {

      private readonly PersonDbContext _context;
      private readonly IMapper _mapper;

      public GetAllPersonsHandler(PersonDbContext context, IMapper mapper)
      {
        _context = context;
        _context.Database.EnsureCreated();
        _mapper = mapper;
      }

      public async Task<List<PersonDto>> Handle(GetAllPersonsQuery request, CancellationToken cancellationToken)
      {
        string searchText = request.SearchText;
        var data = await Task.Run(
                        () => _context.Persons.Where(p => (searchText == null ? true : p.FirstName.Contains(searchText) || searchText == null ? true : p.FirstName.Contains(searchText)))
                             .Include(p => p.Addresses)
                             .Include(p => p.PersonInterests)
                             .ThenInclude(p => p.Interest)
                             .AsEnumerable()
                             .Select(u =>
                             {
                               u.Interests = u.PersonInterests.Select(i => i.Interest).ToList();
                               return u;
                             }).ToList()
                        );

        return _mapper.Map<List<Person>, List<PersonDto>>(data);
      }

    }
  }
}
