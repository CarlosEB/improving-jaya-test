using Jaya.Domain.Issues.Interfaces;
using Jaya.Application.ViewModels;

namespace Jaya.Application.Mappers
{
    public class IssueModelMapper
    {
        public static Issue Map(PayloadViewModel payload)
        {
            return new 
                Issue(payload.Issue.Number, payload.Action, payload.Issue.CreatedAt, payload.Issue.UpdatedAt, payload.Issue.Title);
        }
    }
}
