using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace SlackBot
{
    public static class Utils
    {
        public static string UserIdToString(string userId)
        {
            return $"<@{userId}>";
        }

        private static readonly Regex UserIdPattern = new Regex(@"^<@(?<userId>[A-Z0-9]+)\|[a-zA-Z0-9' \.\-]+>$");
        private static readonly Regex PureIdPattern = new Regex(@"^@(?<userId>[A-Z0-9]+)$");

        public static string StringToUserId(string text)
        {
            if (TryGetUserId(text, UserIdPattern, out var userId) || TryGetUserId(text, PureIdPattern, out userId))
            {
                return userId;
            }
            
            return null;
        }

        private static bool TryGetUserId(string text, Regex pattern, [NotNullWhen(true)] out string userId)
        {
            var matches = pattern.Matches(text);
            foreach (Match match in matches)
            {
                if (match.Groups.TryGetValue("userId", out var value))
                {
                    userId = value.Value;
                    return true;
                }
            }

            userId = null;
            return false;
        }
    }
}
