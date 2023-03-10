using System;

namespace Jaya.Domain.Issues.Interfaces
{
    public class Issue
    {
        public Issue()
        { }

        public Issue(int number, string action, DateTime created, DateTime? updated, string title)
        {
            CreatedAt = created;
            UpdatedAt = updated;
            Number = number;
            Action = action;
            Title = title;
        }

        public long Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public int Number { get; set; }

        public string Action { get; set; }

        public string Title { get; set; }
    }
}
