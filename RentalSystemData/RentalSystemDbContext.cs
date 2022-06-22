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
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Department> Departments { get; set; }
       
        private IRepository<Student> studentRepository;
        public IRepository<Student> StudentRepository
        {
            get
            {
                return studentRepository ??
                    (studentRepository = new BaseRepository<Student>(db));
            }
        }
        
        private IRepository<Enrollment> enrollmentRepository;
        public IRepository<Enrollment> EnrollmentRepository
        {
            get
            {
                return enrollmentRepository ??
                    (enrollmentRepository = new BaseRepository<Enrollment>(db));
            }
        }
        private IRepository<Department> departmentRepository;
        public IRepository<Department> DepartmentRepository
        {
            get
            {
                return departmentRepository ??
                    (departmentRepository = new BaseRepository<Department>(db));
            }
        }

        IRepository<Student> IRentalSystemDataService.Students => throw new NotImplementedException();

        IRepository<Enrollment> IRentalSystemDataService.Enrollments => throw new NotImplementedException();

        IRepository<Department> IRentalSystemDataService.Departments => throw new NotImplementedException();

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