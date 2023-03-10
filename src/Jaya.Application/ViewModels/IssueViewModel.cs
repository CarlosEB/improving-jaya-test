using Jaya.Domain.Issues.Interfaces;

namespace Jaya.Application.ViewModels
{
    public class IssueViewModel : IssueBaseViewModel
    {
        public IssueViewModel()
        { }

        public IssueViewModel(Issue issue)
        {
            if (issue != null)
            {

                CreatedAt = issue.CreatedAt;
                UpdatedAt = issue.UpdatedAt;
                Number = issue.Number;
                Action = issue.Action;
                Title = issue.Title;
            }
        }

        public string Action { get; set; }
    }
}
