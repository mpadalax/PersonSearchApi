using PersonSearchApi.Data.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonSearchApi.Services
{
  public interface IPersonService
  {
    Task<List<PersonDto>> GetPeople(string searchText);
    Task<int> AddUpdatePerson(PersonDto person);
    Task DeletePerson(int personId);
  }
}
