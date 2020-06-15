using MediatR;
using Moq;
using PersonSearchApi.Data.Dtos;
using PersonSearchApi.Data.Models;
using PersonSearchApi.Data.Queries;
using PersonSearchApi.Services;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PeopleSearchApi.Tests
{
  public class PersonServiceTester
  {
    Mock<IMediator> _fakeMediator;
    PersonService _personService;
    public PersonServiceTester()
    {
      _fakeMediator = new Mock<IMediator>();
    }

    [Fact]
    public async Task GetPeople_ReturnMatchingEmailAsync()
    {
      //Arrange
      Mock<List<PersonDto>> personList = new Mock<List<PersonDto>>();
      var persons = new List<PersonDto>();
      persons.Add(new PersonDto
      {
        PersonId = 1,
        FirstName = "Karl",
        LastName = "Johnson",
        DateOfBirth = new DateTime(1965, 11, 30),
        Email = "karl.johnson@example.com",
        Picture = "https://randomuser.me/api/portraits/thumb/men/6.jpg"
      });
      persons.Add(new PersonDto
      {
        PersonId = 8,
        FirstName = "Murali",
        LastName = "Padala",
        DateOfBirth = new DateTime(1980, 08, 10),
        Email = "murali.padala@example.com",
        Picture = "https://randomuser.me/api/portraits/thumb/men/99.jpg"
      });

      _fakeMediator.SetupSequence(x => x.Send(It.IsAny<GetAllPersonsQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(persons);
      _personService = new PersonService(_fakeMediator.Object);

      //Act
      var actualList = await _personService.GetPeople(It.IsAny<string>());
      PersonDto actual = actualList[1];
      PersonDto expected = new PersonDto
      {
        PersonId = 8,
        FirstName = "Murali",
        LastName = "Padala",
        DateOfBirth = new DateTime(1980, 08, 10),
        Email = "murali.padala@example.com",
        Picture = "https://randomuser.me/api/portraits/thumb/men/99.jpg"
      };

      //Assert
      Assert.Equal(actual.Email, expected.Email);
    }
  }
}
