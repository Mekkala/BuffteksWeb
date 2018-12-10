﻿// <auto-generated />
using System;
using Buffteks.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Buffteks.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20181210020547_initals")]
    partial class initals
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024");

            modelBuilder.Entity("Buffteks.Models.Project", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("ProjectName");

                    b.HasKey("ID");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Buffteks.Models.ProjectAssign", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ProjectID");

                    b.Property<int?>("ProjectParticipantID");

                    b.HasKey("ID");

                    b.HasIndex("ProjectID");

                    b.HasIndex("ProjectParticipantID");

                    b.ToTable("ProjectAssigns");
                });

            modelBuilder.Entity("Buffteks.Models.ProjectParticipant", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Phone");

                    b.HasKey("ID");

                    b.ToTable("ProjectParticipant");

                    b.HasDiscriminator<string>("Discriminator").HasValue("ProjectParticipant");
                });

            modelBuilder.Entity("Buffteks.Models.Client", b =>
                {
                    b.HasBaseType("Buffteks.Models.ProjectParticipant");

                    b.Property<string>("CompanyName");

                    b.ToTable("Client");

                    b.HasDiscriminator().HasValue("Client");
                });

            modelBuilder.Entity("Buffteks.Models.Member", b =>
                {
                    b.HasBaseType("Buffteks.Models.ProjectParticipant");

                    b.Property<string>("Major");

                    b.ToTable("Member");

                    b.HasDiscriminator().HasValue("Member");
                });

            modelBuilder.Entity("Buffteks.Models.ProjectAssign", b =>
                {
                    b.HasOne("Buffteks.Models.Project", "Project")
                        .WithMany("Participants")
                        .HasForeignKey("ProjectID");

                    b.HasOne("Buffteks.Models.ProjectParticipant", "ProjectParticipant")
                        .WithMany("Projects")
                        .HasForeignKey("ProjectParticipantID");
                });
#pragma warning restore 612, 618
        }
    }
}