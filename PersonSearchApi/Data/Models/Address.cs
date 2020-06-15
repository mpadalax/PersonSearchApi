using System.ComponentModel.DataAnnotations.Schema;

namespace PersonSearchApi.Data.Models
{
  public class Address
  {
    public int AddressId { get; set; }
    public int PersonId { get; set; }
    public string Street1 { get; set; }
    public string Street2 { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string ZipCode { get; set; }
    [NotMapped]
    public virtual Person Person { get; set; }
  }
}
