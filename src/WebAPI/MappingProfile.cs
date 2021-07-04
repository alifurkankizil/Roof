using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTO;
using WebAPI.Models;

namespace WebAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EmployeeCreateDTO, Employee>();
            CreateMap<Employee, EmployeeResponseDTO>();

            CreateMap<EmployeeUpdateDTO, Employee>();
        }
    }
}
