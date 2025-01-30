﻿// <auto-generated />
using System;
using Emplyee.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Emplyee.Infra.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20250130022913_AddDataMigration")]
    partial class AddDataMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Employee.Domain.Entities.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DocumentNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DocumentNumber")
                        .IsUnique();

                    b.ToTable("People");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Employee.Domain.Entities.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("Role", (string)null);
                });

            modelBuilder.Entity("Employee.Domain.Entities.RolePermission", b =>
                {
                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("CanCreateRoleId")
                        .HasColumnType("int");

                    b.HasKey("RoleId", "CanCreateRoleId");

                    b.HasIndex("CanCreateRoleId");

                    b.ToTable("RolePermissions");
                });

            modelBuilder.Entity("Employee.Domain.Entities.ValueObjects.Address", b =>
                {
                    b.Property<Guid>("PersonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AddressLine")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PersonId", "AddressLine");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Employee.Domain.Entities.ValueObjects.Phone", b =>
                {
                    b.Property<Guid>("PersonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PersonId", "PhoneNumber");

                    b.ToTable("Phones");
                });

            modelBuilder.Entity("EmployeeRole", b =>
                {
                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("RolesRoleId")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId", "RolesRoleId");

                    b.HasIndex("RolesRoleId");

                    b.ToTable("EmployeeRole");
                });

            modelBuilder.Entity("Employee.Domain.Entities.Employee", b =>
                {
                    b.HasBaseType("Employee.Domain.Entities.Person");

                    b.Property<Guid?>("ManagerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("ManagerId");

                    b.ToTable("Employee", (string)null);
                });

            modelBuilder.Entity("Employee.Domain.Entities.RolePermission", b =>
                {
                    b.HasOne("Employee.Domain.Entities.Role", "CanCreateRole")
                        .WithMany()
                        .HasForeignKey("CanCreateRoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Employee.Domain.Entities.Role", "Role")
                        .WithMany("RolePermission")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CanCreateRole");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Employee.Domain.Entities.ValueObjects.Address", b =>
                {
                    b.HasOne("Employee.Domain.Entities.Person", "Person")
                        .WithMany("Addresses")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Employee.Domain.Entities.ValueObjects.Phone", b =>
                {
                    b.HasOne("Employee.Domain.Entities.Person", "Person")
                        .WithMany("Phones")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("EmployeeRole", b =>
                {
                    b.HasOne("Employee.Domain.Entities.Employee", null)
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Employee.Domain.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RolesRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Employee.Domain.Entities.Employee", b =>
                {
                    b.HasOne("Employee.Domain.Entities.Person", null)
                        .WithOne()
                        .HasForeignKey("Employee.Domain.Entities.Employee", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Employee.Domain.Entities.Employee", "Manager")
                        .WithMany("EmployessList")
                        .HasForeignKey("ManagerId");

                    b.Navigation("Manager");
                });

            modelBuilder.Entity("Employee.Domain.Entities.Person", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("Phones");
                });

            modelBuilder.Entity("Employee.Domain.Entities.Role", b =>
                {
                    b.Navigation("RolePermission");
                });

            modelBuilder.Entity("Employee.Domain.Entities.Employee", b =>
                {
                    b.Navigation("EmployessList");
                });
#pragma warning restore 612, 618
        }
    }
}
