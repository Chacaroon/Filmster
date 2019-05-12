using AutoMapper;
using DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SharedKernel.Abstractions.BLL.DTOs.Films;
using SharedKernel.Abstractions.BLL.Services;
using SharedKernel.Abstractions.DAL.Repositories;
using SharedKernel.Abstractions.PL.ViewModels.Films;
using SharedKernel.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Services.FilmFilters;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
	public class FilmService : IFilmService
	{
		private readonly IRepository<Film> _filmRepository;
		private readonly UserManager<User> _userManager;
		private readonly HttpContext _httpContext;

		public FilmService(IRepository<Film> filmRepository, UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
		{
			_filmRepository = filmRepository;
			_userManager = userManager;
			_httpContext = httpContextAccessor.HttpContext;
		}

		public IEnumerable<IFilmDTO> GetAll(IFilmsFilters filters, string orderBy)
		{
			var filmsQuery = _filmRepository.GetAll()
											//.Take(10)
											.AsNoTracking();

			filmsQuery = FilmFiltersProvider.FilterFilms(filmsQuery, filters);

			return Mapper.Map<IEnumerable<IFilmDTO>>(filmsQuery);
		}

		public IFilmDTO GetById(long id)
		{
			return Mapper.Map<IFilmDTO>(_filmRepository.FindById(id));
		}

		public async Task<long> Add(IAddFilmDTO dto)
		{
			var film = Mapper.Map<Film>(dto);

			film.UserId = (await _userManager.FindByNameAsync(_httpContext.User.Identity.Name)).Id;

			_filmRepository.Add(film);

			return film.Id;
		}
	}
}
