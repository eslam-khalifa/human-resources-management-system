using Demo.BusinessLogic.DataTransferObjects.DepartmentDTOs;
using Demo.DataAccess.Entities.DepartmentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogic.Mappings
{
    public static class DepartmentExtensions
    {
        public static DepartmentDTO? ToDto(this Department department)
        {
            if (department == null) return null;

            return new DepartmentDTO
            {
                Id = department.Id,
                Name = department.Name,
                Code = department.Code,
                Description = department.Description,
                DateOfCreation = department.CreatedOn
            };
        }
        public static DepartmentDetailsDTO? ToDetailsDto(this Department department)
        {
            if (department == null) return null;

            return new DepartmentDetailsDTO
            {
                Id = department.Id,
                Name = department.Name,
                Code = department.Code,
                Description = department.Description,
                CreatedBy = department.CreatedBy,
                CreatedOn = department.CreatedOn,
                LastModifiedBy = department.LastModifiedBy,
                LastModifiedOn = department.LastModifiedOn
            };
        }
        public static UpdatedDepartmentDTO? ToEditDto(this Department department)
        {
            if (department == null) return null;
            return new UpdatedDepartmentDTO
            {
                DateOfCreation = department.CreatedOn,
                Name = department.Name,
                Code = department.Code,
                Description = department.Description
            };
        }
        public static Department? ToModel(this CreatedDepartmentDTO createdDepartmentDto)
        {
            if (createdDepartmentDto == null) return null;
            return new Department
            {
                Name = createdDepartmentDto.Name,
                Code = createdDepartmentDto.Code,
                Description = createdDepartmentDto.Description,
                CreatedOn = createdDepartmentDto.DateOfCreation
            };
        }
        public static Department? ToModel(this UpdatedDepartmentDTO updatedDepartmentDto)
        {
            if (updatedDepartmentDto == null) return null;
            return new Department
            {
                Id = updatedDepartmentDto.Id,
                Name = updatedDepartmentDto.Name,
                Code = updatedDepartmentDto.Code,
                Description = updatedDepartmentDto.Description,
                CreatedOn = updatedDepartmentDto.DateOfCreation
            };
        }
        public static Department? ToModel(this DepartmentDetailsDTO departmentDetailsDto)
        {
            if (departmentDetailsDto == null) return null;
            return new Department
            {
                Id = departmentDetailsDto.Id,
                Name = departmentDetailsDto.Name,
                Code = departmentDetailsDto.Code,
                Description = departmentDetailsDto.Description,
                CreatedBy = departmentDetailsDto.CreatedBy,
                CreatedOn = departmentDetailsDto.CreatedOn,
                LastModifiedBy = departmentDetailsDto.LastModifiedBy,
                LastModifiedOn = departmentDetailsDto.LastModifiedOn
            };
        }
    }
}
