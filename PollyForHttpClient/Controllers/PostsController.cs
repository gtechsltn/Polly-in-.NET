using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PollyForHttpClient.Services;

namespace PollyForHttpClient.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly ExternalApiService _externalApiService;

        public PostsController(ExternalApiService externalApiService)
        {
            _externalApiService = externalApiService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            try
            {
                var posts = await _externalApiService.GetPostsAsync();
                return Ok(posts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error fetching posts: {ex.Message}");
            }
        }
    }
}
