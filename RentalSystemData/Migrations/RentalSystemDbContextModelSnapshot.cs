﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RentalSystemData;

#nullable disable

namespace RentalSystemData.Migrations
{
    [DbContext(typeof(RentalSystemDbContext))]
    partial class RentalSystemDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("RentalSystemData.Entities.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("RentalSystemData.Entities.Enrollment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EnrollmentNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Enrollments");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b7798b34-b066-421f-bd8b-f8ea6134c4a4"),
                            EnrollmentNumber = "1-Acc123",
                            Name = "Enrollment A"
                        },
                        new
                        {
                            Id = new Guid("160dc90e-fce0-487a-990d-7ee23bf6f5fd"),
                            EnrollmentNumber = "2-Acc456",
                            Name = "Enrollment B"
                        });
                });

            modelBuilder.Entity("RentalSystemData.Entities.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<Guid?>("DepartmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ff237416-9368-49d8-a968-058c9259eef8"),
                            Age = 0,
                            FirstName = "Aferdita",
                            LastName = "Hasani",
                            Name = "Student A"
                        },
                        new
                        {
                            Id = new Guid("ee237416-9368-49d8-a968-058c9259eef8"),
                            Age = 0,
                            FirstName = "Liridona",
                            LastName = "Daku",
                            Name = "Student B"
                        });
                });

            modelBuilder.Entity("RentalSystemData.Entities.Student", b =>
                {
                    b.HasOne("RentalSystemData.Entities.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId");

                    b.Navigation("Department");
                });
#pragma warning restore 612, 618
        }
    }
}
