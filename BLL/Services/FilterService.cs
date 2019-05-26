using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Abstractions.BLL.DTOs.Filters;
using SharedKernel.Abstractions.BLL.DTOs.Genres;
using SharedKernel.Abstractions.BLL.Services;
using SharedKernel.Abstractions.DAL.Repositories;

namespace BLL.Services
{
	public class FilterService : IFilterService
	{
		private readonly IRepository<Genre> _genresRepository;
		private readonly IRepository<Actor> _actorsRepository;
		private readonly IRepository<Director> _directorsRepository;

		public FilterService(
			IRepository<Genre> genresRepository,
			IRepository<Actor> actorsRepository,
			IRepository<Director> directorsRepository)
		{
			_genresRepository = genresRepository;
			_actorsRepository = actorsRepository;
			_directorsRepository = directorsRepository;
		}

		public IEnumerable<IFilterDTO> SearchFilters(string filter, string value)
		{
			switch (filter)
			{
				case "genres":
					return GetGenreFilters(value);
				case "directors":
					return GetDirectorFilters(value);
				case "actors":
					return GetActorFilters(value);
			}

			return null;
		}

		private IEnumerable<IFilterDTO> GetGenreFilters(string value)
		{
			var filters = _genresRepository
				.GetAll(g => EF.Functions.Like(g.Name, $"%{value}%"));

			return Mapper.Map<IEnumerable<IFilterDTO>>(filters);
		}

		private IEnumerable<IFilterDTO> GetDirectorFilters(string value)
		{
			var filters = _directorsRepository
				.GetAll(d => EF.Functions.Like(d.Name, $"%{value}%"));

			return Mapper.Map<IEnumerable<IFilterDTO>>(filters);
		}

		private IEnumerable<IFilterDTO> GetActorFilters(string value)
		{
			var filters = _actorsRepository
				.GetAll(a => EF.Functions.Like(a.Name, $"%{value}%"));

			return Mapper.Map<IEnumerable<IFilterDTO>>(filters);
		}
	}
}
