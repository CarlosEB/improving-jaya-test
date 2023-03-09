using System.Collections.Generic;

namespace Jaya.Domain.Issues.Interfaces
{
    public interface IIssueRepository
    {
        IEnumerable<Issue> GetAllEvents(long number);

        Issue GetLastEvent(long number);

        void Save(Issue taskModel);
    }
}
