using BookingSystem.Business.Interfaces;
using BookingSystem.DTOs.Search;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.Controllers
{
	/// <summary>
	/// API controller responsible for handling travel search requests
	/// </summary>
	[Route("api/[controller]")]
	[ApiController]
	public class SearchController : ControllerBase
	{
		private readonly ISearchService _searchService;

		/// <summary>
		/// Initializes a new instance of the SearchController with the provided search service
		/// </summary>
		public SearchController(ISearchService searchService)
		{
			_searchService = searchService;
		}

		/// <summary>
		/// Performs a search for available travel options based on the provided request
		/// </summary>
		[Authorize]
		[HttpPost]
		public async Task<ActionResult<SearchResponse>> Search([FromBody] SearchRequest request)
		{
			SearchResponse response = await _searchService.SearchAsync(request);
			return Ok(response);
		}
	}
}
