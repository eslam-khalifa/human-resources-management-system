using AutoMapper;
using Demo.BusinessLogic.DataTransferObjects.EmployeeDTOs;
using Demo.BusinessLogic.Mappings;
using Demo.BusinessLogic.Services.AttachementService;
using Demo.BusinessLogic.Services.Interfaces;
using Demo.DataAccess.Data.Repositories.Interfaces;
using Demo.DataAccess.Data.UnitOfWork.Interfaces;
using Demo.DataAccess.Entities.EmployeEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Demo.BusinessLogic.Services.Classes
{
    public class EmployeeService(IUnitOfWork unitOfWork,
                                 IMapper mapper,
                                 IAttachementService attachementService) : IEmployeeService
    {
        public async Task<int> CreateAsync(CreatedEmployeeDTO createdEmployeeDTO)
        {
            Employee? employee = mapper.Map<CreatedEmployeeDTO, Employee>(createdEmployeeDTO);

            if (createdEmployeeDTO.Image is not null)
            {
                employee.ImageName = attachementService.Upload(createdEmployeeDTO.Image, "Images");
            }

            await unitOfWork.EmployeeRepository.AddAsync(employee);
            return await unitOfWork.SaveChangesAsync();
        }

        public async Task<int?> DeleteAsync(int id)
        {
            Employee? employee = await unitOfWork.EmployeeRepository.GetByIdAsync(id);
            if (employee == null) return null;
            else
            {
                employee.IsDeleted = true;
                unitOfWork.EmployeeRepository.Update(employee);
                return await unitOfWork.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<EmployeeDTO>> GetAllAsync(string? searchName, bool withTracking = false)
        {
            IEnumerable<Employee> employees;

            if (string.IsNullOrEmpty(searchName))
            {
                employees = unitOfWork.EmployeeRepository.GetAll(withTracking).Where(emp => emp.IsDeleted == false).ToList();
            }
            else
            {
                employees = await unitOfWork.EmployeeRepository.GetAllAsync(e => e.Name.ToLower().Contains(searchName.ToLower()));
                employees = employees.Where(emp => emp.IsDeleted == false).ToList();
            }

            IEnumerable<EmployeeDTO>? employeeDTO = mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDTO>>(employees);

            return employeeDTO;
        }

        public async Task<T?> GetByIdAsync<T>(int? id, bool withTracking = false) where T : class
        {
            Employee? employee = await unitOfWork.EmployeeRepository.GetByIdAsync(id, withTracking);
            if (employee is null) return null;

            var employeeDTO = mapper.Map<T>(employee);

            return employeeDTO;
        }

        public async Task<int> UpdateAsync(UpdatedEmployeeDTO updatedEmployeeVM)
        {
            var employee = await unitOfWork.EmployeeRepository.GetByIdAsync(updatedEmployeeVM.Id);

            if (employee == null) throw new Exception("Employee not found");

            mapper.Map(updatedEmployeeVM, employee);

            if (updatedEmployeeVM.Image != null && updatedEmployeeVM.Image.Length > 0)
            {
                var fileName = Guid.NewGuid() + Path.GetExtension(updatedEmployeeVM.Image.FileName);

                var savePath = Path.Combine("wwwroot/Files/Images", fileName);

                using (var stream = new FileStream(savePath, FileMode.Create))
                {
                    updatedEmployeeVM.Image.CopyTo(stream);
                }

                employee.ImageName = fileName;
            }
            else
            {
                employee.ImageName = updatedEmployeeVM.ImageName;
            }

            unitOfWork.EmployeeRepository.Update(employee);
            return await unitOfWork.SaveChangesAsync();
        }
    }
}
