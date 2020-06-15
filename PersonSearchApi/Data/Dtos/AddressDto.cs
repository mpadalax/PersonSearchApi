namespace PersonSearchApi.Data.Dtos
{
  public class AddressDto
  {
    public int? PersonId { get; set; }
    public int? AddressId { get; set; }
    public string Street1 { get; set; }
    public string Street2 { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string ZipCode { get; set; }
  }
}
