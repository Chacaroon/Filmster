﻿using AutoMapper;
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
using BLL.DTOs.Films;
using BLL.DTOs.Filters;
using BLL.Services.FilmFilters;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Abstractions.BLL.DTOs.Actors;
using SharedKernel.Abstractions.BLL.DTOs.Genres;
using SharedKernel.Abstractions.BLL.DTOs.Producers;
using SharedKernel.Exceptions;

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

		public IFilmsResponseDTO GetAll(IFilmsFilters filters, string orderBy)
		{
			var response = new FilmsResponseDTO();

			var filmsQuery = _filmRepository.GetAll()
											.AsNoTracking();

			FilmFiltersProvider.FilterFilms(ref filmsQuery, filters);

			var films = filmsQuery.ToList();

			response.Films = Mapper.Map<IEnumerable<IFilmDTO>>(films);

			// TODO: Refactor adding filters to FilmResponseDTOs
			response.Filters = new FiltersDTO
			{
				Genres = films.SelectMany(f => f.FilmGenres.Select(fg => fg.Genre)).Distinct().Select(Mapper.Map<IGenreDTO>),
				Producers = films.SelectMany(f => f.FilmProducers.Select(fp => fp.Producer)).Distinct().Select(Mapper.Map<IProducerDTO>),
				Actors = films.SelectMany(f => f.FilmActors.Select(fa => fa.Actor)).Distinct().Select(Mapper.Map<IActorDTO>)
			};

			return response;
		}

		public IFilmDTO GetById(long id)
		{
			return Mapper.Map<IFilmDTO>(_filmRepository.FindById(id));
		}

		public IEnumerable<IFilmDTO> FindByTitle(string query)
		{
			return Mapper.Map<IEnumerable<IFilmDTO>>(_filmRepository
														 .GetAll(f => EF.Functions.Like(
																			f.Title.ToLower(), 
																			$"%{query}%".ToLower())));
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

			if (dto.ProducerIds != null)
				newFilm.FilmProducers =
					dto.ProducerIds.Select(id => new FilmProducer { ProducerId = id, Film = newFilm }).ToList();

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
