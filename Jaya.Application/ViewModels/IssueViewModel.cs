using Jaya.Domain.Issues.Interfaces;
using System;

namespace Jaya.Application.ViewModels
{
    public class IssueViewModel
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


        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public int Number { get; set; }

        public string Action { get; set; }

        public string Title { get; set; }
    }
}
