﻿// <auto-generated />
using System;
using DBRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DBRepository.Migrations
{
    [DbContext(typeof(RepositoryDbContext))]
    partial class RepositoryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Models.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CommentId"));

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("TestId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("CommentId");

                    b.HasIndex("TestId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Models.TeamLeader", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("Access")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("TeamLeaders");
                });

            modelBuilder.Entity("Models.Test", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Job")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Namespace")
                        .HasColumnType("text");

                    b.Property<string>("Pipeline")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TestGroupId")
                        .HasColumnType("integer");

                    b.Property<int>("TestsGroupId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<string>("xmlReport")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("TestsGroupId");

                    b.HasIndex("UserId");

                    b.ToTable("Tests");
                });

            modelBuilder.Entity("Models.TestsGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("ProjectId")
                        .HasColumnType("integer");

                    b.Property<int?>("TeamLeaderId")
                        .HasColumnType("integer");

                    b.Property<string>("xmlReport")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("TeamLeaderId");

                    b.ToTable("TestsGroups");
                });

            modelBuilder.Entity("Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("GroupId")
                        .HasColumnType("integer");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TeamLeaderId")
                        .HasColumnType("integer");

                    b.Property<int>("TestsGroupId")
                        .HasColumnType("integer");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("TeamLeaderId");

                    b.HasIndex("TestsGroupId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Models.Comment", b =>
                {
                    b.HasOne("Models.Test", "Test")
                        .WithMany("Comments")
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Test");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Models.Test", b =>
                {
                    b.HasOne("Models.TestsGroup", "TestsGroup")
                        .WithMany("Tests")
                        .HasForeignKey("TestsGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TestsGroup");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Models.TestsGroup", b =>
                {
                    b.HasOne("Models.Project", null)
                        .WithMany("TestsGroups")
                        .HasForeignKey("ProjectId");

                    b.HasOne("Models.TeamLeader", null)
                        .WithMany("TestsGroups")
                        .HasForeignKey("TeamLeaderId");
                });

            modelBuilder.Entity("Models.User", b =>
                {
                    b.HasOne("Models.TeamLeader", "TeamLeader")
                        .WithMany("Users")
                        .HasForeignKey("TeamLeaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.TestsGroup", "TestsGroup")
                        .WithMany()
                        .HasForeignKey("TestsGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TeamLeader");

                    b.Navigation("TestsGroup");
                });

            modelBuilder.Entity("Models.Project", b =>
                {
                    b.Navigation("TestsGroups");
                });

            modelBuilder.Entity("Models.TeamLeader", b =>
                {
                    b.Navigation("TestsGroups");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Models.Test", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("Models.TestsGroup", b =>
                {
                    b.Navigation("Tests");
                });

            modelBuilder.Entity("Models.User", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}
