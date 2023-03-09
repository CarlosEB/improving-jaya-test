using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jaya.Domain.Issues.Interfaces
{
    public interface IIssueRepository
    {
        Task<IEnumerable<Issue>> GetAllEventsAsync(long number);

        Task<Issue> GetLastEventAsync(long number);

        Task SaveAsync(Issue taskModel);
    }
}
