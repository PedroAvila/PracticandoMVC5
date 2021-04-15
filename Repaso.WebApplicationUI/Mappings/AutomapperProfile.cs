using AutoMapper;
using Repaso.EntidadesDominio;
using Repaso.WebApplicationUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repaso.WebApplicationUI.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Empleado, EmpleadoViewModel>().ReverseMap();
        }
    }
}