using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Entitites;

namespace API.Profiles
{
    public class MappingProfiles : Profile
    {
        protected MappingProfiles()
        {
            CreateMap<Address,AddressDto>()
            .ReverseMap()
            .ForMember(o => o.People,d => d.Ignore());

            CreateMap<Address,AddressDto>()
            .ReverseMap();

            CreateMap<City,CityDto>()
            .ReverseMap()
            .ForMember(o => o.People,d => d.Ignore());

            CreateMap<Country,CountryDto>()
            .ReverseMap()
            .ForMember(o => o.Departments,d => d.Ignore());
            
            CreateMap<Course,CourseDto>()
            .ReverseMap()
            .ForMember(o => o.Tuitions,d => d.Ignore())
            .ForMember(o => o.TrainerCourses,d => d.Ignore());

            CreateMap<Department,DepartmentDto>()
            .ReverseMap()
            .ForMember(o => o.Cities,d => d.Ignore());
            
            CreateMap<Genre,GenreDto>()
            .ReverseMap()
            .ForMember(o => o.People,d => d.Ignore());

            CreateMap<Person,PersonDto>()
            .ReverseMap()
            .ForMember(o => o.Addresses,d => d.Ignore())
            .ForMember(o => o.Tuitions,d => d.Ignore())
            .ForMember(o => o.TrainerCourses,d => d.Ignore());

            CreateMap<TrainerCourse,TrainerCourseDto>()
            .ReverseMap();

            CreateMap<Tuition,TuitionDto>()
            .ReverseMap();

            CreateMap<TypePerson,TypePersonDto>()
            .ReverseMap()
            .ForMember(o => o.People,d => d.Ignore());

        }
        
    }
}