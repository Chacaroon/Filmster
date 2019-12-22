using AutoMapper;
using BLL.DTOs.Films;
using DAL.Entities;
using SharedKernel.Abstractions.BLL.DTOs.Actors;
using SharedKernel.Abstractions.BLL.DTOs.Films;
using SharedKernel.Abstractions.BLL.DTOs.Genres;
using System.Collections.Generic;
using System.Linq;
using SharedKernel.Abstractions.BLL.DTOs.Directors;

namespace BLL.IoC.Profiles
{
	class FilmMappingProfile : Profile
	{
		public FilmMappingProfile()
		{

			CreateMap<IAddFilmDTO, Film>()
				.ForMember(film => film.User, opt => opt.Ignore())
				.ForMember(film => film.UserId, opt => opt.Ignore())

				.AfterMap((dto, film) =>
							  film.FilmActors = dto.ActorIds.Select(id => new FilmActor() { ActorId = id, Film = film })
												   .ToList())
				.AfterMap((dto, film) =>
							  film.FilmGenres = dto.GenreIds.Select(id => new FilmGenre() { GenreId = id, Film = film })
												   .ToList());

			CreateMap<IUpdateFilmDTO, Film>()
				.ForMember(film => film.User, opt => opt.Ignore())
				.ForMember(film => film.UserId, opt => opt.Ignore())

				.ForMember(film => film.FilmActors, opt => opt.Ignore())
				.ForMember(film => film.FilmGenres, opt => opt.Ignore());

			CreateMap<Film, IFilmDTO>()
				.ForMember(dto => dto.Genres, opt => opt.MapFrom(film => film.FilmGenres.Select(fg => fg.Genre).ToList()))
				.ForMember(dto => dto.Actors, opt => opt.MapFrom(film => film.FilmActors.Select(fa => fa.Actor).ToList()));

			CreateMap<IEnumerable<Film>, IFilmsResponseDTO>()
				.ForMember(res => res.Films, opt => opt.MapFrom(films => films))
				.AfterMap((films, dto) =>
				{
					dto.Filters = new FiltersDTO()
					{
						Genres = films
							.SelectMany(f => f.FilmGenres.Select(fg => fg.Genre))
							.Distinct()
							.OrderBy(x => x.Name)
							.Select(Mapper.Map<IGenreDTO>),
						Actors = films
							.SelectMany(f => f.FilmActors.Select(fa => fa.Actor))
							.Distinct()
							.OrderBy(x => x.Name)
							.Select(Mapper.Map<IActorDTO>),
						Directors = films
							.Select(f => f.Director)
							.Distinct()
							.OrderBy(x => x.Name)
							.Select(Mapper.Map<IDirectorDTO>)
					};
				});
		}
	}
}
