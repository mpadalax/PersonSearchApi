using System;
using System.Collections.Generic;

namespace PersonSearchApi.Data.Dtos
{
  public class PersonDto
  {
    public int? PersonId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Picture { get; set; }
    public int Age
    {
      get
      {
        if (DateOfBirth != DateTime.MinValue)
        {
          int ret = DateTime.Now.Year - DateOfBirth.Year;
          if (DateOfBirth > DateTime.Now.AddYears(-ret))
            return ret--;
          else
            return ret;
        }
        return 0;
      }
    }
    public List<AddressDto> Addresses { get; set; }
    public List<InterestDto> Interests { get; set; }
  }
}
