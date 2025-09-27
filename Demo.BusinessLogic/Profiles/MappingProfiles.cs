using AutoMapper;
using Demo.BusinessLogic.DataTransferObjects.EmployeeDTOs;
using Demo.DataAccess.Entities.EmployeEntities;
using Demo.DataAccess.Entities.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogic.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Employee, EmployeeDTO>()
                .ForMember(dest => dest.Gender, options => options.MapFrom(src => src.Gender.ToString()))
                .ForMember(dest => dest.EmployeeType, options => options.MapFrom(src => src.EmployeeType.ToString()))
                .ForMember(dest => dest.Department, options => options.MapFrom(src => src.Department != null ? src.Department.Name : null));

            CreateMap<Employee, EmployeeDetailsDTO>()
                .ForMember(dest => dest.Gender, options => options.MapFrom(src => src.Gender.ToString()))
                .ForMember(dest => dest.EmployeeType, options => options.MapFrom(src => src.EmployeeType.ToString()))
                .ForMember(dest => dest.HiringDate, options => options.MapFrom(src => DateOnly.FromDateTime(src.HiringDate)))
                .ForMember(dest => dest.Department, options => options.MapFrom(src => src.Department == null? null : src.Department.Name));
            
            CreateMap<CreatedEmployeeDTO, Employee>()
                .ForMember(dest => dest.Gender, options => options.MapFrom(src => Enum.Parse<Gender>(src.Gender)))
                .ForMember(dest => dest.EmployeeType, options => options.MapFrom(src => Enum.Parse<EmployeeType>(src.EmployeeType)))
                .ForMember(dest => dest.HiringDate, options => options.MapFrom(src => src.HiringDate.ToDateTime(TimeOnly.MinValue)));

            CreateMap<EmployeeDetailsDTO, Employee>()
                .ForMember(dest => dest.Gender, options => options.MapFrom(src => Enum.Parse<Gender>(src.Gender)))
                .ForMember(dest => dest.EmployeeType, options => options.MapFrom(src => Enum.Parse<EmployeeType>(src.EmployeeType)))
                .ForMember(dest => dest.HiringDate, options => options.MapFrom(src => src.HiringDate.ToDateTime(TimeOnly.MinValue)));

            CreateMap<UpdatedEmployeeDTO, Employee>()
                .ForMember(dest => dest.Gender, options => options.MapFrom(src => src.Gender.ToString()))
                .ForMember(dest => dest.EmployeeType, options => options.MapFrom(src => src.EmployeeType.ToString()))
                .ForMember(dest => dest.HiringDate, options => options.MapFrom(src => src.HiringDate.ToDateTime(TimeOnly.MinValue)));

            CreateMap<Employee, UpdatedEmployeeDTO>()
                .ForMember(dest => dest.Gender, options => options.MapFrom(src => src.Gender.ToString()))
                .ForMember(dest => dest.EmployeeType, options => options.MapFrom(src => src.EmployeeType.ToString()))
                .ForMember(dest => dest.HiringDate, options => options.MapFrom(src => DateOnly.FromDateTime(src.HiringDate)));
        }
    }
}
