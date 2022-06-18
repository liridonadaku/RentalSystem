using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentalSystemData.Interfaces;

namespace RentalSystemData.Entities
{
    public class EmployeeCategory : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public EmployeeCategory()
        {
        }
    }
}
