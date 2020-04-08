﻿// <auto-generated />
using System;
using EntityFramework.Infra.Data3;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EntityFramework.Data3.Migrations
{
    [DbContext(typeof(EntityContext))]
    [Migration("20200408194559_AddUserConfigNovo")]
    partial class AddUserConfigNovo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("EntityFramework.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateBirth");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(400);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(400);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(400);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(400);

                    b.Property<int>("Sex");

                    b.Property<string>("UrlPhoto")
                        .IsRequired()
                        .HasMaxLength(400);

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
