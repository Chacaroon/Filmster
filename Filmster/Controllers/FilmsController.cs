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
using SharedKernel.Exceptions;

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
		public ActionResult<FilmsResponseViewModel> Get([FromQuery] FilmsFiltersQuery filters, [FromQuery] string orderBy)
		{
			var response = Mapper.Map<FilmsResponseViewModel>(_filmService.GetAll(filters, orderBy));

			return Ok(response);
		}

		[HttpGet("{query}")]
		public ActionResult<IEnumerable<FilmViewModel>> Get(string query)
		{
			return Ok(Mapper.Map<IEnumerable<FilmViewModel>>(_filmService.FindByTitle(query)));
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

			return CreatedAtAction(nameof(Get), new { Id = filmId }, null);
		}

		// PUT: api/Films/5
		[HttpPut]
		public void Put([FromBody] UpdateFilmViewModel model)
		{
			_filmService.Update(Mapper.Map<IUpdateFilmDTO>(model));
		}

		// DELETE: api/ApiWithActions/5
		[HttpDelete("{id}")]
		public IActionResult Delete(long id)
		{

			try
			{
				_filmService.Delete(id);
			}
			catch (AccessDenyException)
			{
				return Forbid();
			}

			return Ok();
		}
	}
}
