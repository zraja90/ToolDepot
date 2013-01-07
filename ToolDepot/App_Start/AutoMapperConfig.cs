using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using ToolDepot.Mappers;

namespace ToolDepot.App_Start
{
    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(x => x.AddProfile<MappingProfile>());
        }
    }
}