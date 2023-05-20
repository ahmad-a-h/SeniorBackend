﻿// <auto-generated />
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
    [Migration("20230421084535_update-course2")]
    partial class updatecourse2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SeniorBackend.Models.Class", b =>
                {
                    b.Property<int>("class_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("class_Id"), 1L, 1);

                    b.Property<string>("building")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("class_nb")
                        .HasColumnType("int");

                    b.Property<int>("floor_nb")
                        .HasColumnType("int");

                    b.HasKey("class_Id");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("SeniorBackend.Models.Course", b =>
                {
                    b.Property<int>("course_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("course_Id"), 1L, 1);

                    b.Property<int>("class_Id")
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

                    b.HasKey("course_Id");

                    b.HasIndex("class_Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("SeniorBackend.Models.Course", b =>
                {
                    b.HasOne("SeniorBackend.Models.Class", "Class")
                        .WithMany("Courses")
                        .HasForeignKey("class_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");
                });

            modelBuilder.Entity("SeniorBackend.Models.Class", b =>
                {
                    b.Navigation("Courses");
                });
#pragma warning restore 612, 618
        }
    }
}