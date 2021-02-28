using Microsoft.AspNetCore.Http;
using Services.AuthenticationManagement.Models;
using System.Text.Json;

namespace Services.SessionManagement.Helpers
{
    public static class SessionHelper
    {
        // This is used for both internal and external, sharing this prevents the
        // ability to be logged into both accounts at the same time.
        public static string UserSessionKey = "CS_UserSessionKey";
        /// <summary>
        /// Helper for setting custom objects in the session
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="session"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }
        /// <summary>
        /// Helper for getting custom session objects 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="session"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonSerializer.Deserialize<T>(value);
        }
        /// <summary>
        /// Bool checker to see of the current user has a logged in session for either
        /// an external or internal user. 
        /// </summary>
        /// <param name="session">Session context from a controller</param>
        /// <returns>Returns true if there is a user session and false if none was found</returns>
        public static bool HasUserSession(this ISession session)
        {
            if (session.TryGetValue(UserSessionKey, out byte[] userSession))
                return userSession.Length > 0;
            return false;
        }
        /// <summary>
        /// Used to see if their is a current user session stored in memory 
        /// </summary>
        /// <param name="session">Controller session contexxt</param>
        /// <returns>Returns an authenticated session if a user has an exisitng session or will return null if there is no user session</returns>
        public static AuthenticatedSession GetUserSession(this ISession session)
        {
            return session.HasUserSession() ? session.Get<AuthenticatedSession>(UserSessionKey) : null;
        }
    }
}