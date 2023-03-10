using Jaya.Application.ViewModels;
using Jaya.Domain.Issues.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Jaya.Application.Mappers
{
    public class IssueViewModelMapper
    {
        public static IList<IssueViewModel> MapIssues(IEnumerable<Issue> issues)
        {
            return issues.Select(s => new IssueViewModel(s)).ToList();
        }

        public static IssueViewModel MapIssue(Issue issue)
        {
            return new IssueViewModel(issue);
        }
    }
}