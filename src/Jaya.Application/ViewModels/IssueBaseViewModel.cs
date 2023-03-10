using System;
using System.Text.Json.Serialization;

namespace Jaya.Application.ViewModels
{
    public class IssueBaseViewModel
    {
        public int Number { get; set; }
        public string Title { get; set; }
        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}