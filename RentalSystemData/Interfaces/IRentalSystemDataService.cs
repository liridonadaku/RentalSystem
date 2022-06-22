using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentalSystemData.Entities;
using RentalSystemData.Interfaces;
using RentalSystemData.Repositories;

namespace RentalSystemData
{
    public interface IRentalSystemDataService : IDataService
    {
        IRepository<Student> Students { get; }
        IRepository<Enrollment> Enrollments { get; }
        IRepository<Department> Departments { get; }
    }
}
