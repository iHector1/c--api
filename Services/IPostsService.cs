using WebApplication1.DTOs;

namespace WebApplication1.Services
{
    public interface IPostsService
    {
        public Task<IEnumerable<PostsDto>> Get();
    }
}
