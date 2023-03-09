using Jaya.Domain.Issues.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JayaTest.Fake
{
    public class IssueRepositoryFake : IIssueRepository
    {
        private readonly List<Issue> _data;

        public IssueRepositoryFake()
        {
            _data = new List<Issue>();
        }

        public async Task<Issue> GetLastEventAsync(long number)
        {
            return await
                Task.Run(() => _data.Where(w => w.Number == number).OrderByDescending(o => o.UpdatedAt).FirstOrDefault());
        }

        public async Task<IEnumerable<Issue>> GetAllEventsAsync(long number)
        {
            return await
                Task.Run(() => _data.Where(w => w.Number == number).OrderByDescending(o => o.Id).ToList());
        }

        public async Task SaveAsync(Issue issue)
        {
            await Task.Run(() => _data.Add(issue));
        }
    }
}