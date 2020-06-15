using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonSearchApi.Data.Models
{
  public class Interest
  {
    public int InterestId { get; set; }
    public string Name { get; set; }
    [NotMapped]
    public virtual ICollection<PersonInterest> PersonInterests { get; set; }
  }
}
