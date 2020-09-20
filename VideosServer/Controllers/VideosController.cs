using Domain.Dtos;
using Domain.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace VideosServer.Controllers
{
    /// <summary>
    /// Controller is responsible for actions related to films (simple CRUD & with the possibility of filtering)
    /// </summary>
    /// <returns></returns>
    [Route("api/[controller]")]
    [ApiController]
    public class VideosController : ControllerBase
    {
        private IVideosService _videosService;

        public VideosController(IVideosService videoService)
        {
            _videosService = videoService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id) {
            var result = await _videosService.GetVideo(id);
            if (result.IsSuccessful)
            {
                return Ok(result.ObjectResult);
            }
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string searchValue, [FromQuery] int? page, [FromQuery] int? pageSize, 
            [FromQuery] short? ageGroup, [FromQuery] string videoType, [FromQuery(Name = "categories")] long[] categories, 
            [FromQuery] DateTime? availabilityFrom, [FromQuery] DateTime? availabilityTo)
        {
            var videosQueryOptions = new VideoQueryOptions()
            {
                SearchValue = searchValue,
                Page = page.GetValueOrDefault() > 0 ? page - 1 : 0,
                AgeGroup = ageGroup,
                VideoType = videoType,
                Categories = categories,
                AvailabilityFrom = availabilityFrom,
                AvailabilityTo = availabilityTo
            };

            if (pageSize.HasValue)
            {
                videosQueryOptions.PageSize = pageSize.Value;
            }

            var result = await _videosService.FindVideos(videosQueryOptions);
            return Ok(result.ObjectResult);
        }


        [HttpPost("{id}/categories")]
        public async Task<IActionResult> AddCategory(long id, VideoCategorySaveDto videoCategorySaveDto) {
            var result = await _videosService.AddCategoryToVideo(id, videoCategorySaveDto);

            if (result.IsSuccessful)
            {
                return Ok(result.ObjectResult);
            } else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpDelete("{id}/categories/{categoryId}")]
        public async Task<IActionResult> DeleteCategory(long id, long categoryId)
        {
            var result = await _videosService.DeleteCategoryVideo(id, categoryId);

            if (result.IsSuccessful)
            {
                return Ok(result.ObjectResult);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
    }
}
