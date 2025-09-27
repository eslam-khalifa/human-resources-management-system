using Demo.BusinessLogic.DataTransferObjects.DepartmentDTOs;
using Demo.DataAccess.Entities;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogic.Services.Interfaces
{
    public interface IDepartmentService
    {
        IEnumerable<DepartmentDTO> GetAll(bool withTracking = false);
        Task<int> CreateAsync(CreatedDepartmentDTO createdDepartmentDto);
        Task<DepartmentDetailsDTO> GetByIdAsync(int? id, bool withTracking = false);
        Task<int> UpdateAsync(UpdatedDepartmentDTO updatedDepartmentDto);
        Task<int> DeleteAsync(int id);
    }
}
