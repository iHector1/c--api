using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        IPostsService _titlesServices;

        public PostsController(IPostsService titlesServices)
        {
            _titlesServices = titlesServices;
        }

        [HttpGet]
        public async Task<IEnumerable<PostsDto>> Get() =>
            await _titlesServices.Get();
    }
}
