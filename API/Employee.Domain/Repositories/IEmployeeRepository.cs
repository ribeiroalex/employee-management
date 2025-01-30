
using Employee.Domain.Entities;

namespace Employee.Domain.Repositories
{
    public interface IEmployeeRepository
    {
        public bool Update(Entities.Employee employee);

        public Task<Entities.Employee> GetByIdAsync(Guid id);

        public bool Delete(Entities.Employee employee);

        public IEnumerable<Entities.Employee> GetAll();

        Task<Role?> GetRoleByIdAsync(int id);
    }
}
