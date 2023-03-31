﻿// <auto-generated />
using System;
using IDM.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IDM.Infrastructure.Migrations
{
    [DbContext(typeof(IDMDbContext))]
    partial class IDMDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("IDM.Infrastructure.DataAccess.Entities.EmailAddress_MST", b =>
                {
                    b.Property<string>("EmailAddress")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmailType")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OwnerType")
                        .HasColumnType("int");

                    b.Property<int>("PrimaryFlag")
                        .HasColumnType("int");

                    b.Property<Guid>("RelationID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("EmailAddress");

                    b.ToTable("EmailAddress_MST");
                });

            modelBuilder.Entity("IDM.Infrastructure.DataAccess.Entities.EmailAddress_TRN", b =>
                {
                    b.Property<string>("RequestID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("EmailType")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OwnerType")
                        .HasColumnType("int");

                    b.Property<int>("PrimaryFlag")
                        .HasColumnType("int");

                    b.Property<Guid>("RelationID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("RequestID", "Number");

                    b.ToTable("EmailAddress_TRN");
                });

            modelBuilder.Entity("IDM.Infrastructure.DataAccess.Entities.Request_LST", b =>
                {
                    b.Property<string>("RequestID")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<Guid?>("ApproveBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ApproveDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FunctionID")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("RequestBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasMaxLength(2)
                        .HasColumnType("int");

                    b.HasKey("RequestID");

                    b.ToTable("Request_LST");
                });

            modelBuilder.Entity("IDM.Infrastructure.DataAccess.Entities.SecurityGroup_MST", b =>
                {
                    b.Property<Guid>("InternalID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Admin1InternalID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Admin2InternalID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Admin3InternalID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AliasName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("OwnerInternalID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("InternalID");

                    b.ToTable("SecurityGroup_MST");
                });

            modelBuilder.Entity("IDM.Infrastructure.DataAccess.Entities.SecurityGroup_TRN", b =>
                {
                    b.Property<string>("RequestID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("Admin1InternalID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Admin2InternalID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Admin3InternalID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AliasName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<Guid>("InternalID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("OwnerInternalID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("RequestID", "Number");

                    b.ToTable("SecurityGroup_TRN");
                });
#pragma warning restore 612, 618
        }
    }
}
