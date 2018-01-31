﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Order.Infrastructure;
using System;

namespace Order.API.Migrations
{
    [DbContext(typeof(OrderDBContext))]
    [Migration("20180131155401_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Order.Domain.Models.OrderModel.OrderLineItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("ItemNumber");

                    b.Property<string>("OrderID");

                    b.Property<int>("OrderMasterID");

                    b.Property<int>("Quantity");

                    b.Property<decimal>("TotalPrice");

                    b.Property<string>("Unit");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("Id");

                    b.HasIndex("OrderMasterID");

                    b.ToTable("OrderLineItems");
                });

            modelBuilder.Entity("Order.Domain.Models.OrderModel.OrderMaster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Currency");

                    b.Property<DateTime>("OrderDate");

                    b.Property<string>("OrderNumber");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime>("UpdatedOn");

                    b.Property<int>("VendorID");

                    b.HasKey("Id");

                    b.ToTable("OrderMaster");
                });

            modelBuilder.Entity("Order.Domain.Models.OrderModel.OrderLineItem", b =>
                {
                    b.HasOne("Order.Domain.Models.OrderModel.OrderMaster", "Order")
                        .WithMany()
                        .HasForeignKey("OrderMasterID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
