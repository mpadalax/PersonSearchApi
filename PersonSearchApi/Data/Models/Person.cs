using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonSearchApi.Data.Models
{
  public class Person
  {
    public Person()
    {
      Addresses = new HashSet<Address>();
      Interests = new HashSet<Interest>();
    }

    //displaying at least name, address, age, interests, and a picture
    public int PersonId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Picture { get; set; }
    public virtual ICollection<Address> Addresses { get; set; }
    [NotMapped]
    public virtual ICollection<Interest> Interests { get; set; }
    [NotMapped]
    public virtual ICollection<PersonInterest> PersonInterests { get; set; }
  }
}
