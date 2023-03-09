using Jaya.Domain.Issues.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Jaya.Application.Tools;

namespace Jaya.Application.Mappers
{
    public class IssuemodelMapper
    {
        public static Issue Map(object payload)
        {
            var result = (JObject)JsonConvert.DeserializeObject(payload.ToString());

            var issue = result["issue"];

            var createdAt = issue["created_at"].ToDateTime();
            var updatedAt = issue["updated_at"].ToDateTime();
            var number = issue["number"].ToNumber();
            var title = issue["title"].ToString();
            var action = result["action"].ToString();

            return new Issue(number, action, createdAt, updatedAt, title);
        }
    }
}
