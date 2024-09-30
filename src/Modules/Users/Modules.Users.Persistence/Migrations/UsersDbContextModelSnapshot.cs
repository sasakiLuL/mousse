﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Modules.Users.Persistence;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Modules.Users.Persistance.Migrations
{
    [DbContext(typeof(UsersDbContext))]
    partial class UsersDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("users")
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Modules.Users.Domain.Followers.Follower", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.Property<Guid>("FollowedId")
                        .HasColumnType("uuid")
                        .HasColumnName("followed_id");

                    b.Property<DateTime>("CreatedOnUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_on_utc");

                    b.HasKey("UserId", "FollowedId")
                        .HasName("pk_followers");

                    b.HasIndex("FollowedId", "UserId")
                        .HasDatabaseName("ix_followers_followed_id_user_id");

                    b.ToTable("followers", "users");
                });

            modelBuilder.Entity("Modules.Users.Domain.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.Property<string>("IdentityServiceUserId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("identity_service_user_id");

                    b.ComplexProperty<Dictionary<string, object>>("Email", "Modules.Users.Domain.Users.User.Email#Email", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(256)
                                .HasColumnType("character varying(256)")
                                .HasColumnName("email");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("UserName", "Modules.Users.Domain.Users.User.UserName#UserName", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)")
                                .HasColumnName("user_name");
                        });

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.HasIndex("Id")
                        .HasDatabaseName("ix_users_id");

                    b.ToTable("users", "users");
                });

            modelBuilder.Entity("Modules.Users.Domain.Followers.Follower", b =>
                {
                    b.HasOne("Modules.Users.Domain.Users.User", null)
                        .WithMany()
                        .HasForeignKey("FollowedId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("fk_followers_users_followed_id");

                    b.HasOne("Modules.Users.Domain.Users.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_followers_users_user_id");
                });
#pragma warning restore 612, 618
        }
    }
}