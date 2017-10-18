using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vinyl.Models;
using Vinyl.UI.Dtos;
using Vinyl.UI.ViewModels;

namespace Vinyl.UI.Mappers
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(
            config =>
            {
		      config.CreateMap<Artist, ArtistViewModel>();
	            config.CreateMap<ArtistViewModel, Artist>();

			config.CreateMap<Artist, ArtistDto>();
			config.CreateMap<ArtistDto, Artist>();
		});
        }
    }
}