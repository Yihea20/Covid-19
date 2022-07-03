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
            CreateMap<News, CreateNewsDTO>().ReverseMap();
            CreateMap<Vaccination, VaccinationDTO>().ReverseMap();
            CreateMap < Vaccination, CreateVaccinationDTO>().ReverseMap();
            CreateMap<Vaccination, Vaccination_For_Center>().ReverseMap();
            CreateMap<Person_Vaccination, Person_VaccinationDTO>().ReverseMap();
            CreateMap<Person, Person_For_Vaccination>().ReverseMap();
            CreateMap<VaccinationCenter, VaccinationCenterDTO>().ReverseMap();
            CreateMap<VaccinationCenter, CreateVaccinationCenterDTO>().ReverseMap();
            //CreateMap<VaccinationCenter, UpadateVaccinationCenterDTO>().ReverseMap();
            CreateMap<VaccinationCenter, Center_For_Vaccination>().ReverseMap();
            //CreateMap<Vaccination_VaccinationCenter, CreatVaccination_VaccinationCenterDTO>().ReverseMap();
            CreateMap<VaccinationCenter_Vaccination, Vaccinaion_vaccinationCenterDTO>().ReverseMap();
            CreateMap<Person, PersonDTO>().ReverseMap();
            CreateMap<Person_VaccinationCenter, Person_VcccinationCenterDTO>().ReverseMap();
            CreateMap<Person_VaccinationCenter, Just_CenterDTO>().ReverseMap();
        }
    }
}
