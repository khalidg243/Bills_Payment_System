﻿// <auto-generated />
using System;
using BPS_API.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bills_Payment_API.Migrations
{
    [DbContext(typeof(BPS_dbcontext))]
    [Migration("20240731122417_newInitialMig")]
    partial class newInitialMig
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BPS_Shared.Models.Bill", b =>
                {
                    b.Property<int>("B_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("B_Id"));

                    b.Property<float>("B_Amount")
                        .HasColumnType("real");

                    b.Property<DateTime?>("B_CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("B_DueDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("B_Status")
                        .HasColumnType("bit");

                    b.Property<int>("Company_Id")
                        .HasColumnType("int");

                    b.Property<int>("Customer_Id")
                        .HasColumnType("int");

                    b.HasKey("B_Id");

                    b.HasIndex("Company_Id");

                    b.HasIndex("Customer_Id");

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("BPS_Shared.Models.Company", b =>
                {
                    b.Property<int>("CP_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CP_Id"));

                    b.Property<string>("CP_Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CP_Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("CP_Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("CP_Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CP_Id");

                    b.HasIndex("CP_Email", "CP_Phone")
                        .IsUnique();

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("BPS_Shared.Models.Customer", b =>
                {
                    b.Property<int>("C_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("C_Id"));

                    b.Property<string>("C_Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("C_Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("C_Passport_No")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("C_Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("C_Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("C_Id");

                    b.HasIndex("C_Passport_No", "C_Email", "C_Phone")
                        .IsUnique();

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("BPS_Shared.Models.Bill", b =>
                {
                    b.HasOne("BPS_Shared.Models.Company", null)
                        .WithMany("Bills")
                        .HasForeignKey("Company_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BPS_Shared.Models.Customer", null)
                        .WithMany("Bills")
                        .HasForeignKey("Customer_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BPS_Shared.Models.Company", b =>
                {
                    b.Navigation("Bills");
                });

            modelBuilder.Entity("BPS_Shared.Models.Customer", b =>
                {
                    b.Navigation("Bills");
                });
#pragma warning restore 612, 618
        }
    }
}
