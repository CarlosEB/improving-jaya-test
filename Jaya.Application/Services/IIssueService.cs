using Jaya.Application.ViewModels;
using System.Collections.Generic;

namespace Jaya.Application.Services
{
    public interface IIssueService
    {
        void Save(object payload);
        IssueViewModel GetLastEvent(long number);

        IEnumerable<IssueViewModel> GetAllEvents(long number);
    }
}
