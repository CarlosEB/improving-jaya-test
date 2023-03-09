

using Jaya.Application.Mappers;
using Jaya.Application.ViewModels;
using Jaya.Domain.Issues.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jaya.Application.Services
{
    public class IssueService : IIssueService
    {

        private IIssueRepository _repo;

        public IssueService(IIssueRepository repo)
        {
            _repo = repo;

        }

        public async Task<IssueViewModel> GetLastEventAsync(long number)
        {
            return IssueViewModelMapper.MapIssue(await _repo.GetLastEventAsync(number));
        }

        public async Task<IList<IssueViewModel>> GetAllEventsAsync(long number)
        {
            return IssueViewModelMapper.MapIssues(await _repo.GetAllEventsAsync(number));
        }

        public async Task SaveAsync(object payload)
        {

            Issue model = IssuemodelMapper.Map(payload);

            await _repo.SaveAsync(model);

        }
    }
}
