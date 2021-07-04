using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data;
using WebAPI.DTO;
using WebAPI.Models;
using WebAPI.Services.Abstract;

namespace WebAPI.Services.Concrete
{
    public class EmployeeService : IEmployeeService
    {
        ApplicationContext Context { get; }
        IMapper Mapper { get; }
        public EmployeeService(ApplicationContext context,IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }
        public EmployeeResponseDTO Create(EmployeeCreateDTO createDTO)
        {
            var employee = Mapper.Map<Employee>(createDTO);
            Context.Employees.Add(employee);
            Context.SaveChanges();
            return Mapper.Map<EmployeeResponseDTO>(employee);
        }

        public EmployeeResponseDTO Update(long id,EmployeeUpdateDTO updateDTO)
        {
            var employee = Context.Employees.Single(x => x.Id == id);
            Mapper.Map(updateDTO, employee);
            Context.Employees.Update(employee);
            Context.SaveChanges();
            return Mapper.Map<EmployeeResponseDTO>(employee);
        }

        public EmployeeResponseDTO Get(long id)
        {
            var employee = Context.Employees.AsNoTracking().Single(x => x.Id == id);
            var response = Mapper.Map<EmployeeResponseDTO>(employee);
            return response;
        }

        public IList<EmployeeResponseDTO> List()
        {
            var employees = Context.Employees.AsNoTracking();
            var response = Mapper.Map<IList<EmployeeResponseDTO>>(employees);
            return response;
        }

        public bool Delete(long id)
        {
            var employee = Context.Employees.Single(x => x.Id == id);
            Context.Employees.Remove(employee);
            Context.SaveChanges();
            return true;
        }

        public EmployeeResponseDTO GetEmployeeActivity(long id)
        {
            var employee = Context.Employees.Include(x => x.EmployeeActivities).ThenInclude(x => x.Activity).Single(x => x.Id == id);
            var response = Mapper.Map<EmployeeResponseDTO>(employee);
            return response;
        }
    }
}
