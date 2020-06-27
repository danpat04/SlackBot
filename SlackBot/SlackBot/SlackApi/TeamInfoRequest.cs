using System.Net.Http;
using System.Text.Json.Serialization;

namespace SlackBot.SlackApi
{
    public class Team
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    public class TeamInfoRequest : SlackApiRequest<TeamInfoRequest.Response>
    {
        public class Response : SlackApiResponse
        {
            [JsonPropertyName("team")]
            public Team Team { get; set; }
        }

        public TeamInfoRequest() : base(HttpMethod.Get, "api/team.info") { }
    }
}
