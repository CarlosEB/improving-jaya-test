using Newtonsoft.Json.Linq;
using System;

namespace Jaya.Application.Tools
{
    public static class Extension
    {
        public static int ToNumber(this JToken toConvert)
        {
            int.TryParse(toConvert.ToString(), out int result);

            return result;
        }

        public static DateTime ToDateTime(this JToken toConvert)
        {
            DateTime.TryParse(toConvert.ToString(), out DateTime result);

            return result;
        }
    }
}