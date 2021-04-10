using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infrastructure.Repositorios;
using System.Threading.Tasks;

namespace SocialMedia.APi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepository;
        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            var posts = await _postRepository.GetPosts();
            return Ok(posts);
        }
    }
}
