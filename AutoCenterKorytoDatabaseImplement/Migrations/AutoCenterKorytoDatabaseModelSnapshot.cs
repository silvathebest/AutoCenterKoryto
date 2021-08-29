﻿// <auto-generated />
using System;
using AutoCenterKorytoDatabaseImplement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AutoCenterKorytoDatabaseImplement.Migrations
{
    [DbContext(typeof(AutoCenterKorytoDatabase))]
    partial class AutoCenterKorytoDatabaseModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AutoCenterKorytoDatabaseImplement.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ColorName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("WorkerId")
                        .HasColumnType("int");

                    b.Property<int>("YearCreation")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WorkerId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("AutoCenterKorytoDatabaseImplement.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FIO")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("AutoCenterKorytoDatabaseImplement.Models.ClientWishes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PrePurchaseWorksId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("PrePurchaseWorksId");

                    b.ToTable("ClientWishes");
                });

            modelBuilder.Entity("AutoCenterKorytoDatabaseImplement.Models.Complectation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("WorkerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WorkerId");

                    b.ToTable("Complectations");
                });

            modelBuilder.Entity("AutoCenterKorytoDatabaseImplement.Models.Complectation_Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<int>("ComplectationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("ComplectationId");

                    b.ToTable("Complectation_Cars");
                });

            modelBuilder.Entity("AutoCenterKorytoDatabaseImplement.Models.Features", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<int>("WorkerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("WorkerId");

                    b.ToTable("Features");
                });

            modelBuilder.Entity("AutoCenterKorytoDatabaseImplement.Models.PrePurchaseWorks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("DeadlineDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("PrePurchaseWorks");
                });

            modelBuilder.Entity("AutoCenterKorytoDatabaseImplement.Models.PrePurchaseWorks_Complectation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ComplectationId")
                        .HasColumnType("int");

                    b.Property<int>("PrePurchaseWorksId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ComplectationId");

                    b.HasIndex("PrePurchaseWorksId");

                    b.ToTable("PrePurchaseWorks_Complectations");
                });

            modelBuilder.Entity("AutoCenterKorytoDatabaseImplement.Models.Purchase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateDelivery")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Purchases");
                });

            modelBuilder.Entity("AutoCenterKorytoDatabaseImplement.Models.Purchase_Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<int>("PurchaseId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("PurchaseId");

                    b.ToTable("Purchase_Cars");
                });

            modelBuilder.Entity("AutoCenterKorytoDatabaseImplement.Models.Purchase_PrePurchaseWorks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PrePurchaseWorksId")
                        .HasColumnType("int");

                    b.Property<int>("PurchaseId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PrePurchaseWorksId");

                    b.HasIndex("PurchaseId");

                    b.ToTable("Purchase_PrePurchaseWorks");
                });

            modelBuilder.Entity("AutoCenterKorytoDatabaseImplement.Models.Worker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FIO")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Workers");
                });

            modelBuilder.Entity("AutoCenterKorytoDatabaseImplement.Models.Car", b =>
                {
                    b.HasOne("AutoCenterKorytoDatabaseImplement.Models.Worker", "Worker")
                        .WithMany("Cars")
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AutoCenterKorytoDatabaseImplement.Models.ClientWishes", b =>
                {
                    b.HasOne("AutoCenterKorytoDatabaseImplement.Models.Client", "Client")
                        .WithMany("ClientWishes")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutoCenterKorytoDatabaseImplement.Models.PrePurchaseWorks", "PrePurchaseWorks")
                        .WithMany("ClientWishes")
                        .HasForeignKey("PrePurchaseWorksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AutoCenterKorytoDatabaseImplement.Models.Complectation", b =>
                {
                    b.HasOne("AutoCenterKorytoDatabaseImplement.Models.Worker", "Worker")
                        .WithMany("Complectations")
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AutoCenterKorytoDatabaseImplement.Models.Complectation_Car", b =>
                {
                    b.HasOne("AutoCenterKorytoDatabaseImplement.Models.Car", "Car")
                        .WithMany("Complectation_Cars")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutoCenterKorytoDatabaseImplement.Models.Complectation", "Complectation")
                        .WithMany("Complectation_Cars")
                        .HasForeignKey("ComplectationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AutoCenterKorytoDatabaseImplement.Models.Features", b =>
                {
                    b.HasOne("AutoCenterKorytoDatabaseImplement.Models.Car", "Car")
                        .WithMany("Features")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutoCenterKorytoDatabaseImplement.Models.Worker", "Worker")
                        .WithMany("Features")
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AutoCenterKorytoDatabaseImplement.Models.PrePurchaseWorks", b =>
                {
                    b.HasOne("AutoCenterKorytoDatabaseImplement.Models.Client", "Client")
                        .WithMany("PrePurchaseWorks")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AutoCenterKorytoDatabaseImplement.Models.PrePurchaseWorks_Complectation", b =>
                {
                    b.HasOne("AutoCenterKorytoDatabaseImplement.Models.Complectation", "Complectation")
                        .WithMany("PrePurchaseWorks_Complectations")
                        .HasForeignKey("ComplectationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutoCenterKorytoDatabaseImplement.Models.PrePurchaseWorks", "PrePurchaseWorks")
                        .WithMany("PrePurchaseWorks_Complectations")
                        .HasForeignKey("PrePurchaseWorksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AutoCenterKorytoDatabaseImplement.Models.Purchase", b =>
                {
                    b.HasOne("AutoCenterKorytoDatabaseImplement.Models.Client", "Client")
                        .WithMany("Purchases")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AutoCenterKorytoDatabaseImplement.Models.Purchase_Car", b =>
                {
                    b.HasOne("AutoCenterKorytoDatabaseImplement.Models.Car", "Car")
                        .WithMany("Purchase_Cars")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutoCenterKorytoDatabaseImplement.Models.Purchase", "Purchase")
                        .WithMany("Purchase_Cars")
                        .HasForeignKey("PurchaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AutoCenterKorytoDatabaseImplement.Models.Purchase_PrePurchaseWorks", b =>
                {
                    b.HasOne("AutoCenterKorytoDatabaseImplement.Models.PrePurchaseWorks", "PrePurchaseWorks")
                        .WithMany("Purchase_PrePurchaseWorks")
                        .HasForeignKey("PrePurchaseWorksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutoCenterKorytoDatabaseImplement.Models.Purchase", "Purchase")
                        .WithMany("Purchase_PrePurchaseWorks")
                        .HasForeignKey("PurchaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
