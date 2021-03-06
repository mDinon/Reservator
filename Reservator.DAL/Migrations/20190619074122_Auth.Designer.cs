﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Reservator.DAL;

namespace Reservator.DAL.Migrations
{
    [DbContext(typeof(ReservatorDbContext))]
    [Migration("20190619074122_Auth")]
    partial class Auth
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Reservator")
                .HasAnnotation("ProductVersion", "3.0.0-preview5.19227.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Reservator.Model.ObjectOwner", b =>
                {
                    b.Property<int?>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Active")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("1");

                    b.Property<DateTime?>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime?>("DateModified")
                        .ValueGeneratedOnUpdate()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("ID");

                    b.ToTable("ObjectOwners");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Active = true,
                            DateCreated = new DateTime(2019, 6, 19, 9, 41, 20, 947, DateTimeKind.Local).AddTicks(212),
                            Description = "Desc1",
                            Name = "Owner1"
                        },
                        new
                        {
                            ID = 2,
                            Active = true,
                            DateCreated = new DateTime(2019, 6, 19, 9, 41, 20, 947, DateTimeKind.Local).AddTicks(1405),
                            Description = "Desc2",
                            Name = "Owner2"
                        });
                });

            modelBuilder.Entity("Reservator.Model.Reservation", b =>
                {
                    b.Property<int?>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Active")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("1");

                    b.Property<DateTime?>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime?>("DateFrom")
                        .IsRequired();

                    b.Property<DateTime?>("DateModified")
                        .ValueGeneratedOnUpdate()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime?>("DateTo")
                        .IsRequired();

                    b.Property<int?>("ReservationObjectID")
                        .IsRequired();

                    b.Property<int?>("UserID")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasIndex("ReservationObjectID");

                    b.HasIndex("UserID");

                    b.ToTable("Reservations");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Active = true,
                            DateCreated = new DateTime(2019, 6, 19, 9, 41, 20, 954, DateTimeKind.Local).AddTicks(7525),
                            DateFrom = new DateTime(2019, 6, 19, 9, 41, 20, 954, DateTimeKind.Local).AddTicks(7568),
                            DateTo = new DateTime(2019, 6, 19, 9, 41, 20, 954, DateTimeKind.Local).AddTicks(8789),
                            ReservationObjectID = 1,
                            UserID = 1
                        });
                });

            modelBuilder.Entity("Reservator.Model.ReservationObject", b =>
                {
                    b.Property<int?>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Active")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("1");

                    b.Property<DateTime?>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime?>("DateModified")
                        .ValueGeneratedOnUpdate()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Description");

                    b.Property<long?>("MaximumReservationTime")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int?>("ObjectOwnerID")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasIndex("ObjectOwnerID");

                    b.ToTable("ReservationObjects");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Active = true,
                            DateCreated = new DateTime(2019, 6, 19, 9, 41, 20, 952, DateTimeKind.Local).AddTicks(4054),
                            Description = "Reservation object A",
                            MaximumReservationTime = 864000000000L,
                            Name = "Reservation object A",
                            ObjectOwnerID = 1
                        });
                });

            modelBuilder.Entity("Reservator.Model.Role", b =>
                {
                    b.Property<int?>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Active")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("1");

                    b.Property<DateTime?>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime?>("DateModified")
                        .ValueGeneratedOnUpdate()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("ID");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Active = true,
                            DateCreated = new DateTime(2019, 6, 19, 9, 41, 20, 945, DateTimeKind.Local).AddTicks(5262),
                            Description = "User role",
                            Name = "User"
                        },
                        new
                        {
                            ID = 2,
                            Active = true,
                            DateCreated = new DateTime(2019, 6, 19, 9, 41, 20, 945, DateTimeKind.Local).AddTicks(5337),
                            Description = "Admin role",
                            Name = "Admin"
                        });
                });

            modelBuilder.Entity("Reservator.Model.User", b =>
                {
                    b.Property<int?>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Active")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("1");

                    b.Property<DateTime?>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime?>("DateModified")
                        .ValueGeneratedOnUpdate()
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("EmailConfirmed");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("Token");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("ID");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Active = true,
                            DateCreated = new DateTime(2019, 6, 19, 9, 41, 20, 934, DateTimeKind.Local).AddTicks(4535),
                            Email = "test.test@test.test",
                            FirstName = "Test",
                            LastName = "User",
                            Password = "testuser",
                            Username = "tUser"
                        },
                        new
                        {
                            ID = 2,
                            Active = true,
                            DateCreated = new DateTime(2019, 6, 19, 9, 41, 20, 942, DateTimeKind.Local).AddTicks(3235),
                            Email = "admin@admin.admin",
                            FirstName = "Admin",
                            LastName = "User",
                            Password = "adminuser",
                            Username = "aUser"
                        });
                });

            modelBuilder.Entity("Reservator.Model.UserRole", b =>
                {
                    b.Property<int?>("UserID");

                    b.Property<int?>("RoleID");

                    b.HasKey("UserID", "RoleID");

                    b.HasIndex("RoleID");

                    b.ToTable("UserRole");

                    b.HasData(
                        new
                        {
                            UserID = 1,
                            RoleID = 1
                        },
                        new
                        {
                            UserID = 2,
                            RoleID = 2
                        });
                });

            modelBuilder.Entity("Reservator.Model.Reservation", b =>
                {
                    b.HasOne("Reservator.Model.ReservationObject", "ReservationObject")
                        .WithMany("Reservations")
                        .HasForeignKey("ReservationObjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Reservator.Model.User", "User")
                        .WithMany("Reservations")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Reservator.Model.ReservationObject", b =>
                {
                    b.HasOne("Reservator.Model.ObjectOwner", "ObjectOwner")
                        .WithMany("ReservationObjects")
                        .HasForeignKey("ObjectOwnerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Reservator.Model.UserRole", b =>
                {
                    b.HasOne("Reservator.Model.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Reservator.Model.User", "User")
                        .WithMany("Roles")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
