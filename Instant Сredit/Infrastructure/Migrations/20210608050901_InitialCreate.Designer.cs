﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210608050901_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Domain.Entities.Borrower", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Age")
                        .HasColumnType("integer");

                    b.Property<decimal>("CreditAmount")
                        .HasColumnType("numeric");

                    b.Property<int>("CreditPurpose")
                        .HasColumnType("integer");

                    b.Property<int>("GetEmployment")
                        .HasColumnType("integer");

                    b.Property<int>("GetPledge")
                        .HasColumnType("integer");

                    b.Property<bool>("IsConvicted")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("Borrowers");
                });

            modelBuilder.Entity("Domain.Entities.Credit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<Guid?>("BorrowerId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("BorrowerId");

                    b.ToTable("Credits");
                });

            modelBuilder.Entity("Domain.Entities.Borrower", b =>
                {
                    b.OwnsOne("Domain.ValueObjects.FullName", "FullName", b1 =>
                        {
                            b1.Property<Guid>("BorrowerId")
                                .HasColumnType("uuid");

                            b1.Property<string>("FirstName")
                                .HasColumnType("text")
                                .HasColumnName("FirstName");

                            b1.Property<string>("LastName")
                                .HasColumnType("text")
                                .HasColumnName("LastName");

                            b1.Property<string>("MiddleName")
                                .HasColumnType("text")
                                .HasColumnName("MiddleName");

                            b1.HasKey("BorrowerId");

                            b1.ToTable("Borrowers");

                            b1.WithOwner()
                                .HasForeignKey("BorrowerId");
                        });

                    b.OwnsOne("Domain.ValueObjects.Passport", "Passport", b1 =>
                        {
                            b1.Property<Guid>("BorrowerId")
                                .HasColumnType("uuid");

                            b1.Property<DateTime>("DateOfIssue")
                                .HasColumnType("timestamp without time zone")
                                .HasColumnName("DateOfIssue");

                            b1.Property<string>("IssuedBy")
                                .HasColumnType("text")
                                .HasColumnName("IssuedBy");

                            b1.Property<string>("Number")
                                .HasColumnType("text")
                                .HasColumnName("Number");

                            b1.Property<string>("Residency")
                                .HasColumnType("text")
                                .HasColumnName("Residency");

                            b1.Property<string>("Series")
                                .HasColumnType("text")
                                .HasColumnName("Series");

                            b1.Property<string>("SubdivisionCode")
                                .HasColumnType("text")
                                .HasColumnName("SubdivisionCode");

                            b1.HasKey("BorrowerId");

                            b1.ToTable("Borrowers");

                            b1.WithOwner()
                                .HasForeignKey("BorrowerId");
                        });

                    b.Navigation("FullName");

                    b.Navigation("Passport");
                });

            modelBuilder.Entity("Domain.Entities.Credit", b =>
                {
                    b.HasOne("Domain.Entities.Borrower", null)
                        .WithMany("Credits")
                        .HasForeignKey("BorrowerId");
                });

            modelBuilder.Entity("Domain.Entities.Borrower", b =>
                {
                    b.Navigation("Credits");
                });
#pragma warning restore 612, 618
        }
    }
}
