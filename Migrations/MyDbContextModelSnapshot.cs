﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WatchBook.Data;

#nullable disable

namespace WatchBook.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("WatchBook.Data.Anime", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AnimeID")
                        .HasColumnType("INTEGER");

                    b.Property<byte>("Buy")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateAired")
                        .HasColumnType("TEXT");

                    b.Property<int>("Episodes")
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("IMG")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("OrginalName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<byte>("Rank")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SearchCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Animes");
                });

            modelBuilder.Entity("WatchBook.Data.AnimeGenre", b =>
                {
                    b.Property<int>("AnimeID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GenreID")
                        .HasColumnType("INTEGER");

                    b.HasKey("AnimeID", "GenreID");

                    b.HasIndex("GenreID");

                    b.ToTable("AnimeGenres");
                });

            modelBuilder.Entity("WatchBook.Data.Genre", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("WatchBook.Data.Movie", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<byte>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<byte>("Buy")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateAired")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Favorit")
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("IMG")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("MovieID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("WatchBook.Data.MovieGenre", b =>
                {
                    b.Property<int>("MovieID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GenreID")
                        .HasColumnType("INTEGER");

                    b.HasKey("MovieID", "GenreID");

                    b.HasIndex("GenreID");

                    b.ToTable("MovieGenres");
                });

            modelBuilder.Entity("WatchBook.Data.Settings", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("IMG")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<string>("Setting")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("WatchBook.Data.WatchLaterAnime", b =>
                {
                    b.Property<int>("AnimeID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comment")
                        .HasColumnType("TEXT");

                    b.HasKey("AnimeID", "Comment");

                    b.ToTable("WatchLaterAnimes");
                });

            modelBuilder.Entity("WatchBook.Data.WatchLaterMovie", b =>
                {
                    b.Property<int>("MovieID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comment")
                        .HasColumnType("TEXT");

                    b.HasKey("MovieID", "Comment");

                    b.ToTable("WatchLaterMovies");
                });

            modelBuilder.Entity("WatchBook.Data.AnimeGenre", b =>
                {
                    b.HasOne("WatchBook.Data.Anime", "Anime")
                        .WithMany("AnimeGenres")
                        .HasForeignKey("AnimeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WatchBook.Data.Genre", "Genre")
                        .WithMany("AnimeGenres")
                        .HasForeignKey("GenreID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Anime");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("WatchBook.Data.MovieGenre", b =>
                {
                    b.HasOne("WatchBook.Data.Genre", "Genre")
                        .WithMany("MovieGenres")
                        .HasForeignKey("GenreID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WatchBook.Data.Movie", "Movie")
                        .WithMany("MovieGenres")
                        .HasForeignKey("MovieID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("WatchBook.Data.WatchLaterAnime", b =>
                {
                    b.HasOne("WatchBook.Data.Anime", "Anime")
                        .WithMany("WatchLaterAnimes")
                        .HasForeignKey("AnimeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Anime");
                });

            modelBuilder.Entity("WatchBook.Data.WatchLaterMovie", b =>
                {
                    b.HasOne("WatchBook.Data.Movie", "Movie")
                        .WithMany("WatchLaterMovies")
                        .HasForeignKey("MovieID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("WatchBook.Data.Anime", b =>
                {
                    b.Navigation("AnimeGenres");

                    b.Navigation("WatchLaterAnimes");
                });

            modelBuilder.Entity("WatchBook.Data.Genre", b =>
                {
                    b.Navigation("AnimeGenres");

                    b.Navigation("MovieGenres");
                });

            modelBuilder.Entity("WatchBook.Data.Movie", b =>
                {
                    b.Navigation("MovieGenres");

                    b.Navigation("WatchLaterMovies");
                });
#pragma warning restore 612, 618
        }
    }
}