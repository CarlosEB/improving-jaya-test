using Jaya.Application.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jaya.Application.Services
{
    public interface IIssueService
    {
        Task SaveAsync(object payload);
        Task<IssueViewModel> GetLastEventAsync(long number);

        Task<IList<IssueViewModel>> GetAllEventsAsync(long number);
    }
}
