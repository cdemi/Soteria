﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Soteria.Data;

namespace Soteria.Data.SqlServer.Migrations
{
    [DbContext(typeof(SoteriaContext))]
    [Migration("20200720152759_Added even more fields to the Login History")]
    partial class AddedevenmorefieldstotheLoginHistory
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Soteria.Data.LoginHistory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<long?>("AutonomousSystemNumber")
                        .HasColumnType("bigint");

                    b.Property<string>("AutonomousSystemOrganization")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConnectionType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Continent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Domain")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAnonymous")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAnonymousProxy")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAnonymousVpn")
                        .HasColumnType("bit");

                    b.Property<bool>("IsHostingProvider")
                        .HasColumnType("bit");

                    b.Property<bool>("IsLegitimateProxy")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPublicProxy")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSatelliteProvider")
                        .HasColumnType("bit");

                    b.Property<bool>("IsTorExitNode")
                        .HasColumnType("bit");

                    b.Property<string>("Isp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Organization")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("StaticIPScore")
                        .HasColumnType("float");

                    b.Property<string>("UserAgent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Username", "DateTime");

                    b.ToTable("LoginHistories");
                });
#pragma warning restore 612, 618
        }
    }
}
