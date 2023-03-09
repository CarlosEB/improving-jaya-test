using Jaya.Application.Services;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace JayaTest
{

    public class BasicTests
    : IClassFixture<WebApplicationFactory<Jaya.Startup>>
    {
        private readonly WebApplicationFactory<Jaya.Startup> _factory;

        public BasicTests()
        {
            _factory = new WebApplicationFactory<Jaya.Startup>().WithWebHostBuilder(builder =>
           {
               var descriptor = new ServiceDescriptor(
                    typeof(IIssueService), typeof(IssueServiceFake), ServiceLifetime.Transient);

               builder.ConfigureServices(services => services.Add(descriptor));

           });
        }

        [Theory]
        [InlineData("/Events/1/lastevent")]
        [InlineData("/Events/1/events")]
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200
            Assert.Equal("application/json; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }

        [Theory]
        [InlineData("/Events/11/lastevent")]
        [InlineData("/Events/11/events")]
        public async Task Get_EndpointsReturnNoContent(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.StatusCode.Equals(HttpStatusCode.NoContent); // Status Code 204
            Assert.Null(response.Content.Headers.ContentType);
        }
    }
}