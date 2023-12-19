using BusinessWorkManagementSystem.DataAccess.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace BusinessWorkManagementSystem
{
    public static class SessionExtensions
    {
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }

       
    }

    public class Common
    {
        
    }
}
