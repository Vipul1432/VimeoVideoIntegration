using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VimeoVideoTest2.Services;

namespace VimeoVideoTest2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VimeoController : ControllerBase
    {
        private readonly IVimeoService _vimeoService;

        public VimeoController(IVimeoService vimeoService)
        {
            _vimeoService = vimeoService;
        }

        [HttpGet("private-channel-videos")]
        public async Task<IActionResult> GetPrivateChannelVideos([FromQuery]string query)
        {
            long channelId = 1892158;
            var videos = await _vimeoService.GetPrivateChannelVideosAsync(channelId, query);
            return Ok(videos);
        }
    }
}