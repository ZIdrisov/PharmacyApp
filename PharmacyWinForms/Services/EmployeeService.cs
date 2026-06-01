using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISApteka.Models;
using ISApteka.Repositories;

namespace ISApteka.Services
{
    public class EmployeeService
    {
        private readonly EmployeeRepository _repository;

        public EmployeeService(EmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Employee?> AuthenticateAsync(string login, string password)
        {
            
            var employee = await _repository.GetByLoginAsync(login);

            if (employee == null)
            {
                Console.WriteLine($"[DEBUG] Пользователь {login} НЕ НАЙДЕН в БД");
                return null;
            }


            if (employee.Password == password)
            {
                Console.WriteLine("[DEBUG] Аутентификация УСПЕШНА!");
                return employee;
            }

            Console.WriteLine("[DEBUG] Аутентификация НЕУСПЕШНА - пароли не совпадают");
            return null;
        }

        public async Task AssignPharmacistAsync(int employeeId)
        {
            var emp = await _repository.GetByIdAsync(employeeId);
            if (emp == null)
                throw new ArgumentException("Сотрудник не найден");

            if (emp.Role == UserRole.Pharmacist)
                throw new InvalidOperationException("Сотрудник уже является фармацевтом");

            if (emp.Role == UserRole.Admin)
                throw new InvalidOperationException("Администратор не может быть назначен фармацевтом");

            emp.Role = UserRole.Pharmacist;
            await _repository.UpdateAsync(emp);
        }

        public async Task AddEmployeeAsync(string login, string password, UserRole role)
        {
            var existing = await _repository.GetByLoginAsync(login);
            if (existing != null)
                throw new InvalidOperationException("Сотрудник с таким логином уже существует");

            var employee = new Employee
            {
                Login = login,
                Password = password,
                Role = role
            };
            await _repository.AddAsync(employee);
        }
    }
}