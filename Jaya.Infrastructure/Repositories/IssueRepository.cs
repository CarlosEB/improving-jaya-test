
using Jaya.Domain.Issues.Interfaces;
using Jaya.Infrastructure.DataAccess;
using System.Collections.Generic;
using System.Linq;

namespace Jaya.Infrastructure.Repositories
{
    public class IssueRepository : IIssueRepository
    {
        public DomainContext Context { get; set; }

        public IssueRepository(DomainContext context)
        {
            Context = context;
        }


        public Issue GetLastEvent(long number)
        {
            return GetAllEvents(number).FirstOrDefault();
        }

        public IEnumerable<Issue> GetAllEvents(long number)
        {
            return Context.Set<Issue>().Where(w => w.Number == number).OrderByDescending(o => o.Id).ToList();
        }

        public async void Save(Issue issue)
        {
            Context.Set<Issue>().Add(issue);
            Context.SaveChanges();
        }

    }
}