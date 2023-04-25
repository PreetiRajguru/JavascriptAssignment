﻿// <auto-generated />
using MatterAssignment.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MatterAssignment.Data.Migrations
{
    [DbContext(typeof(MatterAssignmentDbContext))]
    partial class MatterAssignmentDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MatterAssignment.Data.Models.Attorney", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("JurisdictionId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("JurisdictionId")
                        .IsUnique();

                    b.ToTable("Attorneys");
                });

            modelBuilder.Entity("MatterAssignment.Data.Models.AttorneyRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AttorneyId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("RoleMasterId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AttorneyId");

                    b.ToTable("AttorneyRole");
                });

            modelBuilder.Entity("MatterAssignment.Data.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("PhoneNumber")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("MatterAssignment.Data.Models.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AttorneyId")
                        .HasColumnType("int");

                    b.Property<decimal>("HoursWorked")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("MatterId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AttorneyId");

                    b.HasIndex("MatterId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("MatterAssignment.Data.Models.JurisdictionMaster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("JurisdictionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("JurisdictionMaster");
                });

            modelBuilder.Entity("MatterAssignment.Data.Models.Matter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BillingAttorneyId")
                        .HasColumnType("int");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("JurisdictionId")
                        .HasColumnType("int");

                    b.Property<int>("ResponsibleAttorneyId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("JurisdictionId")
                        .IsUnique();

                    b.HasIndex("ResponsibleAttorneyId");

                    b.ToTable("Matters");
                });

            modelBuilder.Entity("MatterAssignment.Data.Models.RoleMaster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RoleMaster");
                });

            modelBuilder.Entity("MatterAssignment.Data.Models.Attorney", b =>
                {
                    b.HasOne("MatterAssignment.Data.Models.JurisdictionMaster", "Jurisdiction")
                        .WithOne("Attorney")
                        .HasForeignKey("MatterAssignment.Data.Models.Attorney", "JurisdictionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Jurisdiction");
                });

            modelBuilder.Entity("MatterAssignment.Data.Models.AttorneyRole", b =>
                {
                    b.HasOne("MatterAssignment.Data.Models.Attorney", "Attorney")
                        .WithMany("AttorneyRoles")
                        .HasForeignKey("AttorneyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MatterAssignment.Data.Models.RoleMaster", "RoleMaster")
                        .WithMany("AttorneyRoles")
                        .HasForeignKey("AttorneyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Attorney");

                    b.Navigation("RoleMaster");
                });

            modelBuilder.Entity("MatterAssignment.Data.Models.Invoice", b =>
                {
                    b.HasOne("MatterAssignment.Data.Models.Attorney", "Attorney")
                        .WithMany("Invoices")
                        .HasForeignKey("AttorneyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MatterAssignment.Data.Models.Matter", "Matter")
                        .WithMany("Invoices")
                        .HasForeignKey("MatterId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Attorney");

                    b.Navigation("Matter");
                });

            modelBuilder.Entity("MatterAssignment.Data.Models.Matter", b =>
                {
                    b.HasOne("MatterAssignment.Data.Models.Client", "Client")
                        .WithMany("Matters")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MatterAssignment.Data.Models.JurisdictionMaster", "Jurisdiction")
                        .WithOne("Matter")
                        .HasForeignKey("MatterAssignment.Data.Models.Matter", "JurisdictionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MatterAssignment.Data.Models.Attorney", "Attorney")
                        .WithMany("Matters")
                        .HasForeignKey("ResponsibleAttorneyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Attorney");

                    b.Navigation("Client");

                    b.Navigation("Jurisdiction");
                });

            modelBuilder.Entity("MatterAssignment.Data.Models.Attorney", b =>
                {
                    b.Navigation("AttorneyRoles");

                    b.Navigation("Invoices");

                    b.Navigation("Matters");
                });

            modelBuilder.Entity("MatterAssignment.Data.Models.Client", b =>
                {
                    b.Navigation("Matters");
                });

            modelBuilder.Entity("MatterAssignment.Data.Models.JurisdictionMaster", b =>
                {
                    b.Navigation("Attorney")
                        .IsRequired();

                    b.Navigation("Matter")
                        .IsRequired();
                });

            modelBuilder.Entity("MatterAssignment.Data.Models.Matter", b =>
                {
                    b.Navigation("Invoices");
                });

            modelBuilder.Entity("MatterAssignment.Data.Models.RoleMaster", b =>
                {
                    b.Navigation("AttorneyRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
