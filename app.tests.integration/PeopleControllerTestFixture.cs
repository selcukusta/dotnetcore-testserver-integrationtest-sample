using app.models.Entities;
using app.tests.integration.ClassFixtures;
using app.tests.integration.Middleware;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace app.tests.integration
{
    [TestCaseOrderer(CustomOrderer.TypeName, CustomOrderer.AssembyName)]
    public class PeopleControllerTestFixture : IClassFixture<ClientFixture>
    {
        private readonly HttpClient _client;

        public PeopleControllerTestFixture(ClientFixture hede)
        {
            _client = hede.Client;
        }

        [Fact, TestOrder(2)]
        public async Task When_GetPeople_ReturnAnyPerson()
        {
            var response = await _client.GetAsync("/api/people");
            response.EnsureSuccessStatusCode();
            var responseContent = await response.Content.ReadAsStringAsync();
            if (!string.IsNullOrWhiteSpace(responseContent))
            {
                var people = JsonConvert.DeserializeObject<IList<Person>>(responseContent);
                Assert.True(people != null && people.Any());
            }
        }

        [Fact, TestOrder(1)]
        public async Task When_InsertPerson_ReturnStatusCode201AndPersonIdGreaterThanZero()
        {
            var jsonPerson = JsonConvert.SerializeObject(new Person
            {
                Name = "John",
                Surname = "Doe",
                IdentificationNumber = "13485949610"
            });
            var response = await _client.PostAsync("/api/people", new StringContent(jsonPerson, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            var responseContent = await response.Content.ReadAsStringAsync();
            if (!string.IsNullOrWhiteSpace(responseContent))
            {
                var person = JsonConvert.DeserializeObject<Person>(responseContent);
                Assert.True(person.Id > 0);
            }
        }
    }
}
