using Demo.BusinessLogic.DataTransferObjects.DepartmentDTOs;
using Demo.BusinessLogic.Mappings;
using Demo.BusinessLogic.Services.Interfaces;
using Demo.DataAccess.Data.Contexts;
using Demo.DataAccess.Data.Repositories.Interfaces;
using Demo.DataAccess.Data.UnitOfWork.Interfaces;
using Demo.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogic.Services.Classes
{
    public class DepartmentService(IUnitOfWork unitOfWork) : IDepartmentService
    {
        public async Task<int> CreateAsync(CreatedDepartmentDTO createdDepartmentDto)
        {
            await unitOfWork.DepartmentRepository.AddAsync(createdDepartmentDto.ToModel());
            return await unitOfWork.SaveChangesAsync();
        }

        public IEnumerable<DepartmentDTO> GetAll(bool withTracking = false)
        {
            var departments = unitOfWork.DepartmentRepository.GetAll(withTracking);
            return departments.Select(d => d.ToDto());
        }

        public async Task<DepartmentDetailsDTO> GetByIdAsync(int? id, bool withTracking = false)
        {
            var department = await unitOfWork.DepartmentRepository.GetByIdAsync(id, withTracking);
            if (department == null) return new DepartmentDetailsDTO { };
            return department.ToDetailsDto();
        }

        public async Task<int> UpdateAsync(UpdatedDepartmentDTO updatedDepartmentDto)
        {
            unitOfWork.DepartmentRepository.Update(updatedDepartmentDto.ToModel());
            return await unitOfWork.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(int id)
        {
            var departmentDetailsDto = await GetByIdAsync(id);
            unitOfWork.DepartmentRepository.Remove(departmentDetailsDto.ToModel());
            return await unitOfWork.SaveChangesAsync();
        }
    }
}
