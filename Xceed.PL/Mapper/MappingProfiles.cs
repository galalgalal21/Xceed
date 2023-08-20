using AutoMapper;
using System.Runtime;
using Xceed.DAL.Entities;
using Xceed.PL.Models;

namespace Xceed.PL.Mapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Employee, EmployeeVM>().ForMember(dest => dest.EmployeeLanguageLevels, opt => opt
            .MapFrom(src => src.EmployeeLanguageLevels.Select(i => i.Language_Level)
            .Select(a => a.name).ToList()))
            .ForMember(dest => dest.account, opt => opt.MapFrom(src => src.account.name))
            .ForMember(dest => dest.line_Of_Business, opt => opt.MapFrom(src => src.line_Of_Business.name))
            .ForMember(dest => dest.language, opt => opt.MapFrom(src => src.language.name)).ReverseMap();
            CreateMap<AddEditEmployeeVM, Employee>().ReverseMap();
            CreateMap<Account, AccountVM>().ReverseMap();
            CreateMap<Language, LanguageVM>().ReverseMap();
            CreateMap<Language_level, Language_levelVM>().ReverseMap();
            CreateMap<Line_of_Business, LineOfBusinessVM>().ReverseMap();
        }
    }
}
