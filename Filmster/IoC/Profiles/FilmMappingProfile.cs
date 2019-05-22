using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DAL.Entities;
using Filmster.ViewModels.Films;
using SharedKernel.Abstractions.BLL.DTOs.Films;

namespace Filmster.IoC.Profiles
{
	public class FilmMappingProfile : Profile
	{
		public FilmMappingProfile()
		{
			CreateMap<AddFilmViewModel, IAddFilmDTO>()
				.ForMember(dto => dto.Duration,
				           opt => opt.MapFrom(model => TimeSpan.Parse(model.Duration)));

			CreateMap<UpdateFilmViewModel, IUpdateFilmDTO>()
				.ForMember(dto => dto.Duration,
				           opt => opt.MapFrom(model => TimeSpan.Parse(model.Duration)));
		}
	}
}
