using RentalSystemData.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalSystemData.Entities
{
    public class Employee : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Age { get; set; }   
        public EmployeeCategory? EmployeeCategory { get; set; }
        public Guid? EmployeeCategoryId { get; set; }
        public Employee()
        {
        }
    }
   
}