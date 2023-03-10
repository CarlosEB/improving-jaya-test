
using Jaya.Application.ViewModels;
using System;

namespace Jaya.Test.Fakes
{
    public class PayloadViewModelBuilder
    {
        public static PayloadViewModel Build(string action, int number, string title, DateTime created, DateTime? updated)
        {
            return new PayloadViewModel
            {
                Action = action,
                Issue = new IssueBaseViewModel
                {
                    Number= number,
                    Title = title,
                    CreatedAt = created,
                    UpdatedAt = updated
                }
            };
        }

    }
}
