using BookingSystem.Business.Interfaces;
using BookingSystem.DTOs.Search;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SearchController : ControllerBase
	{
		private readonly ISearchService _searchService;

		public SearchController(ISearchService searchService)
		{
			_searchService = searchService;
		}

		[Authorize]
		[HttpPost]
		public async Task<ActionResult<SearchResponse>> Search([FromBody] SearchRequest request)
		{
			SearchResponse response = await _searchService.SearchAsync(request);
			return Ok(response);
		}
	}
}
