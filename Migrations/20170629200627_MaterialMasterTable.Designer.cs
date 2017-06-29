using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using vega.Persistence;

namespace Vega.Migrations
{
    [DbContext(typeof(VegaDbContext))]
    [Migration("20170629200627_MaterialMasterTable")]
    partial class MaterialMasterTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("vega.Models.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("GradeId");

                    b.Property<string>("Name");

                    b.Property<int>("StudyingYearId");

                    b.HasKey("Id");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("vega.Models.Grade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("vega.Models.Material", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Materials");
                });

            modelBuilder.Entity("vega.Models.RegistrationYear", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EndYear");

                    b.Property<int>("StartYear");

                    b.HasKey("Id");

                    b.ToTable("RegistrationYears");
                });

            modelBuilder.Entity("vega.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("LastName");

                    b.Property<string>("MiddleName");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("vega.Models.StudentClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClassId");

                    b.Property<int>("StudentId");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentClasses");
                });

            modelBuilder.Entity("vega.Models.StudentRegistration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GradeId");

                    b.Property<DateTime>("RegistrationDate");

                    b.Property<int>("RegistrationYearId");

                    b.Property<int>("StudentId");

                    b.HasKey("Id");

                    b.ToTable("StudentRegistrations");
                });

            modelBuilder.Entity("vega.Models.StudyingYear", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("EndYear");

                    b.Property<string>("Name");

                    b.Property<int>("StartYear");

                    b.HasKey("Id");

                    b.ToTable("StudyingYears");
                });

            modelBuilder.Entity("vega.Models.StudentClass", b =>
                {
                    b.HasOne("vega.Models.Class", "Class")
                        .WithMany("Students")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("vega.Models.Student", "Student")
                        .WithMany("Classes")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
