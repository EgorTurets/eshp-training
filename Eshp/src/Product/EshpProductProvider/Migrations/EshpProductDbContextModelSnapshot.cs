﻿// <auto-generated />
using System;
using EshpProductProvider;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EshpProductProvider.Migrations
{
    [DbContext(typeof(EshpProductDbContext))]
    partial class EshpProductDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EshpProductCommon.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Amount");

                    b.Property<string>("BaseDescription");

                    b.Property<int?>("BaseProductId");

                    b.Property<int?>("CompanyId");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int?>("Price");

                    b.Property<int?>("ProductId");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("EshpProductCommon.Product", b =>
                {
                    b.HasOne("EshpProductCommon.Product")
                        .WithMany("Offers")
                        .HasForeignKey("ProductId");
                });
#pragma warning restore 612, 618
        }
    }
}
