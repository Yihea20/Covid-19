using Accounts_5.Data;
using Accounts_5.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accounts_5.ConfigServices
{
    public class MapperInitilizer:Profile
    {
        public MapperInitilizer()
        {
            CreateMap<News, NewsDTO>().ReverseMap();
            CreateMap<Vaccination, VaccinationDTO>().ReverseMap();
            CreateMap<VaccinationCenter, VaccinationCenterDTO>().ReverseMap();
        }
    }
}
