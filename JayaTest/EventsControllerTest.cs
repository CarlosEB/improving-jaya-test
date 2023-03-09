using Jaya.Application.Services;
using JayaTest.Fake;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace JayaTest
{
    public class EventsControllerTest
    : IClassFixture<WebApplicationFactory<Jaya.Startup>>
    {
        private readonly WebApplicationFactory<Jaya.Startup> _factory;

        public EventsControllerTest()
        {
            _factory = new WebApplicationFactory<Jaya.Startup>().WithWebHostBuilder(builder =>
           {
               var descriptor = 
               new ServiceDescriptor(typeof(IIssueService), typeof(IssueServiceFake), ServiceLifetime.Transient);

               builder.ConfigureServices(services => services.Add(descriptor));
           });
        }

        [Theory]
        [InlineData("/Events/1/lastevent")]
        [InlineData("/Events/1/events")]
        public async Task EndpointsShouldReturnSuccessAndCorrectContentType(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert - Status Code 200
            response.EnsureSuccessStatusCode(); 
            Assert.Equal("application/json; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }

        [Theory]
        [InlineData("/Events/11/lastevent")]
        [InlineData("/Events/11/events")]
        public async Task EndpointsShouldReturnNoContent(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert - Status Code 204
            response.StatusCode.Equals(HttpStatusCode.NoContent); 
            Assert.Null(response.Content.Headers.ContentType);
        }
    }
}