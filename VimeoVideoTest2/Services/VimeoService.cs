using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace VimeoVideoTest2.Services
{
    public class VimeoService :IVimeoService
    {
        private readonly HttpClient _httpClient;

        public VimeoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://api.vimeo.com/");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "50112eb714ef47dcbb89f13858047fc9");
        }

        public async Task<List<VideoData>> GetPrivateChannelVideosAsync(long channelId, string query)
        {
            var response = await _httpClient.GetAsync($"channels/{channelId}/videos");
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var responseObject = JsonConvert.DeserializeObject<ApiResponse>(jsonResponse);
            var data = responseObject.data.ToString();
            var videos = JsonConvert.DeserializeObject<List<VideoData>>(data);

            var filteredVideos = videos.Where(v => v.Name.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0).ToList();

            return filteredVideos;
        }
    }
    public class ApiResponse
    {
        public int total { get; set; }
        public int page { get; set; }
        public int per_page { get; set; }
        public Paging paging { get; set; }
        public object data { get; set; }
    }

    public class Paging
    {
        public object next { get; set; }
        public object previous { get; set; }
        public string first { get; set; }
        public string last { get; set; }
    }
    public class VideoData
    {
        [JsonProperty(PropertyName = "uri")]
        public string Uri { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "link")]
        public string Link { get; set; }

        [JsonProperty(PropertyName = "player_embed_url")]
        public string PlayerEmbedUrl { get; set; }

        [JsonProperty(PropertyName = "duration")]
        public int Duration { get; set; }

        [JsonProperty(PropertyName = "width")]
        public int Width { get; set; }

        [JsonProperty(PropertyName = "language")]
        public string Language { get; set; }

        [JsonProperty(PropertyName = "height")]
        public int Height { get; set; }

        [JsonProperty(PropertyName = "embed")]
        public Embed Embed { get; set; }
    }

    public class Embed
    {
        [JsonProperty(PropertyName = "html")]
        public string Html { get; set; }
    }

}
