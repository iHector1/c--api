using System.Text.Json;
using WebApplication1.DTOs;

namespace WebApplication1.Services
{
    public class PostsService:IPostsService
    {
        private HttpClient _httpClient;

        public PostsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<PostsDto>> Get()
        {

            var result = await _httpClient.GetAsync(_httpClient.BaseAddress);

            var body = await result.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var posts = JsonSerializer.Deserialize<IEnumerable<PostsDto>>(body, options);
            return posts;
        }
    }
}
