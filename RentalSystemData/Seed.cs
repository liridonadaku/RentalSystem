using Microsoft.EntityFrameworkCore;
using RentalSystemData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalSystemData
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<Student>().HasData(new Student()
            {
                Id = new Guid("ff237416-9368-49d8-a968-058c9259eef8"),
                Name = "Student A",
                FirstName = "Aferdita",
                LastName = "Hasani",
            });
            builder.Entity<Student>().HasData(new Student()
            {
                Id = new Guid("ee237416-9368-49d8-a968-058c9259eef8"),
                Name = "Student B",
                FirstName = "Liridona",
                LastName = "Daku",
            });
            builder.Entity<Enrollment>().HasData(new Enrollment()
            {
                Id = new Guid("b7798b34-b066-421f-bd8b-f8ea6134c4a4"),
                Name = "Enrollment A",
                EnrollmentNumber = "1-Acc123"
            });
            builder.Entity<Enrollment>().HasData(new Enrollment()
            {
                Id = new Guid("160dc90e-fce0-487a-990d-7ee23bf6f5fd"),
                Name = "Enrollment B",
                EnrollmentNumber = "2-Acc456"
            });           
        }
    }
}
