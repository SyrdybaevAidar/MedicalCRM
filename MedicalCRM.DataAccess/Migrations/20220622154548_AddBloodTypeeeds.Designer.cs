﻿// <auto-generated />
using System;
using MedicalCRM.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MedicalCRM.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220622154548_AddBloodTypeeeds")]
    partial class AddBloodTypeeeds
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("consultation_by_disaeses", b =>
                {
                    b.Property<int>("ChronicalDiseasesId")
                        .HasColumnType("integer");

                    b.Property<int>("ConsultationsId")
                        .HasColumnType("integer");

                    b.HasKey("ChronicalDiseasesId", "ConsultationsId");

                    b.HasIndex("ConsultationsId");

                    b.ToTable("consultation_by_disaeses");
                });

            modelBuilder.Entity("MedicalCRM.DataAccess.Entities.BloodType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("RhesusFactore")
                        .HasColumnType("int")
                        .HasColumnName("rhesus_factore");

                    b.Property<int>("Type")
                        .HasColumnType("int")
                        .HasColumnName("type");

                    b.HasKey("Id");

                    b.ToTable("blood_type", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RhesusFactore = 0,
                            Type = 1
                        },
                        new
                        {
                            Id = 2,
                            RhesusFactore = 0,
                            Type = 2
                        },
                        new
                        {
                            Id = 3,
                            RhesusFactore = 0,
                            Type = 3
                        },
                        new
                        {
                            Id = 4,
                            RhesusFactore = 0,
                            Type = 4
                        });
                });

            modelBuilder.Entity("MedicalCRM.DataAccess.Entities.Consultation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DoctorId")
                        .HasColumnType("integer");

                    b.Property<int>("PatientId")
                        .HasColumnType("integer");

                    b.Property<string>("Recommendations")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("Consultation");
                });

            modelBuilder.Entity("MedicalCRM.DataAccess.Entities.Disease", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("int");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(500)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("disease", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Гайморит"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Ангина"
                        });
                });

            modelBuilder.Entity("MedicalCRM.DataAccess.Entities.DoctorDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DoctorId")
                        .HasColumnType("integer");

                    b.Property<int>("PositionId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PositionId");

                    b.ToTable("DoctorDetails");
                });

            modelBuilder.Entity("MedicalCRM.DataAccess.Entities.MedicalCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("varchar(700)")
                        .HasColumnName("address");

                    b.Property<int>("BloodTypeId")
                        .HasColumnType("int")
                        .HasColumnName("blood_type_id");

                    b.Property<string>("FamilyDoctorName")
                        .IsRequired()
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("varchar(700)")
                        .HasColumnName("address");

                    b.HasKey("Id");

                    b.HasIndex("BloodTypeId");

                    b.ToTable("medical_card", (string)null);
                });

            modelBuilder.Entity("MedicalCRM.DataAccess.Entities.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("int");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(500)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("Position", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Врач терапевт"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Хирург"
                        });
                });

            modelBuilder.Entity("MedicalCRM.DataAccess.Entities.UserEntities.ChatEntities.Chat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DoctorId")
                        .HasColumnType("int")
                        .HasColumnName("doctor_id");

                    b.Property<int>("PatientId")
                        .HasColumnType("int")
                        .HasColumnName("patient_id");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("chat", (string)null);
                });

            modelBuilder.Entity("MedicalCRM.DataAccess.Entities.UserEntities.ChatEntities.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ChatId")
                        .HasColumnType("int")
                        .HasColumnName("chat_id");

                    b.Property<bool>("IsRead")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("is_read");

                    b.Property<DateTime>("SendDate")
                        .HasColumnType("TIMESTAMP")
                        .HasColumnName("send_date");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("varchar(700)")
                        .HasColumnName("text");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("ChatId");

                    b.ToTable("message", (string)null);
                });

            modelBuilder.Entity("MedicalCRM.DataAccess.Entities.UserEntities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("TIMESTAMP")
                        .HasColumnName("birth_date");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("Patronimic")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<int>("Sex")
                        .HasColumnType("integer");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasColumnType("varchar(10)")
                        .HasColumnName("user_type");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("UserType").IsComplete(true).HasValue("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("MedicalCRM.DataAccess.Entities.UserEntities.AdminUser", b =>
                {
                    b.HasBaseType("MedicalCRM.DataAccess.Entities.UserEntities.User");

                    b.HasDiscriminator().HasValue("Admin");
                });

            modelBuilder.Entity("MedicalCRM.DataAccess.Entities.UserEntities.DoctorUser", b =>
                {
                    b.HasBaseType("MedicalCRM.DataAccess.Entities.UserEntities.User");

                    b.Property<int?>("DoctorDetailsId")
                        .HasColumnType("int")
                        .HasColumnName("doctor_details_id");

                    b.HasIndex("DoctorDetailsId")
                        .IsUnique();

                    b.HasDiscriminator().HasValue("Doctor");
                });

            modelBuilder.Entity("MedicalCRM.DataAccess.Entities.UserEntities.PatientUser", b =>
                {
                    b.HasBaseType("MedicalCRM.DataAccess.Entities.UserEntities.User");

                    b.Property<int?>("MedicalCardId")
                        .HasColumnType("int")
                        .HasColumnName("medical_card_id");

                    b.HasIndex("MedicalCardId")
                        .IsUnique();

                    b.HasDiscriminator().HasValue("Patient");
                });

            modelBuilder.Entity("consultation_by_disaeses", b =>
                {
                    b.HasOne("MedicalCRM.DataAccess.Entities.Disease", null)
                        .WithMany()
                        .HasForeignKey("ChronicalDiseasesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedicalCRM.DataAccess.Entities.Consultation", null)
                        .WithMany()
                        .HasForeignKey("ConsultationsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MedicalCRM.DataAccess.Entities.Consultation", b =>
                {
                    b.HasOne("MedicalCRM.DataAccess.Entities.UserEntities.DoctorUser", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedicalCRM.DataAccess.Entities.UserEntities.PatientUser", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("MedicalCRM.DataAccess.Entities.DoctorDetails", b =>
                {
                    b.HasOne("MedicalCRM.DataAccess.Entities.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Position");
                });

            modelBuilder.Entity("MedicalCRM.DataAccess.Entities.MedicalCard", b =>
                {
                    b.HasOne("MedicalCRM.DataAccess.Entities.BloodType", "BloodType")
                        .WithMany()
                        .HasForeignKey("BloodTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("BloodType");
                });

            modelBuilder.Entity("MedicalCRM.DataAccess.Entities.UserEntities.ChatEntities.Chat", b =>
                {
                    b.HasOne("MedicalCRM.DataAccess.Entities.UserEntities.DoctorUser", "Doctor")
                        .WithMany("Chats")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.HasOne("MedicalCRM.DataAccess.Entities.UserEntities.PatientUser", "Patient")
                        .WithMany("Chats")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("MedicalCRM.DataAccess.Entities.UserEntities.ChatEntities.Message", b =>
                {
                    b.HasOne("MedicalCRM.DataAccess.Entities.UserEntities.ChatEntities.Chat", "Chat")
                        .WithMany("Messages")
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Chat");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("MedicalCRM.DataAccess.Entities.UserEntities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("MedicalCRM.DataAccess.Entities.UserEntities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MedicalCRM.DataAccess.Entities.UserEntities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("MedicalCRM.DataAccess.Entities.UserEntities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MedicalCRM.DataAccess.Entities.UserEntities.DoctorUser", b =>
                {
                    b.HasOne("MedicalCRM.DataAccess.Entities.DoctorDetails", "DoctorDetails")
                        .WithOne()
                        .HasForeignKey("MedicalCRM.DataAccess.Entities.UserEntities.DoctorUser", "DoctorDetailsId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("DoctorDetails");
                });

            modelBuilder.Entity("MedicalCRM.DataAccess.Entities.UserEntities.PatientUser", b =>
                {
                    b.HasOne("MedicalCRM.DataAccess.Entities.MedicalCard", "MedicalCard")
                        .WithOne()
                        .HasForeignKey("MedicalCRM.DataAccess.Entities.UserEntities.PatientUser", "MedicalCardId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("MedicalCard");
                });

            modelBuilder.Entity("MedicalCRM.DataAccess.Entities.UserEntities.ChatEntities.Chat", b =>
                {
                    b.Navigation("Messages");
                });

            modelBuilder.Entity("MedicalCRM.DataAccess.Entities.UserEntities.DoctorUser", b =>
                {
                    b.Navigation("Chats");
                });

            modelBuilder.Entity("MedicalCRM.DataAccess.Entities.UserEntities.PatientUser", b =>
                {
                    b.Navigation("Chats");
                });
#pragma warning restore 612, 618
        }
    }
}