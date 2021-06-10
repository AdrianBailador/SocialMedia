using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.DTOs;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infrastructure.Repositorios;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.APi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        public PostController(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            var posts = await _postRepository.GetPosts();
            var postsDto = _mapper.Map<IEnumerable<PostDto>>(posts);
            return Ok(postsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            var post = await _postRepository.GetPost(id);
            var postsDto = _mapper.Map<IEnumerable<PostDto>>(post);
            return Ok(postsDto);
        }

        [HttpPost]
        public async Task<IActionResult> Post(PostDto postsDto)
        {
            var post = _mapper.Map<Post>(postsDto);
            await _postRepository.InsertPost(post);
            return Ok(post);
        }
    }
}
