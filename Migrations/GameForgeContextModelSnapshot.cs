﻿// <auto-generated />
using System;
using System.Collections.Generic;
using GameForge.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GameForge.Migrations
{
    [DbContext(typeof(GameForgeContext))]
    partial class GameForgeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("GameForge.Models.Answer", b =>
                {
                    b.Property<int>("QuestionID")
                        .HasColumnType("integer");

                    b.Property<int>("UserID")
                        .HasColumnType("integer");

                    b.Property<string>("AnswerText")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Downvotes")
                        .HasColumnType("integer");

                    b.Property<int>("Upvotes")
                        .HasColumnType("integer");

                    b.HasKey("QuestionID", "UserID");

                    b.HasIndex("UserID");

                    b.ToTable("Answer");
                });

            modelBuilder.Entity("GameForge.Models.AnswerVote", b =>
                {
                    b.Property<int>("QuestionID")
                        .HasColumnType("integer");

                    b.Property<int>("UserID")
                        .HasColumnType("integer");

                    b.Property<bool>("IsUpvote")
                        .HasColumnType("boolean");

                    b.HasKey("QuestionID", "UserID");

                    b.HasIndex("UserID");

                    b.ToTable("AnswerVotes");
                });

            modelBuilder.Entity("GameForge.Models.Question", b =>
                {
                    b.Property<int>("QuestionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("QuestionID"));

                    b.Property<int>("AuthorID")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Downvotes")
                        .HasColumnType("integer");

                    b.Property<int>("LatestAnswerID")
                        .HasColumnType("integer");

                    b.Property<DateTime>("LatestAnswerTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("NumberOfAnswers")
                        .HasColumnType("integer");

                    b.Property<string>("QuestionText")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Upvotes")
                        .HasColumnType("integer");

                    b.HasKey("QuestionID");

                    b.HasIndex("AuthorID");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("GameForge.Models.QuestionVote", b =>
                {
                    b.Property<int>("QuestionID")
                        .HasColumnType("integer");

                    b.Property<int>("UserID")
                        .HasColumnType("integer");

                    b.Property<bool>("IsUpvote")
                        .HasColumnType("boolean");

                    b.HasKey("QuestionID", "UserID");

                    b.HasIndex("UserID");

                    b.ToTable("QuestionVotes");
                });

            modelBuilder.Entity("GameForge.Models.ThreadTopic", b =>
                {
                    b.Property<int>("ThreadTopicID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ThreadTopicID"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("LatestReplyID")
                        .HasColumnType("integer");

                    b.Property<DateTime>("LatestReplyTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("NumberOfReplies")
                        .HasColumnType("integer");

                    b.Property<List<string>>("Tag")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserID")
                        .HasColumnType("integer");

                    b.HasKey("ThreadTopicID");

                    b.HasIndex("UserID");

                    b.ToTable("ThreadTopic");
                });

            modelBuilder.Entity("GameForge.Models.ThreadTopicReply", b =>
                {
                    b.Property<int>("UserID")
                        .HasColumnType("integer");

                    b.Property<int>("ThreadTopicID")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UserID", "ThreadTopicID");

                    b.HasIndex("ThreadTopicID");

                    b.ToTable("ThreadTopicReplies");
                });

            modelBuilder.Entity("GameForge.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("GameForge.Models.Answer", b =>
                {
                    b.HasOne("GameForge.Models.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameForge.Models.User", "User")
                        .WithMany("Answers")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");

                    b.Navigation("User");
                });

            modelBuilder.Entity("GameForge.Models.AnswerVote", b =>
                {
                    b.HasOne("GameForge.Models.Question", "Question")
                        .WithMany("AnswerVotes")
                        .HasForeignKey("QuestionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameForge.Models.User", "User")
                        .WithMany("AnswerVotes")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");

                    b.Navigation("User");
                });

            modelBuilder.Entity("GameForge.Models.Question", b =>
                {
                    b.HasOne("GameForge.Models.User", "User")
                        .WithMany("Questions")
                        .HasForeignKey("AuthorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("GameForge.Models.QuestionVote", b =>
                {
                    b.HasOne("GameForge.Models.Question", "Question")
                        .WithMany("QuestionVotes")
                        .HasForeignKey("QuestionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameForge.Models.User", "User")
                        .WithMany("QuestionVotes")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");

                    b.Navigation("User");
                });

            modelBuilder.Entity("GameForge.Models.ThreadTopic", b =>
                {
                    b.HasOne("GameForge.Models.User", "User")
                        .WithMany("ThreadTopics")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("GameForge.Models.ThreadTopicReply", b =>
                {
                    b.HasOne("GameForge.Models.ThreadTopic", "ThreadTopic")
                        .WithMany("ThreadTopidcReplies")
                        .HasForeignKey("ThreadTopicID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameForge.Models.User", "User")
                        .WithMany("ThreadTopicReplies")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ThreadTopic");

                    b.Navigation("User");
                });

            modelBuilder.Entity("GameForge.Models.Question", b =>
                {
                    b.Navigation("AnswerVotes");

                    b.Navigation("Answers");

                    b.Navigation("QuestionVotes");
                });

            modelBuilder.Entity("GameForge.Models.ThreadTopic", b =>
                {
                    b.Navigation("ThreadTopidcReplies");
                });

            modelBuilder.Entity("GameForge.Models.User", b =>
                {
                    b.Navigation("AnswerVotes");

                    b.Navigation("Answers");

                    b.Navigation("QuestionVotes");

                    b.Navigation("Questions");

                    b.Navigation("ThreadTopicReplies");

                    b.Navigation("ThreadTopics");
                });
#pragma warning restore 612, 618
        }
    }
}
