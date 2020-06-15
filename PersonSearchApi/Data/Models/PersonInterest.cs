using System.ComponentModel.DataAnnotations.Schema;

namespace PersonSearchApi.Data.Models
{
  public class PersonInterest
  {
    public int PersonId { get; set; }
    public int InterestId { get; set; }
    [NotMapped]
    public virtual Interest Interest { get; set; }
    [NotMapped]
    public virtual Person Person { get; set; }
  }
}
