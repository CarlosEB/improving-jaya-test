using Jaya.Domain.Issues.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Jaya.Application.Mappers
{
    public class IssuemodelMapper
    {
        public static Issue Map(object payload)
        {
            var result = (JObject)JsonConvert.DeserializeObject(payload.ToString());

            var action = result["action"].ToString();
            var createdAt = DateTime.Parse(result["issue"]["created_at"].ToString());
            var updatedAt = DateTime.Parse(result["issue"]["updated_at"].ToString());
            var number = int.Parse(result["issue"]["number"].ToString());
            var title = result["issue"]["title"].ToString();

            return new Issue
            { 
                Action = action,
                CreatedAt = createdAt,
                UpdatedAt = updatedAt,
                Number = number,
                Title = title
            };
        }
    }
}
