using Microsoft.AspNetCore.Mvc;
using WebApplication1.Controllers;
using WebApplication1.Domain;
using WebApplication1.Repository;

namespace rsoi_lab1_tests
{
    public class PersonControllerTests
    {
        [Fact]
        public async Task GetAllPersonsTest()
        {
            List<Person> expected = new List<Person>() { new Person()
            {
                Id = 1,
                Name = "mockName",
                Address = "mockAddress",
                Age = 10,
                Work = "mockWork"
            } };
            var mock = new Mock<IPersonRepository>();
            mock.Setup(a => a.GetAllPersons()).ReturnsAsync(expected);
            PersonController controller = new PersonController(mock.Object);

            var result = await controller.GetPersons();
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var actual = okResult.Value;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task GetPersonByIdTest()
        {
            var expected = new Person()
            {
                Id = 1,
                Name = "mockName",
                Address = "mockAddress",
                Age = 10,
                Work = "mockWork"
            };
            var mock = new Mock<IPersonRepository>();
            mock.Setup(a => a.GetPersonById(1)).ReturnsAsync(expected);
            PersonController controller = new PersonController(mock.Object);

            var result = await controller.GetPersonById(1);
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var actual = okResult.Value;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task PostPersonTest()
        {
            var person = new Person()
            {
                Name = "mockName",
                Address = "mockAddress",
                Age = 10,
                Work = "mockWork"
            };
            var mock = new Mock<IPersonRepository>();
            PersonController controller = new PersonController(mock.Object);

            var result = await controller.PostPerson(person);

            mock.Verify(a => a.AddPerson(person));
        }

        [Fact]
        public async Task DeletePersonTest()
        {
            List<Person> expected = new List<Person>();
            var person = new Person()
            {
                Id = 1,
                Name = "mockName",
                Address = "mockAddress",
                Age = 10,
                Work = "mockWork"
            };
            var mock = new Mock<IPersonRepository>();
            PersonController controller = new PersonController(mock.Object);

            var result = await controller.DeletePerson(person.Id);

            mock.Verify(a => a.DeletePerson(person.Id));
        }
    }
}