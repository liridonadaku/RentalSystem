using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentalSystemData.Entities;
using RentalSystemData.Interfaces;
using RentalSystemData.Repositories;
using RentalSystemData;

namespace RentalSystemData
{
    public class RentalSystemDbContext : DbContext, IRentalSystemDataService
    {
        private readonly RentalSystemDbContext db;
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<EmployeeCategory> EmployeeCategories { get; set; }
       
        private IRepository<Employee> employeeRepository;
        public IRepository<Employee> EmployeeRepository
        {
            get
            {
                return employeeRepository ??
                    (employeeRepository = new BaseRepository<Employee>(db));
            }
        }
        
        private IRepository<Account> accountRepository;
        public IRepository<Account> AccountRepository
        {
            get
            {
                return accountRepository ??
                    (accountRepository = new BaseRepository<Account>(db));
            }
        }
        private IRepository<EmployeeCategory> employeeCategoryRepository;
        public IRepository<EmployeeCategory> EmployeeCategoryRepository
        {
            get
            {
                return employeeCategoryRepository ??
                    (employeeCategoryRepository = new BaseRepository<EmployeeCategory>(db));
            }
        }

        IRepository<Employee> IRentalSystemDataService.Employees => throw new NotImplementedException();

        IRepository<Account> IRentalSystemDataService.Accounts => throw new NotImplementedException();

        IRepository<EmployeeCategory> IRentalSystemDataService.EmployeeCategories => throw new NotImplementedException();

        public RentalSystemDbContext(DbContextOptions options) : base(options)
        {
            db = this;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Seed();
        }

        public virtual IRepository<T> CreateRepository<T>() where T : class, IEntity
        {
            Type baseRepository = typeof(BaseRepository<>);
            Type[] typeArgs = { typeof(T) };
            Type constructed = baseRepository.MakeGenericType(typeArgs);
            return Activator.CreateInstance(constructed, db) as BaseRepository<T>; ;
        }
    }
}