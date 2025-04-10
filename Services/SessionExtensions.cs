using System.Text.Json;

namespace ausemartweb.Services;

public static class SessionExtensions
{
    public static void SetJson<T>(this ISession session, string key, T value)
    {
        session.SetString(key, JsonSerializer.Serialize(value));
    }

    public static T? GetJson<T>(this ISession session, string key)
    {
        var sessionData = session.GetString(key);
        return sessionData == null ? default : JsonSerializer.Deserialize<T>(sessionData);
    }

    public static string GetCartId(this ISession session)
    {
        const string cartIdKey = "CartId";
        
        string? cartId = session.GetString(cartIdKey);
        
        if (string.IsNullOrEmpty(cartId))
        {
            cartId = Guid.NewGuid().ToString();
            session.SetString(cartIdKey, cartId);
        }
        
        return cartId;
    }
}