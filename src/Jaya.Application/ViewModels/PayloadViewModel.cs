using System.Text.Json.Serialization;

namespace Jaya.Application.ViewModels
{
    public class PayloadViewModel
    {
        public string Action { get; set; }

        public IssueBaseViewModel Issue { get; set; }
    }
}
