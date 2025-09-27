using Demo.BusinessLogic.DataTransferObjects.EmployeeDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogic.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDTO>> GetAllAsync(string? searchName, bool withTracking = false);
        Task<T?> GetByIdAsync<T>(int? id, bool withTracking = false) where T : class;
        Task<int> CreateAsync(CreatedEmployeeDTO createdEmployeeDto);
        Task<int> UpdateAsync(UpdatedEmployeeDTO updatedEmployeeDto);
        Task<int?> DeleteAsync(int id);
    }
}
