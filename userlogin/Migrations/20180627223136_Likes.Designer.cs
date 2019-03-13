﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using userlogin.Models;

namespace userlogin.Migrations
{
    [DbContext(typeof(UserContext))]
    [Migration("20180627223136_Likes")]
    partial class Likes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("userlogin.Models.Likes", b =>
                {
                    b.Property<int>("JoinerId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("PostId");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<int>("UserId");

                    b.Property<int?>("likesJoinerId");

                    b.HasKey("JoinerId");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.HasIndex("likesJoinerId");

                    b.ToTable("likers");
                });

            modelBuilder.Entity("userlogin.Models.Posts", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("UserId");

                    b.Property<DateTime>("date");

                    b.Property<int>("numlikers");

                    b.Property<string>("posts")
                        .IsRequired();

                    b.Property<DateTime>("time");

                    b.HasKey("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("posts");
                });

            modelBuilder.Entity("userlogin.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("alias");

                    b.Property<string>("email");

                    b.Property<string>("firstname");

                    b.Property<string>("lastname");

                    b.Property<string>("password");

                    b.HasKey("UserId");

                    b.ToTable("users");
                });

            modelBuilder.Entity("userlogin.Models.Likes", b =>
                {
                    b.HasOne("userlogin.Models.Posts")
                        .WithMany("Likers")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("userlogin.Models.User", "user")
                        .WithMany("Creater")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("userlogin.Models.Likes", "likes")
                        .WithMany()
                        .HasForeignKey("likesJoinerId");
                });

            modelBuilder.Entity("userlogin.Models.Posts", b =>
                {
                    b.HasOne("userlogin.Models.User", "createdby")
                        .WithMany("AllPosts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
