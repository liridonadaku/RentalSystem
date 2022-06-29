using RentalSystemData.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalSystemData.Entities
{
    public class Student : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Age { get; set; }   
        public Department? Department { get; set; }
        public Guid? DepartmentId { get; set; }
        public List<Certification> Certifications { get; set; }

        //public virtual ICollection<Certification> Certifications { get; set; }
        public List<Enrollment> Enrollments { get; set; }

        public Student()
        {
        }
    }
   
}