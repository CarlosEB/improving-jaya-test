
using Jaya.Domain.Issues.Interfaces;
using Jaya.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jaya.Infrastructure.Repositories
{
    public class IssueRepository : IIssueRepository
    {
        public DomainContext Context { get; set; }

        public IssueRepository(DomainContext context)
        {
            Context = context;
        }


        public async Task<Issue> GetLastEventAsync(long number)
        {
            return await Context.Set<Issue>().Where(w => w.Number == number).OrderByDescending(o => o.Id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Issue>> GetAllEventsAsync(long number)
        {
            return await Context.Set<Issue>().Where(w => w.Number == number).OrderByDescending(o => o.Id).ToListAsync();
        }

        public async Task SaveAsync(Issue issue)
        {
            await Context.Set<Issue>().AddAsync(issue);
            
            await Context.SaveChangesAsync();
        }
    }
}