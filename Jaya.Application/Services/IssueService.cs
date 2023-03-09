

using Jaya.Application.Mappers;
using Jaya.Application.ViewModels;
using Jaya.Domain.Issues.Interfaces;
using System.Collections.Generic;

namespace Jaya.Application.Services
{
    public class IssueService : IIssueService
    {

        private IIssueRepository _repo;

        public IssueService(IIssueRepository repo)
        {
            _repo = repo;

        }

        public IssueViewModel GetLastEvent(long number)
        {
            return IssueViewModelMapper.MapIssue(_repo.GetLastEvent(number));
        }

        public IEnumerable<IssueViewModel> GetAllEvents(long number)
        {
            return IssueViewModelMapper.MapIssues(_repo.GetAllEvents(number));
        }

        public void Save(object payload)
        {

            Issue model = IssuemodelMapper.Map(payload);

            _repo.Save(model);

        }
    }
}
