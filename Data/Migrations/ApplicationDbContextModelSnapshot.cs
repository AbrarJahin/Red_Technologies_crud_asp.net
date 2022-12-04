﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StartupProject_Asp.NetCore_PostGRE.Data;

namespace StartupProject_Asp.NetCore_PostGRE.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("public")
                .HasAnnotation("ProductVersion", "3.1.30");

            modelBuilder.Entity("StartupProject_Asp.NetCore_PostGRE.Data.Models.AppData.Order", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("CreateTime")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnName("CreateTime")
                        .HasColumnType("TIMESTAMPTZ");

                    b.Property<Guid?>("CustomerId")
                        .HasColumnName("CustomerId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("LastUpdateTime")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnName("LastUpdateTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("OrderType")
                        .HasColumnName("OrderType")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("StartupProject_Asp.NetCore_PostGRE.Data.Models.AppData.OrderProduct", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("CreateTime")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnName("CreateTime")
                        .HasColumnType("TIMESTAMPTZ");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("LastUpdateTime")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnName("LastUpdateTime")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("OrderId")
                        .HasColumnName("OrderId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ProductId")
                        .HasColumnName("ProductId")
                        .HasColumnType("TEXT");

                    b.Property<int>("UnitBought")
                        .HasColumnName("UnitBought")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderProducts");
                });

            modelBuilder.Entity("StartupProject_Asp.NetCore_PostGRE.Data.Models.AppData.Product", b =>
                {
                    b.Property<Guid?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("CreateTime")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnName("CreateTime")
                        .HasColumnType("TIMESTAMPTZ");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("LastUpdateTime")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnName("LastUpdateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasColumnType("TEXT")
                        .HasMaxLength(32767);

                    b.Property<float>("UnitPrice")
                        .HasColumnName("UnitPrice")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("Role","Identity");

                    b.HasData(
                        new
                        {
                            Id = new Guid("619b607a-e5f5-4acb-9926-2afcb4de28bd"),
                            ConcurrencyStamp = "d5a4a1b8-6972-44e9-b299-958db18dee29",
                            Description = "12/4/2022 10:24:32 PM",
                            Name = "Super-Admin",
                            NormalizedName = "SUPER-ADMIN"
                        });
                });

            modelBuilder.Entity("StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity.RoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("RoleId")
                        .HasColumnName("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaim","Identity");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            ClaimType = "SuperAdmin_All",
                            ClaimValue = "SuperAdmin.All",
                            RoleId = new Guid("619b607a-e5f5-4acb-9926-2afcb4de28bd")
                        },
                        new
                        {
                            Id = -2,
                            ClaimType = "Role_Create",
                            ClaimValue = "Role.Create",
                            RoleId = new Guid("619b607a-e5f5-4acb-9926-2afcb4de28bd")
                        },
                        new
                        {
                            Id = -3,
                            ClaimType = "Role_Read",
                            ClaimValue = "Role.Read",
                            RoleId = new Guid("619b607a-e5f5-4acb-9926-2afcb4de28bd")
                        },
                        new
                        {
                            Id = -4,
                            ClaimType = "Role_Update",
                            ClaimValue = "Role.Update",
                            RoleId = new Guid("619b607a-e5f5-4acb-9926-2afcb4de28bd")
                        },
                        new
                        {
                            Id = -5,
                            ClaimType = "Role_Delete",
                            ClaimValue = "Role.Delete",
                            RoleId = new Guid("619b607a-e5f5-4acb-9926-2afcb4de28bd")
                        },
                        new
                        {
                            Id = -6,
                            ClaimType = "Claim_Create",
                            ClaimValue = "Claim.Create",
                            RoleId = new Guid("619b607a-e5f5-4acb-9926-2afcb4de28bd")
                        });
                });

            modelBuilder.Entity("StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("ProfilePicture")
                        .HasColumnType("BLOB");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.Property<int>("UsernameChangeLimit")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("User","Identity");

                    b.HasData(
                        new
                        {
                            Id = new Guid("035c6acd-3484-4dd5-acfd-4854a7d69dfe"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "21f6f2d5-6679-46e8-89f7-76311f959a17",
                            Email = "abrar@jahin.com",
                            EmailConfirmed = true,
                            FirstName = "Abrar",
                            LastName = "Jahin",
                            LockoutEnabled = false,
                            NormalizedEmail = "ABRAR@JAHIN.COM",
                            NormalizedUserName = "ABRAR",
                            PasswordHash = "AQAAAAEAACcQAAAAEJX741ZGqBJyU+cBZ3V189hbj3WLectM4ltQoMEhSfAW8CFJUZLgd43FlXYUb+esfg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "638057714727099647_2057b16a-4186-4c3e-b84e-325256640ef5",
                            TwoFactorEnabled = false,
                            UserName = "abrar",
                            UsernameChangeLimit = 10
                        });
                });

            modelBuilder.Entity("StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity.UserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("UserId1")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("UserId1");

                    b.ToTable("UserClaim","Identity");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            ClaimType = "SuperAdmin_All",
                            ClaimValue = "SuperAdmin.All",
                            UserId = new Guid("035c6acd-3484-4dd5-acfd-4854a7d69dfe")
                        },
                        new
                        {
                            Id = -2,
                            ClaimType = "Role_Create",
                            ClaimValue = "Role.Create",
                            UserId = new Guid("035c6acd-3484-4dd5-acfd-4854a7d69dfe")
                        },
                        new
                        {
                            Id = -3,
                            ClaimType = "Role_Read",
                            ClaimValue = "Role.Read",
                            UserId = new Guid("035c6acd-3484-4dd5-acfd-4854a7d69dfe")
                        },
                        new
                        {
                            Id = -4,
                            ClaimType = "Role_Update",
                            ClaimValue = "Role.Update",
                            UserId = new Guid("035c6acd-3484-4dd5-acfd-4854a7d69dfe")
                        },
                        new
                        {
                            Id = -5,
                            ClaimType = "Role_Delete",
                            ClaimValue = "Role.Delete",
                            UserId = new Guid("035c6acd-3484-4dd5-acfd-4854a7d69dfe")
                        },
                        new
                        {
                            Id = -6,
                            ClaimType = "Claim_Create",
                            ClaimValue = "Claim.Create",
                            UserId = new Guid("035c6acd-3484-4dd5-acfd-4854a7d69dfe")
                        });
                });

            modelBuilder.Entity("StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity.UserLogin", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginIp")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("UserId1")
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.HasIndex("UserId1");

                    b.ToTable("UserLogin","Identity");
                });

            modelBuilder.Entity("StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity.UserRole", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("TEXT");

                    b.Property<string>("ReasonForAdding")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("RoleId1")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("UserId1")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("RoleId1");

                    b.HasIndex("UserId1");

                    b.ToTable("UserRole","Identity");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("035c6acd-3484-4dd5-acfd-4854a7d69dfe"),
                            RoleId = new Guid("619b607a-e5f5-4acb-9926-2afcb4de28bd"),
                            ReasonForAdding = "Created During Migration"
                        });
                });

            modelBuilder.Entity("StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity.UserToken", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("UserId1")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.HasIndex("UserId1");

                    b.ToTable("UserToken","Identity");
                });

            modelBuilder.Entity("StartupProject_Asp.NetCore_PostGRE.Data.Models.AppData.Order", b =>
                {
                    b.HasOne("StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity.User", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");
                });

            modelBuilder.Entity("StartupProject_Asp.NetCore_PostGRE.Data.Models.AppData.OrderProduct", b =>
                {
                    b.HasOne("StartupProject_Asp.NetCore_PostGRE.Data.Models.AppData.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId");

                    b.HasOne("StartupProject_Asp.NetCore_PostGRE.Data.Models.AppData.Order", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity.RoleClaim", b =>
                {
                    b.HasOne("StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity.Role", "Role")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity.UserClaim", b =>
                {
                    b.HasOne("StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity.User", null)
                        .WithMany("Claims")
                        .HasForeignKey("UserId1");
                });

            modelBuilder.Entity("StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity.UserLogin", b =>
                {
                    b.HasOne("StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity.User", null)
                        .WithMany("Logins")
                        .HasForeignKey("UserId1");
                });

            modelBuilder.Entity("StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity.UserRole", b =>
                {
                    b.HasOne("StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity.Role", null)
                        .WithMany("Users")
                        .HasForeignKey("RoleId1");

                    b.HasOne("StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity.User", null)
                        .WithMany("Roles")
                        .HasForeignKey("UserId1");
                });

            modelBuilder.Entity("StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity.UserToken", b =>
                {
                    b.HasOne("StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity.User", null)
                        .WithMany("UserTokens")
                        .HasForeignKey("UserId1");
                });
#pragma warning restore 612, 618
        }
    }
}
