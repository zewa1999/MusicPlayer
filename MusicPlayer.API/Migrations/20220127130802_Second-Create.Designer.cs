﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MusicPlayer.API.Data;

#nullable disable

namespace MusicPlayer.API.Migrations
{
    [DbContext(typeof(MusicPlayerContext))]
    [Migration("20220127130802_Second-Create")]
    partial class SecondCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.1");

            modelBuilder.Entity("ArtistSong", b =>
                {
                    b.Property<int>("ArtistsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CreatedSongsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ArtistsId", "CreatedSongsId");

                    b.HasIndex("CreatedSongsId");

                    b.ToTable("ArtistSong");
                });

            modelBuilder.Entity("MusicPlayer.API.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("MusicPlayer.API.Models.Artist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Artist");
                });

            modelBuilder.Entity("MusicPlayer.API.Models.Song", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("Content")
                        .HasColumnType("BLOB");

                    b.Property<string>("Duration")
                        .HasMaxLength(10)
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("Image")
                        .HasColumnType("BLOB");

                    b.Property<string>("Name")
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.Property<int?>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Songs");
                });

            modelBuilder.Entity("MusicPlayer.API.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AccountId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Country")
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ArtistSong", b =>
                {
                    b.HasOne("MusicPlayer.API.Models.Artist", null)
                        .WithMany()
                        .HasForeignKey("ArtistsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicPlayer.API.Models.Song", null)
                        .WithMany()
                        .HasForeignKey("CreatedSongsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MusicPlayer.API.Models.Song", b =>
                {
                    b.HasOne("MusicPlayer.API.Models.User", null)
                        .WithMany("Songs")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("MusicPlayer.API.Models.User", b =>
                {
                    b.HasOne("MusicPlayer.API.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("MusicPlayer.API.Models.User", b =>
                {
                    b.Navigation("Songs");
                });
#pragma warning restore 612, 618
        }
    }
}
