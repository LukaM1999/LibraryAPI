﻿// <auto-generated />
using System;
using LibraryCL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LibraryCL.Migrations
{
    [DbContext(typeof(LibraryDbContext))]
    [Migration("20230222083558_SoftDeleteMigration")]
    partial class SoftDeleteMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("LibraryCL.Model.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Author");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2023, 2, 22, 8, 35, 58, 632, DateTimeKind.Utc).AddTicks(1506),
                            Deleted = false,
                            FirstName = "Tom",
                            LastName = "Paice",
                            ModifiedDate = new DateTime(2023, 2, 22, 8, 35, 58, 632, DateTimeKind.Utc).AddTicks(1506)
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2023, 2, 22, 8, 35, 58, 632, DateTimeKind.Utc).AddTicks(1508),
                            Deleted = false,
                            FirstName = "Bob",
                            LastName = "Vance",
                            ModifiedDate = new DateTime(2023, 2, 22, 8, 35, 58, 632, DateTimeKind.Utc).AddTicks(1508)
                        },
                        new
                        {
                            Id = 3,
                            Created = new DateTime(2023, 2, 22, 8, 35, 58, 632, DateTimeKind.Utc).AddTicks(1509),
                            Deleted = false,
                            FirstName = "Nick",
                            LastName = "Chapsas",
                            ModifiedDate = new DateTime(2023, 2, 22, 8, 35, 58, 632, DateTimeKind.Utc).AddTicks(1509)
                        });
                });

            modelBuilder.Entity("LibraryCL.Model.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Book");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 1,
                            Created = new DateTime(2023, 2, 22, 8, 35, 58, 632, DateTimeKind.Utc).AddTicks(1598),
                            Deleted = false,
                            ModifiedDate = new DateTime(2023, 2, 22, 8, 35, 58, 632, DateTimeKind.Utc).AddTicks(1598),
                            Name = "Marvelous Tale of Time"
                        },
                        new
                        {
                            Id = 2,
                            AuthorId = 1,
                            Created = new DateTime(2023, 2, 22, 8, 35, 58, 632, DateTimeKind.Utc).AddTicks(1599),
                            Deleted = false,
                            ModifiedDate = new DateTime(2023, 2, 22, 8, 35, 58, 632, DateTimeKind.Utc).AddTicks(1599),
                            Name = "Marvelous Tale of Space"
                        },
                        new
                        {
                            Id = 3,
                            AuthorId = 2,
                            Created = new DateTime(2023, 2, 22, 8, 35, 58, 632, DateTimeKind.Utc).AddTicks(1600),
                            Deleted = false,
                            ModifiedDate = new DateTime(2023, 2, 22, 8, 35, 58, 632, DateTimeKind.Utc).AddTicks(1600),
                            Name = "Refrigeration 101"
                        },
                        new
                        {
                            Id = 4,
                            AuthorId = 3,
                            Created = new DateTime(2023, 2, 22, 8, 35, 58, 632, DateTimeKind.Utc).AddTicks(1600),
                            Deleted = true,
                            ModifiedDate = new DateTime(2023, 2, 22, 8, 35, 58, 632, DateTimeKind.Utc).AddTicks(1601),
                            Name = "Programming 101"
                        });
                });

            modelBuilder.Entity("LibraryCL.Model.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "2c6f174e-3b0e-446f-86af-483d56fd7210",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "a0723a84-1bdf-43fa-9737-b617eda8779a",
                            CreatedDate = new DateTime(2023, 2, 22, 8, 35, 58, 629, DateTimeKind.Utc).AddTicks(9652),
                            Email = "admin@mail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            ModifiedDate = new DateTime(2023, 2, 22, 8, 35, 58, 629, DateTimeKind.Utc).AddTicks(9653),
                            NormalizedEmail = "ADMIN@MAIL.COM",
                            NormalizedUserName = "ADMIN@MAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEFlyaJD2fJ9czKDU2MiOOxMDs+jqPm64BEUR8dAYAYHcRAXq8fldBTkw8lNbnrRkrA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "74dadc65-91ec-48c6-8a22-15853d195fda",
                            TwoFactorEnabled = false,
                            UserName = "admin@mail.com"
                        },
                        new
                        {
                            Id = "3b7g174e-3b0e-446f-86af-483d56fd7210",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "40dd5a97-3a21-4375-9cf7-ff3809cdbefe",
                            CreatedDate = new DateTime(2023, 2, 22, 8, 35, 58, 629, DateTimeKind.Utc).AddTicks(9659),
                            Email = "user@mail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            ModifiedDate = new DateTime(2023, 2, 22, 8, 35, 58, 629, DateTimeKind.Utc).AddTicks(9659),
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "53c52020-c316-4779-8f1e-6faf908c35ea",
                            TwoFactorEnabled = false,
                            UserName = "user@mail.com"
                        },
                        new
                        {
                            Id = "4a8h174e-3b0e-446f-86af-483d56fd7210",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "10276fa4-c0ab-499d-8d57-e00bd9849538",
                            CreatedDate = new DateTime(2023, 2, 22, 8, 35, 58, 629, DateTimeKind.Utc).AddTicks(9672),
                            Email = "librarian@mail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            ModifiedDate = new DateTime(2023, 2, 22, 8, 35, 58, 629, DateTimeKind.Utc).AddTicks(9673),
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "fa5211c1-15fa-436d-8e9a-b57cbe1eeda2",
                            TwoFactorEnabled = false,
                            UserName = "librarian@mail.com"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                            ConcurrencyStamp = "a7380991-3741-4031-8ebf-1aaebd4df374",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "3b5e174e-3b0e-446f-86af-483d56fd7210",
                            ConcurrencyStamp = "300df285-01a8-4f6b-8529-44a826529b15",
                            Name = "User",
                            NormalizedName = "USER"
                        },
                        new
                        {
                            Id = "4a5e174e-3b0e-446f-86af-483d56fd7210",
                            ConcurrencyStamp = "0a5dd486-8ac2-4a24-9cab-3fac9efdf054",
                            Name = "Librarian",
                            NormalizedName = "LIBRARIAN"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "2c6f174e-3b0e-446f-86af-483d56fd7210",
                            RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210"
                        },
                        new
                        {
                            UserId = "3b7g174e-3b0e-446f-86af-483d56fd7210",
                            RoleId = "3b5e174e-3b0e-446f-86af-483d56fd7210"
                        },
                        new
                        {
                            UserId = "4a8h174e-3b0e-446f-86af-483d56fd7210",
                            RoleId = "4a5e174e-3b0e-446f-86af-483d56fd7210"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("LibraryCL.Model.Book", b =>
                {
                    b.HasOne("LibraryCL.Model.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("LibraryCL.Model.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("LibraryCL.Model.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryCL.Model.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("LibraryCL.Model.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LibraryCL.Model.Author", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}