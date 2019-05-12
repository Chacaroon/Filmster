using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Filmster.ViewModels.Films;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Abstractions.BLL.DTOs.Films;
using SharedKernel.Abstractions.BLL.Services;

namespace Filmster.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class FilmsController : ControllerBase
	{
		private readonly IFilmService _filmService;

		public FilmsController(IFilmService filmService)
		{
			_filmService = filmService;
		}

		// GET: api/Films
		[HttpGet]
		public ActionResult<IEnumerable<FilmViewModel>> Get([FromQuery] FilmsFiltersQuery filters, [FromQuery] string orderBy)
		{
			return Ok(Mapper.Map<IEnumerable<FilmViewModel>>(_filmService.GetAll(filters, orderBy)));
		}

		// GET: api/Films/5
		[HttpGet("{id}", Name = "Get")]
		public ActionResult<FilmViewModel> Get(int id)
		{
			return Ok(Mapper.Map<FilmViewModel>(_filmService.GetById(id)));
		}

		// POST: api/Films
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] AddFilmViewModel model)
		{
			long filmId;

			try
			{
				filmId = await _filmService.Add(Mapper.Map<IAddFilmDTO>(model));
			}
			catch (FormatException)
			{
				return BadRequest();
			}

			return CreatedAtAction("Get", new { FilmId = filmId });
		}

		// PUT: api/Films/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE: api/ApiWithActions/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
