using RentalSystemData.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalSystemData.Entities
{
    public class Course : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public double? Credits { get; set; }
        public Course()
        {
        }
    }
}