﻿// <auto-generated />
using System;
using DynamicFormBuilder.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DynamicFormBuilder.Persistence.Migrations
{
    [DbContext(typeof(DynamicFormBuilderDbContext))]
    [Migration("20231021212828_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.HasSequence<int>("DynamicFormBuilderSequence");

            modelBuilder.Entity("DynamicFormBuilder.Domain.Entities.FieldData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CreatedById")
                        .HasColumnType("int")
                        .HasColumnOrder(3);

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(2);

                    b.Property<string>("DisplatName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FieldSpecId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnOrder(6);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UpdatedById")
                        .HasColumnType("int")
                        .HasColumnOrder(5);

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(4);

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FieldSpecId");

                    b.ToTable("FieldData");
                });

            modelBuilder.Entity("DynamicFormBuilder.Domain.Entities.FieldSpec", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AdditionalAttribute")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Caption")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CreatedById")
                        .HasColumnType("int")
                        .HasColumnOrder(3);

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(2);

                    b.Property<byte?>("ElementInputTypeId")
                        .HasColumnType("tinyint");

                    b.Property<byte>("ElementTypeId")
                        .HasColumnType("tinyint");

                    b.Property<int>("FormSpecId")
                        .HasColumnType("int");

                    b.Property<string>("InputName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnOrder(6);

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<int?>("UpdatedById")
                        .HasColumnType("int")
                        .HasColumnOrder(5);

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(4);

                    b.HasKey("Id");

                    b.HasIndex("FormSpecId");

                    b.ToTable("FieldSpec");
                });

            modelBuilder.Entity("DynamicFormBuilder.Domain.Entities.FormSpec", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AdditionalAttribute")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CreatedById")
                        .HasColumnType("int")
                        .HasColumnOrder(3);

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(2);

                    b.Property<DateTime?>("FinishDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnOrder(6);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UpdatedById")
                        .HasColumnType("int")
                        .HasColumnOrder(5);

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(4);

                    b.HasKey("Id");

                    b.ToTable("FormSpec");
                });

            modelBuilder.Entity("DynamicFormBuilder.Domain.Entities.FormSubmission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CreatedById")
                        .HasColumnType("int")
                        .HasColumnOrder(3);

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(2);

                    b.Property<int>("FormSpecId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnOrder(6);

                    b.Property<string>("Payload")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UpdatedById")
                        .HasColumnType("int")
                        .HasColumnOrder(5);

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(4);

                    b.HasKey("Id");

                    b.HasIndex("FormSpecId");

                    b.ToTable("FormSubmission");
                });

            modelBuilder.Entity("DynamicFormBuilder.Domain.Entities.FieldData", b =>
                {
                    b.HasOne("DynamicFormBuilder.Domain.Entities.FieldSpec", "FieldSpec")
                        .WithMany("FieldDatas")
                        .HasForeignKey("FieldSpecId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("FieldSpec");
                });

            modelBuilder.Entity("DynamicFormBuilder.Domain.Entities.FieldSpec", b =>
                {
                    b.HasOne("DynamicFormBuilder.Domain.Entities.FormSpec", "FormSpec")
                        .WithMany("FieldSpecs")
                        .HasForeignKey("FormSpecId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("FormSpec");
                });

            modelBuilder.Entity("DynamicFormBuilder.Domain.Entities.FormSubmission", b =>
                {
                    b.HasOne("DynamicFormBuilder.Domain.Entities.FormSpec", "FormSpec")
                        .WithMany("FormSubmissions")
                        .HasForeignKey("FormSpecId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("FormSpec");
                });

            modelBuilder.Entity("DynamicFormBuilder.Domain.Entities.FieldSpec", b =>
                {
                    b.Navigation("FieldDatas");
                });

            modelBuilder.Entity("DynamicFormBuilder.Domain.Entities.FormSpec", b =>
                {
                    b.Navigation("FieldSpecs");

                    b.Navigation("FormSubmissions");
                });
#pragma warning restore 612, 618
        }
    }
}