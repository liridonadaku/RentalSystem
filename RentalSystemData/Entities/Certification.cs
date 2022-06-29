using RentalSystemData.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalSystemData.Entities
{
    public class Certification : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public Guid? StudentId { get; set; }
        public Student Student { get; set; }

        public Certification()
        {
        }
    }
}
