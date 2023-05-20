﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using facialRecognitionBackend.Data;

#nullable disable

namespace SeniorBackend.Migrations
{
    [DbContext(typeof(facialRecognitionDbContext))]
    [Migration("20230502190024_added-session-attendance-attended-tables")]
    partial class addedsessionattendanceattendedtables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SeniorBackend.Models.Attendance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Sessionid")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Sessionid");

                    b.ToTable("Attendance");
                });

            modelBuilder.Entity("SeniorBackend.Models.Attendended", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("Attendanded");
                });

            modelBuilder.Entity("SeniorBackend.Models.Class", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("building")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("class_nb")
                        .HasColumnType("int");

                    b.Property<int>("floor_nb")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("SeniorBackend.Models.Course", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("Classid")
                        .HasColumnType("int");

                    b.Property<int>("course_Code")
                        .HasColumnType("int");

                    b.Property<string>("course_Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("course_Instructor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("course_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("SeniorBackend.Models.CourseStudent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Coursesid")
                        .HasColumnType("int");

                    b.Property<int>("StudentsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Coursesid");

                    b.HasIndex("StudentsId");

                    b.ToTable("CourseStudent");
                });

            modelBuilder.Entity("SeniorBackend.Models.Face", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<byte[]>("FaceEncoding")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("StudentsId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("StudentsId")
                        .IsUnique();

                    b.ToTable("Face");
                });

            modelBuilder.Entity("SeniorBackend.Models.Session", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Classesid")
                        .HasColumnType("int");

                    b.Property<int>("Coursesid")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("TimeSpan")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.HasIndex("Classesid");

                    b.HasIndex("Coursesid");

                    b.ToTable("Session");
                });

            modelBuilder.Entity("SeniorBackend.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("fName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("faceID")
                        .HasColumnType("int");

                    b.Property<string>("lName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("SeniorBackend.Models.Attendance", b =>
                {
                    b.HasOne("SeniorBackend.Models.Session", "Session")
                        .WithMany()
                        .HasForeignKey("Sessionid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Session");
                });

            modelBuilder.Entity("SeniorBackend.Models.Attendended", b =>
                {
                    b.HasOne("SeniorBackend.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("SeniorBackend.Models.CourseStudent", b =>
                {
                    b.HasOne("SeniorBackend.Models.Course", "Course")
                        .WithMany("Students")
                        .HasForeignKey("Coursesid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SeniorBackend.Models.Student", "Student")
                        .WithMany("Courses")
                        .HasForeignKey("StudentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("SeniorBackend.Models.Face", b =>
                {
                    b.HasOne("SeniorBackend.Models.Student", "Student")
                        .WithOne("face")
                        .HasForeignKey("SeniorBackend.Models.Face", "StudentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("SeniorBackend.Models.Session", b =>
                {
                    b.HasOne("SeniorBackend.Models.Class", "Class")
                        .WithMany()
                        .HasForeignKey("Classesid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SeniorBackend.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("Coursesid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("Course");
                });

            modelBuilder.Entity("SeniorBackend.Models.Course", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("SeniorBackend.Models.Student", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("face")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
