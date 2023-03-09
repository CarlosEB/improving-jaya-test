using Jaya.Application.Services;
using Jaya.Application.ViewModels;
using Jaya.Domain.Issues.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JayaTest
{
    public class IssueServiceFake : IIssueService
    {
        private IList<Issue> _data = new List<Issue>()
        {
             new Issue(1,"opened", new DateTime(2023,03,10), new DateTime(2023,03,10),"Title1"),
             new Issue(1,"closed", new DateTime(2023,03,10), new DateTime(2023,03,11),"Title1"),
             new Issue(2,"opened", new DateTime(2023,03,11), new DateTime(2023,03,11),"Title2")
        };

        public async Task<IList<IssueViewModel>> GetAllEventsAsync(long number)
        {
            return await Task.Run(
                () =>
                _data.Where(w => w.Number == number).Select(s => new IssueViewModel(s)).ToList());
        }

        public async Task<IssueViewModel> GetLastEventAsync(long number)
        {
            return await Task.Run(
                () =>
                new IssueViewModel(_data.Where(w => w.Number == number).OrderByDescending(o => o.Id).FirstOrDefault()));
        }

        public Task SaveAsync(object payload)
        {
            throw new NotImplementedException();
        }
    }
}
