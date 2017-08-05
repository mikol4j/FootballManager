using AutoMapper;
using Core.Domain;
using Infrastructure.Dto;
using System;
using System.Collections.Generic;
using System.Text;



namespace Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDto>();
                cfg.CreateMap<Team, TeamDto>();
            })
            .CreateMapper();

    }
}
