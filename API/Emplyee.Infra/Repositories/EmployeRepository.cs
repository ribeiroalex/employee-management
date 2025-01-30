using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employee.Domain.Entities;
using Employee.Domain.Queries;
using Employee.Domain.Repositories;
using Emplyee.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Emplyee.Infra.Repositories
{
    public class EmployeRepository : IEmployeeRepository
    {

        private readonly DataContext _dataContext;

        public EmployeRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> Add(Employee.Domain.Entities.Employee employee)
        {
            _dataContext.Employees.Add(employee);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public bool Delete(Employee.Domain.Entities.Employee employee)
        {
            _dataContext.Employees.Remove(employee);
            _dataContext.SaveChanges();
            return true;
        }

        public IEnumerable<Employee.Domain.Entities.Employee> GetAll()
        {
            return _dataContext.Employees.AsNoTracking().OrderBy(x => x.FirstName);
        }

        public async Task<Employee.Domain.Entities.Employee?> GetByIdAsync(Guid id)
        {
            return await _dataContext.Employees
                .Include(x => x.EmployeeRoles)
                .ThenInclude(x => x.RolePermission)
                .Where(EmployeeQueries.GetById(id)).FirstOrDefaultAsync();
        }

        public bool Update(Employee.Domain.Entities.Employee employee)
        {
            _dataContext.Entry(employee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _dataContext.SaveChanges();
            return true;
        }

        public async Task<Role?> GetRoleByIdAsync(int id)
        {
            return await _dataContext.Roles.Where(RoleQueries.GetById(id)).FirstOrDefaultAsync();
        }
    }
}
