using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PersonSearchApi.Data.Dtos;
using PersonSearchApi.Data.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PersonSearchApi.Data.Queries
{
  public class GetAllInterestsQuery : IRequest<List<InterestDto>>
  {

    public class GetAllInterestsHandler : IRequestHandler<GetAllInterestsQuery, List<InterestDto>>
    {
      private readonly PersonDbContext _context;
      private readonly IMapper _mapper;

      public GetAllInterestsHandler(PersonDbContext context, IMapper mapper)
      {
        _context = context;
        _context.Database.EnsureCreated();
        _mapper = mapper;
      }

      public async Task<List<InterestDto>> Handle(GetAllInterestsQuery request, CancellationToken cancellationToken)
      {

        var data = await _context.Interests.ToListAsync();
        return _mapper.Map<List<Interest>, List<InterestDto>>(data);

      }
    }
  }
}
