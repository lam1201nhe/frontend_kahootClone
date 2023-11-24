﻿// <auto-generated />
using System;
using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BusinessObjects.Migrations
{
    [DbContext(typeof(CloneKahootContext))]
    [Migration("20231120081420_InitialDB")]
    partial class InitialDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BusinessObjects.Models.Account", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("AccountID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccountId"), 1L, 1);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.HasKey("AccountId");

                    b.ToTable("Account", (string)null);
                });

            modelBuilder.Entity("BusinessObjects.Models.Choice", b =>
                {
                    b.Property<int>("ChoiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ChoiceID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ChoiceId"), 1L, 1);

                    b.Property<string>("ChoiceContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ChoiceId");

                    b.ToTable("Choice", (string)null);
                });

            modelBuilder.Entity("BusinessObjects.Models.Game", b =>
                {
                    b.Property<int>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("GameID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GameId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("PinCode")
                        .HasColumnType("int");

                    b.Property<bool?>("Publish")
                        .HasColumnType("bit");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    b.HasKey("GameId");

                    b.HasIndex("UserId");

                    b.ToTable("Game", (string)null);
                });

            modelBuilder.Entity("BusinessObjects.Models.GameSession", b =>
                {
                    b.Property<int>("GameSessionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("GameSessionID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GameSessionId"), 1L, 1);

                    b.Property<TimeSpan?>("EndTime")
                        .HasColumnType("time");

                    b.Property<int>("GameId")
                        .HasColumnType("int")
                        .HasColumnName("GameID");

                    b.Property<int?>("PlayerId")
                        .HasColumnType("int")
                        .HasColumnName("PlayerID");

                    b.Property<TimeSpan?>("StartTime")
                        .HasColumnType("time");

                    b.HasKey("GameSessionId");

                    b.HasIndex("GameId");

                    b.HasIndex("PlayerId");

                    b.ToTable("GameSession", (string)null);
                });

            modelBuilder.Entity("BusinessObjects.Models.Player", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PlayerID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlayerId"), 1L, 1);

                    b.Property<string>("PlayerName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("Score")
                        .HasColumnType("int");

                    b.HasKey("PlayerId");

                    b.ToTable("Player", (string)null);
                });

            modelBuilder.Entity("BusinessObjects.Models.Question", b =>
                {
                    b.Property<int>("QuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("QuestionID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QuestionId"), 1L, 1);

                    b.Property<int>("GameId")
                        .HasColumnType("int")
                        .HasColumnName("GameID");

                    b.Property<int>("Point")
                        .HasColumnType("int");

                    b.Property<string>("QuestionContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TimeLimit")
                        .HasColumnType("int")
                        .HasColumnName("timeLimit");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("QuestionId");

                    b.HasIndex("GameId");

                    b.ToTable("Question", (string)null);
                });

            modelBuilder.Entity("BusinessObjects.Models.QuestionChoice", b =>
                {
                    b.Property<int>("QuestionId")
                        .HasColumnType("int")
                        .HasColumnName("QuestionID");

                    b.Property<int>("ChoiceId")
                        .HasColumnType("int")
                        .HasColumnName("ChoiceID");

                    b.Property<bool>("CorrectAnswer")
                        .HasColumnType("bit");

                    b.HasKey("QuestionId", "ChoiceId");

                    b.HasIndex("ChoiceId");

                    b.ToTable("Question_Choice", (string)null);
                });

            modelBuilder.Entity("BusinessObjects.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("UserID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<int>("AccountId")
                        .HasColumnType("int")
                        .HasColumnName("AccountID");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Dob")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool?>("Gender")
                        .HasColumnType("bit");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("UserId");

                    b.HasIndex("AccountId");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("BusinessObjects.Models.Game", b =>
                {
                    b.HasOne("BusinessObjects.Models.User", "User")
                        .WithMany("Games")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_Game_User");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BusinessObjects.Models.GameSession", b =>
                {
                    b.HasOne("BusinessObjects.Models.Game", "Game")
                        .WithMany("GameSessions")
                        .HasForeignKey("GameId")
                        .IsRequired()
                        .HasConstraintName("FK_GameSession_Game");

                    b.HasOne("BusinessObjects.Models.Player", "Player")
                        .WithMany("GameSessions")
                        .HasForeignKey("PlayerId")
                        .HasConstraintName("FK_GameSession_Player");

                    b.Navigation("Game");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("BusinessObjects.Models.Question", b =>
                {
                    b.HasOne("BusinessObjects.Models.Game", "Game")
                        .WithMany("Questions")
                        .HasForeignKey("GameId")
                        .IsRequired()
                        .HasConstraintName("FK_Question_Game");

                    b.Navigation("Game");
                });

            modelBuilder.Entity("BusinessObjects.Models.QuestionChoice", b =>
                {
                    b.HasOne("BusinessObjects.Models.Choice", "Choice")
                        .WithMany("QuestionChoices")
                        .HasForeignKey("ChoiceId")
                        .IsRequired()
                        .HasConstraintName("FK_Question_Choice_Choice");

                    b.HasOne("BusinessObjects.Models.Question", "Question")
                        .WithMany("QuestionChoices")
                        .HasForeignKey("QuestionId")
                        .IsRequired()
                        .HasConstraintName("FK_Question_Choice_Question");

                    b.Navigation("Choice");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("BusinessObjects.Models.User", b =>
                {
                    b.HasOne("BusinessObjects.Models.Account", "Account")
                        .WithMany("Users")
                        .HasForeignKey("AccountId")
                        .IsRequired()
                        .HasConstraintName("FK_User_Account");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("BusinessObjects.Models.Account", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("BusinessObjects.Models.Choice", b =>
                {
                    b.Navigation("QuestionChoices");
                });

            modelBuilder.Entity("BusinessObjects.Models.Game", b =>
                {
                    b.Navigation("GameSessions");

                    b.Navigation("Questions");
                });

            modelBuilder.Entity("BusinessObjects.Models.Player", b =>
                {
                    b.Navigation("GameSessions");
                });

            modelBuilder.Entity("BusinessObjects.Models.Question", b =>
                {
                    b.Navigation("QuestionChoices");
                });

            modelBuilder.Entity("BusinessObjects.Models.User", b =>
                {
                    b.Navigation("Games");
                });
#pragma warning restore 612, 618
        }
    }
}
