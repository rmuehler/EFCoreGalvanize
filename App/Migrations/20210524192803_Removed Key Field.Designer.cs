﻿// <auto-generated />
using EFCoreGalvanize;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFCoreGalvanize.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20210524192803_Removed Key Field")]
    partial class RemovedKeyField
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.6");

            modelBuilder.Entity("EFCoreGalvanize.Grade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CourseName")
                        .HasColumnType("TEXT");

                    b.Property<float>("Score")
                        .HasColumnType("REAL");

                    b.Property<int>("StudentId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("Grades");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CourseName = "Calculus 302",
                            Score = 89f,
                            StudentId = 3
                        },
                        new
                        {
                            Id = 2,
                            CourseName = "English 101",
                            Score = 98f,
                            StudentId = 1
                        },
                        new
                        {
                            Id = 3,
                            CourseName = "Computer Science 203",
                            Score = 66f,
                            StudentId = 2
                        },
                        new
                        {
                            Id = 4,
                            CourseName = "Woodwork 200",
                            Score = 45f,
                            StudentId = 1
                        },
                        new
                        {
                            Id = 5,
                            CourseName = "Database Design 101",
                            Score = 0f,
                            StudentId = 5
                        });
                });

            modelBuilder.Entity("EFCoreGalvanize.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Classification")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 22,
                            Classification = 3,
                            FirstName = "Robert",
                            LastName = "Muehler"
                        },
                        new
                        {
                            Id = 2,
                            Age = 21,
                            Classification = 2,
                            FirstName = "Bob",
                            LastName = "Evans"
                        },
                        new
                        {
                            Id = 3,
                            Age = 20,
                            Classification = 1,
                            FirstName = "Ronald",
                            LastName = "McDonald"
                        },
                        new
                        {
                            Id = 4,
                            Age = 121,
                            Classification = 3,
                            FirstName = "Joseph",
                            LastName = "Biden"
                        },
                        new
                        {
                            Id = 5,
                            Age = 18,
                            Classification = 0,
                            FirstName = "Frank",
                            LastName = "Biden"
                        });
                });

            modelBuilder.Entity("EFCoreGalvanize.Grade", b =>
                {
                    b.HasOne("EFCoreGalvanize.Student", null)
                        .WithMany("Grades")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EFCoreGalvanize.Student", b =>
                {
                    b.Navigation("Grades");
                });
#pragma warning restore 612, 618
        }
    }
}
