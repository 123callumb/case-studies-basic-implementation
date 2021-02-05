using Microsoft.AspNetCore.Http;
using Services.DTOs;
using System.Text.Json;

namespace Services.SessionManagement.Helpers
{
    public static class SessionHelper
    {
        // This is used for both internal and external, sharing this prevents the
        // ability to be logged into both accounts at the same time.
        public static string UserSessionKey = "CS_UserSessionKey";
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonSerializer.Deserialize<T>(value);
        }

        public static bool HasUserSession(this ISession session)
        {
            if (session.TryGetValue(UserSessionKey, out byte[] learnerSession))
                return learnerSession.Length > 0;
            return false;
        }
        public static IUserDTO GetUserSession(this ISession session)
        {
            return session.HasUserSession() ? session.Get<IUserDTO>(UserSessionKey) : null;
        }
    }
}