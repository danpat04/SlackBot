using Microsoft.AspNetCore.Authorization;

namespace SlackBot.SlackAuthentication
{
    public class SlackAuthorizeAttribute : AuthorizeAttribute
    {
        public SlackAuthorizeAttribute() : base("Slack") { }
    }
}
