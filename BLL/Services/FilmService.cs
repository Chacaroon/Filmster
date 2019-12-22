using AutoMapper;
using DAL.Entities;
using DAL.QueryParams;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SharedKernel.Abstractions.BLL.DTOs.Films;
using SharedKernel.Abstractions.BLL.Services;
using SharedKernel.Abstractions.DAL.Repositories;
using SharedKernel.Abstractions.PL.ViewModels.Films;
using SharedKernel.Exceptions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Services
{
	public class FilmService : IFilmService
	{
		private readonly IRepository<Film, FilmParams> _filmRepository;
		private readonly UserManager<User> _userManager;
		private readonly HttpContext _httpContext;

		public FilmService(IRepository<Film, FilmParams> filmRepository, UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
		{
			_filmRepository = filmRepository;
			_userManager = userManager;
			_httpContext = httpContextAccessor.HttpContext;
		}

		public IFilmsResponseDTO GetAll(IFilmsFilters filters, string orderBy, string searchString = "", int page = 1)
		{
			var filmsQuery = _filmRepository.GetAll(new FilmParams
			{
				Title = searchString ?? "",
				GenresFilter = filters.GenreIds ?? new List<long>(),
				ActorsFilter = filters.ActorIds ?? new List<long>(),
				DirectorsFilter = filters.DirectorIds ?? new List<long>()
			});

			var response = Mapper.Map<IFilmsResponseDTO>(filmsQuery);

			return response;
		}

		public IFilmDTO GetById(long id)
		{
			return Mapper.Map<IFilmDTO>(_filmRepository.FindById(id));
		}

		public async Task<long> Add(IAddFilmDTO dto)
		{
			var film = Mapper.Map<Film>(dto);

			film.UserId = (await GetCurrentUserAsync()).Id;

			_filmRepository.Add(film);

			return film.Id;
		}

		public void Update(IUpdateFilmDTO dto)
		{
			var oldFilm = _filmRepository.FindById(dto.Id);

			if (oldFilm.User.NormalizedUserName != _httpContext.User.Identity.Name.ToUpper())
				throw new AccessDenyException();

			var newFilm = Mapper.Map(dto, oldFilm);

			if (dto.ActorIds != null)
				newFilm.FilmActors = dto.ActorIds.Select(id => new FilmActor { ActorId = id, Film = newFilm }).ToList();

			if (dto.GenreIds != null)
				newFilm.FilmGenres = dto.GenreIds.Select(id => new FilmGenre { GenreId = id, Film = newFilm }).ToList();

			_filmRepository.Update(newFilm);
		}

		public void Delete(long id)
		{
			var film = _filmRepository.FindById(id);

			if (film == null)
				throw new KeyNotFoundException();

			if (film.User.NormalizedUserName != _httpContext.User.Identity.Name.ToUpper())
				throw new AccessDenyException();

			_filmRepository.Delete(film);
		}

		private Task<User> GetCurrentUserAsync() => _userManager.FindByNameAsync(_httpContext.User.Identity.Name);
	}
}
