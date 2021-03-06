// <auto-generated />
using System;
using MedicalCRM.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MedicalCRM.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220702023734_bloodSeed")]
    partial class bloodSeed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MedicalCRM.DataAccess.Entities.BloodType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("blood_type", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "1-положительная"
                        },
                        new
                        {
                            Id = 2,
                            Name = "2-положительная"
                        },
                        new
                        {
                            Id = 3,
                            Name = "3-положительная"
                        },
                        new
                        {
                            Id = 4,
                            Name = "4-положительная"
                        },
                        new
                        {
                            Id = 5,
                            Name = "1-отрицательная"
                        },
                        new
                        {
                            Id = 6,
                            Name = "2-отрицательная"
                        },
                        new
                        {
                            Id = 7,
                            Name = "3-отрицательная"
                        },
                        new
                        {
                            Id = 8,
                            Name = "4-отрицательная"
                        });
                });

            modelBuilder.Entity("MedicalCRM.DataAccess.Entities.Consultation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Diesases")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("DoctorId")
                        .HasColumnType("integer");

                    b.Property<int?>("PatientId")
                        .IsRequired()
                        .HasColumnType("integer");

                    b.Property<string>("Recommendations")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("Consultation");
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

            modelBuilder.Entity("MedicalCRM.DataAccess.Entities.Recept", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ConsultationId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ConsultationId")
                        .IsUnique();

                    b.ToTable("recept", (string)null);
                });

            modelBuilder.Entity("MedicalCRM.DataAccess.Entities.ReceptByMedicament", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<int>("Count")
                        .HasColumnType("int")
                        .HasColumnName("column");

                    b.Property<string>("MedicamentName")
                        .IsRequired()
                        .HasColumnType("varchar(700)")
                        .HasColumnName("medicament_name");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("varchar(700)")
                        .HasColumnName("note");

                    b.Property<int>("ReceptId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ReceptId");

                    b.ToTable("recept_by_medicament", (string)null);
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

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsActive")
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

                    b.Property<byte[]>("Image")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.HasIndex("DoctorDetailsId");

                    b.HasDiscriminator().HasValue("Doctor");
                });

            modelBuilder.Entity("MedicalCRM.DataAccess.Entities.UserEntities.PatientUser", b =>
                {
                    b.HasBaseType("MedicalCRM.DataAccess.Entities.UserEntities.User");

                    b.Property<string>("Address")
                        .HasColumnType("varchar(500)")
                        .HasColumnName("address");

                    b.Property<int?>("BloodTypeId")
                        .HasColumnType("int")
                        .HasColumnName("blood_type_id");

                    b.Property<int?>("DoctorUserId")
                        .HasColumnType("int")
                        .HasColumnName("doctor_id");

                    b.HasIndex("BloodTypeId");

                    b.HasIndex("DoctorUserId");

                    b.HasDiscriminator().HasValue("Patient");
                });

            modelBuilder.Entity("MedicalCRM.DataAccess.Entities.Consultation", b =>
                {
                    b.HasOne("MedicalCRM.DataAccess.Entities.UserEntities.DoctorUser", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId");

                    b.HasOne("MedicalCRM.DataAccess.Entities.UserEntities.PatientUser", "Patient")
                        .WithMany("Consultations")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.SetNull)
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

            modelBuilder.Entity("MedicalCRM.DataAccess.Entities.Recept", b =>
                {
                    b.HasOne("MedicalCRM.DataAccess.Entities.Consultation", "Consultation")
                        .WithOne("Recept")
                        .HasForeignKey("MedicalCRM.DataAccess.Entities.Recept", "ConsultationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Consultation");
                });

            modelBuilder.Entity("MedicalCRM.DataAccess.Entities.ReceptByMedicament", b =>
                {
                    b.HasOne("MedicalCRM.DataAccess.Entities.Recept", "Recept")
                        .WithMany("Medicaments")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("Recept");
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
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("DoctorDetails");
                });

            modelBuilder.Entity("MedicalCRM.DataAccess.Entities.UserEntities.PatientUser", b =>
                {
                    b.HasOne("MedicalCRM.DataAccess.Entities.BloodType", "BloodType")
                        .WithMany()
                        .HasForeignKey("BloodTypeId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("MedicalCRM.DataAccess.Entities.UserEntities.DoctorUser", "DoctorUser")
                        .WithOne()
                        .HasForeignKey("MedicalCRM.DataAccess.Entities.UserEntities.PatientUser", "DoctorUserId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("BloodType");

                    b.Navigation("DoctorUser");
                });

            modelBuilder.Entity("MedicalCRM.DataAccess.Entities.Consultation", b =>
                {
                    b.Navigation("Recept")
                        .IsRequired();
                });

            modelBuilder.Entity("MedicalCRM.DataAccess.Entities.Recept", b =>
                {
                    b.Navigation("Medicaments");
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

                    b.Navigation("Consultations");
                });
#pragma warning restore 612, 618
        }
    }
}
