// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using StartupProject_Asp.NetCore_PostGRE.Data;

namespace StartupProject_Asp.NetCore_PostGRE.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20201208092708_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("public")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("Role","Identity");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e507c211-0ff1-4a1e-a744-c0cf30e96934"),
                            ConcurrencyStamp = "9d3a576f-a9c0-44c7-9f48-788680e06377",
                            Description = "12/8/2020 9:27:07 AM",
                            Name = "Super-Admin",
                            NormalizedName = "SUPER-ADMIN"
                        });
                });

            modelBuilder.Entity("StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity.RoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<Guid>("RoleId")
                        .HasColumnName("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaim","Identity");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            ClaimType = "SuperAdmin_All",
                            ClaimValue = "SuperAdmin.All",
                            RoleId = new Guid("e507c211-0ff1-4a1e-a744-c0cf30e96934")
                        },
                        new
                        {
                            Id = -2,
                            ClaimType = "Role_Create",
                            ClaimValue = "Role.Create",
                            RoleId = new Guid("e507c211-0ff1-4a1e-a744-c0cf30e96934")
                        },
                        new
                        {
                            Id = -3,
                            ClaimType = "Role_Read",
                            ClaimValue = "Role.Read",
                            RoleId = new Guid("e507c211-0ff1-4a1e-a744-c0cf30e96934")
                        },
                        new
                        {
                            Id = -4,
                            ClaimType = "Role_Update",
                            ClaimValue = "Role.Update",
                            RoleId = new Guid("e507c211-0ff1-4a1e-a744-c0cf30e96934")
                        },
                        new
                        {
                            Id = -5,
                            ClaimType = "Role_Delete",
                            ClaimValue = "Role.Delete",
                            RoleId = new Guid("e507c211-0ff1-4a1e-a744-c0cf30e96934")
                        },
                        new
                        {
                            Id = -6,
                            ClaimType = "Claim_Create",
                            ClaimValue = "Claim.Create",
                            RoleId = new Guid("e507c211-0ff1-4a1e-a744-c0cf30e96934")
                        });
                });

            modelBuilder.Entity("StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<byte[]>("ProfilePicture")
                        .HasColumnType("bytea");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<int>("UsernameChangeLimit")
                        .HasColumnType("integer");

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
                            Id = new Guid("503c13fb-3f62-43ee-a42b-9beb5b678939"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "66d8c20a-b7ad-4c25-8bae-afe301f3a72d",
                            Email = "abrar@jahin.com",
                            EmailConfirmed = true,
                            FirstName = "Abrar",
                            LastName = "Jahin",
                            LockoutEnabled = false,
                            NormalizedEmail = "ABRAR@JAHIN.COM",
                            NormalizedUserName = "ABRAR",
                            PasswordHash = "AQAAAAEAACcQAAAAEIvZj1REJRr5G9ehJD0eYPfa4BxlVngQ6ZcUsitZ4PMBTwpKDeR2T6Rv2rITpwLzEg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "637430380275976571_dbf7cdff-e9a1-411b-93a5-d88d5bfc65e8",
                            TwoFactorEnabled = false,
                            UserName = "abrar",
                            UsernameChangeLimit = 10
                        });
                });

            modelBuilder.Entity("StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity.UserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("UserId1")
                        .HasColumnType("uuid");

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
                            UserId = new Guid("503c13fb-3f62-43ee-a42b-9beb5b678939")
                        },
                        new
                        {
                            Id = -2,
                            ClaimType = "Role_Create",
                            ClaimValue = "Role.Create",
                            UserId = new Guid("503c13fb-3f62-43ee-a42b-9beb5b678939")
                        },
                        new
                        {
                            Id = -3,
                            ClaimType = "Role_Read",
                            ClaimValue = "Role.Read",
                            UserId = new Guid("503c13fb-3f62-43ee-a42b-9beb5b678939")
                        },
                        new
                        {
                            Id = -4,
                            ClaimType = "Role_Update",
                            ClaimValue = "Role.Update",
                            UserId = new Guid("503c13fb-3f62-43ee-a42b-9beb5b678939")
                        },
                        new
                        {
                            Id = -5,
                            ClaimType = "Role_Delete",
                            ClaimValue = "Role.Delete",
                            UserId = new Guid("503c13fb-3f62-43ee-a42b-9beb5b678939")
                        },
                        new
                        {
                            Id = -6,
                            ClaimType = "Claim_Create",
                            ClaimValue = "Claim.Create",
                            UserId = new Guid("503c13fb-3f62-43ee-a42b-9beb5b678939")
                        });
                });

            modelBuilder.Entity("StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity.UserLogin", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("LoginIp")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("UserId1")
                        .HasColumnType("uuid");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.HasIndex("UserId1");

                    b.ToTable("UserLogin","Identity");
                });

            modelBuilder.Entity("StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity.UserRole", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.Property<string>("ReasonForAdding")
                        .HasColumnType("text");

                    b.Property<Guid?>("RoleId1")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("UserId1")
                        .HasColumnType("uuid");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("RoleId1");

                    b.HasIndex("UserId1");

                    b.ToTable("UserRole","Identity");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("503c13fb-3f62-43ee-a42b-9beb5b678939"),
                            RoleId = new Guid("e507c211-0ff1-4a1e-a744-c0cf30e96934"),
                            ReasonForAdding = "Created During Migration"
                        });
                });

            modelBuilder.Entity("StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity.UserToken", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<Guid?>("UserId1")
                        .HasColumnType("uuid");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.HasIndex("UserId1");

                    b.ToTable("UserToken","Identity");
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
