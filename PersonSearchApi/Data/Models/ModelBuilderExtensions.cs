using Microsoft.EntityFrameworkCore;
using System;

namespace PersonSearchApi.Data.Models
{
  public static class ModelBuilderExtensions
  {
    public static void Seed(this ModelBuilder modelBuilder)
    {
      //Dummy Data from https://randonuser.me
      modelBuilder.Entity<Person>().HasData(
        new Person
        {
          PersonId = 1,
          FirstName = "Karl",
          LastName = "Johnson",
          DateOfBirth = new DateTime(1965, 11, 30),
          Email = "karl.johnson@example.com",
          Picture = "https://randomuser.me/api/portraits/thumb/men/6.jpg"
        },
        new Person
        {
          PersonId = 2,
          FirstName = "Finn",
          LastName = "Morris",
          DateOfBirth = new DateTime(1997, 12, 02),
          Email = "finn.morris@example.com",
          Picture = "https://randomuser.me/api/portraits/thumb/men/64.jpg"
        },
        new Person
        {
          PersonId = 3,
          FirstName = "Romane",
          LastName = "Perez",
          DateOfBirth = new DateTime(1995, 04, 30),
          Email = "romane.perez@example.com",
          Picture = "https://randomuser.me/api/portraits/thumb/women/36.jpg"
        },
        new Person
        {
          PersonId = 4,
          FirstName = "Klara",
          LastName = "Degner",
          DateOfBirth = new DateTime(1982, 05, 28),
          Email = "klara.degner@example.com",
          Picture = "https://randomuser.me/api/portraits/thumb/women/12.jpg"
        },
        new Person
        {
          PersonId = 5,
          FirstName = "Christian",
          LastName = "Jensen",
          DateOfBirth = new DateTime(1950, 11, 21),
          Email = "christian.jensen@example.com",
          Picture = "https://randomuser.me/api/portraits/thumb/men/33.jpg"
        },
        new Person
        {
          PersonId = 6,
          FirstName = "Doris",
          LastName = "Beck",
          DateOfBirth = new DateTime(1954, 12, 14),
          Email = "doris.beck@example.com",
          Picture = "https://randomuser.me/api/portraits/thumb/women/47.jpg"
        },
        new Person
        {
          PersonId = 7,
          FirstName = "Melvyn",
          LastName = "Benjamin",
          DateOfBirth = new DateTime(1952, 03, 31),
          Email = "melvyn.benjamin@example.com",
          Picture = "https://randomuser.me/api/portraits/thumb/men/63.jpg"
        },
        new Person
        {
          PersonId = 8,
          FirstName = "Murali",
          LastName = "Padala",
          DateOfBirth = new DateTime(1980, 08, 10),
          Email = "murali.padalan@example.com",
          Picture = "https://randomuser.me/api/portraits/thumb/men/99.jpg"
        },
        new Person
        {
          PersonId = 9,
          FirstName = "Nolhan",
          LastName = "Rousseau",
          DateOfBirth = new DateTime(1977, 10, 10),
          Email = "nolhan.rousseau@example.com",
          Picture = "https://randomuser.me/api/portraits/thumb/men/64.jpg"
        });


      modelBuilder.Entity<Address>().HasData(
        new Address
        {
          AddressId = 1,
          PersonId = 1,
          Street1 = "6057, Avondale Ave",
          Street2 = "",
          City = "New York",
          State = "New York",
          Country = "United States",
          ZipCode = "12564"
        },
        new Address
        {
          AddressId = 2,
          PersonId = 2,
          Street1 = "7130, The Strand",
          Street2 = "",
          City = "New Plymouth",
          State = "Nelson",
          Country = "New Zealand",
          ZipCode = "21728"
        },
        new Address
        {
          AddressId = 3,
          PersonId = 3,
          Street1 = "3717, Rue Dubois",
          Street2 = "",
          City = "Bordeaux",
          State = "Bouches-du-Rhône",
          Country = "France",
          ZipCode = "48220"
        },
        new Address
        {
          AddressId = 4,
          PersonId = 4,
          Street1 = "2902, Talstraße",
          Street2 = "",
          City = "Oelsnitz",
          State = "Bremen",
          Country = "Germany",
          ZipCode = "82147"
        },
        new Address
        {
          AddressId = 5,
          PersonId = 5,
          Street1 = "600, Samsøvej",
          Street2 = "",
          City = "Rødvig Stevns",
          State = "Midtjylland",
          Country = "Denmark",
          ZipCode = "99266"
        },
        new Address
        {
          AddressId = 6,
          PersonId = 6,
          Street1 = "2422, Poplar Dr",
          Street2 = "",
          City = "Chicago",
          State = "Illinois",
          Country = "United States",
          ZipCode = "71227"
        },
        new Address
        {
          AddressId = 7,
          PersonId = 7,
          Street1 = "9442, White Oak Dr",
          Street2 = "",
          City = "Bendigo",
          State = "Victoria",
          Country = "Australia",
          ZipCode = "21033"
        },
        new Address
        {
          AddressId = 8,
          PersonId = 8,
          Street1 = "123 Mill Creek Ave",
          Street2 = "",
          City = "Atlanta",
          State = "Georgia",
          Country = "United States",
          ZipCode = "30350"
        },
        new Address
        {
          AddressId = 9,
          PersonId = 9,
          Street1 = "6948, Rue de L'Abbé-Groult",
          Street2 = "",
          City = "Pau",
          State = "Pyrénées-Orientales",
          Country = "France",
          ZipCode = "17211"
        });


      modelBuilder.Entity<Interest>().HasData(
        new Interest { InterestId = 1, Name = "Baking" },
        new Interest { InterestId = 2, Name = "Cooking" },
        new Interest { InterestId = 3, Name = "Dance" },
        new Interest { InterestId = 4, Name = "Gardening" },
        new Interest { InterestId = 5, Name = "Hiking" },
        new Interest { InterestId = 6, Name = "Painting" },
        new Interest { InterestId = 7, Name = "Programming" },
        new Interest { InterestId = 8, Name = "Reading" },
        new Interest { InterestId = 9, Name = "Sewing" },
        new Interest { InterestId = 10, Name = "Singing" },
        new Interest { InterestId = 11, Name = "Soccer" },
        new Interest { InterestId = 12, Name = "Tennis" },
        new Interest { InterestId = 13, Name = "Travel" },
        new Interest { InterestId = 14, Name = "Yoga" },
        new Interest { InterestId = 15, Name = "Zumba" });

      modelBuilder.Entity<PersonInterest>().HasData(
        new PersonInterest { PersonId = 1, InterestId = 3 },
        new PersonInterest { PersonId = 2, InterestId = 4 },
        new PersonInterest { PersonId = 3, InterestId = 5 },
        new PersonInterest { PersonId = 4, InterestId = 7 },
        new PersonInterest { PersonId = 5, InterestId = 8 },
        new PersonInterest { PersonId = 6, InterestId = 9 },
        new PersonInterest { PersonId = 7, InterestId = 1 },
        new PersonInterest { PersonId = 8, InterestId = 11 },
        new PersonInterest { PersonId = 9, InterestId = 6 });
    }
  }
}
