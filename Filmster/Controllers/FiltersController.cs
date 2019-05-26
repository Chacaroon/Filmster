using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Abstractions.BLL.DTOs.Filters;
using SharedKernel.Abstractions.BLL.Services;

namespace Filmster.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FiltersController : ControllerBase
    {
		private readonly IFilterService _filterService;

		public FiltersController(IFilterService filterService)
		{
			_filterService = filterService;
		}

		[HttpGet("Search/{filter}/Like/{value}")]
		public ActionResult<IEnumerable<IFilterDTO>> Search(string filter, string value)
		{
			var result = _filterService.SearchFilters(filter, value);

			if (result == null)
				return BadRequest();

			return Ok(Mapper.Map<IEnumerable<IFilterDTO>>(result));
		}
    }
}