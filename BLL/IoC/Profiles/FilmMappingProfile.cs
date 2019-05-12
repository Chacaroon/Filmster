using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using DAL.Entities;
using SharedKernel.Abstractions.BLL.DTOs.Films;

namespace BLL.IoC.Profiles
{
	class FilmMappingProfile : Profile
	{
		public FilmMappingProfile()
		{

			CreateMap<IAddFilmDTO, Film>()
				.ForMember(film => film.User, opt => opt.Ignore())
				.ForMember(film => film.UserId, opt => opt.Ignore())
				.ForMember(film => film.FilmActors, opt => opt.Ignore())
				.ForMember(film => film.FilmGenres, opt => opt.Ignore())
				.ForMember(film => film.FilmProducers, opt => opt.Ignore())

				.AfterMap((dto, film) => film.FilmActors = dto.ActorIds.Select(id => new FilmActor() { ActorId = id, Film = film }).ToList())
				.AfterMap((dto, film) => film.FilmGenres = dto.GenreIds.Select(id => new FilmGenre() { GenreId = id, Film = film }).ToList())
				.AfterMap((dto, film) => film.FilmProducers = dto.ProducerIds.Select(id => new FilmProducer() { ProducerId = id, Film = film }).ToList());


			CreateMap<Film, IFilmDTO>()
					.ForMember(dto => dto.Genres, opt => opt.MapFrom(film => film.FilmGenres.Select(fg => fg.Genre).ToList()))
					.ForMember(dto => dto.Actors, opt => opt.MapFrom(film => film.FilmActors.Select(fa => fa.Actor).ToList()))
					.ForMember(dto => dto.Producers, opt => opt.MapFrom(film => film.FilmProducers.Select(fp => fp.Producer).ToList()));
		}
	}
}
