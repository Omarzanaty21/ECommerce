
using Newtonsoft.Json;
using WEB.Models;

namespace WEB.Services
{
    public static class SessionService 
    {
        public static void SetCartAsJson<T>(ISession session, string key, List<T> cart)
        {
            session.SetString(key, JsonConvert.SerializeObject(cart));
        }
        public static List<T> GetCartFromJson<T>(ISession session, string key)
        {
            var keyValue = session.GetString(key);

            if(!string.IsNullOrEmpty(keyValue))
            {
                return JsonConvert.DeserializeObject<List<T>>(keyValue);
            }
            return null;
        }
    }
}