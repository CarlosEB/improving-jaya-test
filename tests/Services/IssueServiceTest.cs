using Jaya.Application.Services;
using Jaya.Test.Fakes;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Jaya.Test.Services
{

    public class IssueServiceTest
    : IClassFixture<WebApplicationFactory<Jaya.Startup>>
    {
        private IIssueService _issueService;

        public IssueServiceTest()
        {
            _issueService = new IssueService(new IssueRepositoryFake());
        }

        [Fact]
        public async Task ServiceShouldCreateTwoIssuesAndReadAll()
        {
            // Arrange
            _issueService = new IssueService(new IssueRepositoryFake());

            // Act
            await _issueService
                .SaveAsync(PayloadViewModelBuilder.Build("opened", 1, "Issue #1", new DateTime(2023, 03, 10, 9, 15, 20), null));

            await _issueService
                .SaveAsync(PayloadViewModelBuilder.Build("closed", 1, "Issue #1", new DateTime(2023, 03, 10, 9, 15, 20), new DateTime(2023, 03, 10, 9, 20, 32)));



            //  "{'action': 'opened','issue': {'number': 1,'title': 'Issue #1','created_at': '2023-03-10T14:32:15Z','updated_at': ''}}"); ;
            //await _issueService.SaveAsync("{'action': 'closed','issue': {'number': 1,'title': 'Issue #1','created_at': '2023-03-10T14:32:15Z','updated_at': '2023-03-10T14:35:15Z'}}");

            var resultAll = await _issueService.GetAllEventsAsync(1);
            var resultLast = await _issueService.GetLastEventAsync(1);

            // Assert          
            Assert.Equal(2, resultAll.Count);
            Assert.Equal("closed", resultLast.Action);
        }

        [Fact]
        public async Task ServiceShouldReturnAnErrorWhenNumberDoesNotExist()
        {
            // Arrange
            _issueService = new IssueService(new IssueRepositoryFake());

            // Act - Nothing to Do

            var resultAll = await _issueService.GetAllEventsAsync(2);
            var resultLast = await _issueService.GetLastEventAsync(2);

            // Assert          
            Assert.Equal(0, resultAll.Count);
            Assert.Equal(0, resultLast.Number);
        }

    }
}