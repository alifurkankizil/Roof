using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.DTO;

namespace WebAPI.Services.Abstract
{
    public interface IEmployeeService
    {
        EmployeeResponseDTO Create(EmployeeCreateDTO createDTO);
        EmployeeResponseDTO Update(long id,EmployeeUpdateDTO updateDTO);
        EmployeeResponseDTO Get(long id);
        IList<EmployeeResponseDTO> List();
        bool Delete(long id);
    }
}
