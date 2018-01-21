﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using VendorInfrastructure;

namespace Vendor.API.Migrations
{
    [DbContext(typeof(VendorDBContext))]
    partial class VendorDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Vendor.Models.VendorModel.VendorDocument", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<byte[]>("DocumentContent");

                    b.Property<DateTime>("DocumentExpiry");

                    b.Property<string>("DocumentName");

                    b.Property<string>("DocumentType");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime>("UpdatedOn");

                    b.Property<int>("VendorMasterId");

                    b.HasKey("ID");

                    b.HasIndex("VendorMasterId");

                    b.ToTable("VendorDocuments");
                });

            modelBuilder.Entity("Vendor.Models.VendorModel.VendorMaster", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddressLine1");

                    b.Property<string>("AddressLine2");

                    b.Property<string>("City");

                    b.Property<string>("ContractNumber");

                    b.Property<string>("Country");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Email");

                    b.Property<string>("FaxNumber");

                    b.Property<string>("PrimaryContactEmail");

                    b.Property<string>("PrimaryContactNumber");

                    b.Property<string>("PrimaryContactPersonName");

                    b.Property<string>("SecondaryContactEmail");

                    b.Property<string>("SecondaryContactNumber");

                    b.Property<string>("SecondaryContactPersonName");

                    b.Property<string>("Title");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime>("UpdatedOn");

                    b.Property<string>("VendorName");

                    b.Property<string>("Website");

                    b.HasKey("ID");

                    b.ToTable("VendorMaster");
                });

            modelBuilder.Entity("Vendor.Models.VendorModel.VendorDocument", b =>
                {
                    b.HasOne("Vendor.Models.VendorModel.VendorMaster", "VendorMaster")
                        .WithMany("VendorDocuments")
                        .HasForeignKey("VendorMasterId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
