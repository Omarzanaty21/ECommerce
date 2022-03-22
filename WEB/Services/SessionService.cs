
using Newtonsoft.Json;
using WEB.Models;

namespace WEB.Services
{
    public static class SessionService 
    {
        public static int ExistedCartItemIndex(int id, ISession session)
        {
            var cart = SessionService.GetCartFromJson<CartItem>(session, "cart");
            for(int i = 0; i < cart.Count(); i++)
            {
                if(cart[i].Product.Id == id)
                {
                    return i;
                }
            }
            return -1;
        }
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