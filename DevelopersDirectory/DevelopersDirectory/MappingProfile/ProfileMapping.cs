using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using DevelopersDirectory.BindingModels;
using DevelopersDirectory.Models;

namespace DevelopersDirectory.MappingProfile
{
    public class ProfileMapping : Profile
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Developer, DeveloperDirectoryBindingModel>().ReverseMap();
                cfg.CreateMap<IQueryable<Developer>, IQueryable<DeveloperDirectoryBindingModel>>();
                cfg.CreateMap<DeveloperDirectoryBindingModel, Developer>().ForMember(v => v.DeveloperId, opt => opt.Ignore());
            });
        }
    }
}