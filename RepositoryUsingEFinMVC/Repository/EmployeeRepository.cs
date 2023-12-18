using RepositoryUsingEFinMVC.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace RepositoryUsingEFinMVC.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDBEntities _context;

        public EmployeeRepository()
        {
            _context = new EmployeeDBEntities();
        }
        public EmployeeRepository(EmployeeDBEntities context)
        {
            _context = context;
        }
        public IEnumerable<Employee> GetAll()
        {
            return _context.Employees.ToList();
        }
        public Employee GetById(int EmployeeID)
        {
            return _context.Employees.Find(EmployeeID);
        }
        public void Update(Employee employee)
        {
            _context.Entry(employee).State = EntityState.Modified;
        }
        public void Delete(int EmployeeID)
        {
            Employee employee = _context.Employees.Find(EmployeeID);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
            }
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Insert(Employee employee)
        {
            // throw new NotImplementedException();
            _context.Employees.Add(employee);
        }
    }
}