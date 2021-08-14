﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReviewApp.DAL;

namespace ReviewApp.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200525001215_Modelsv5")]
    partial class Modelsv5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ReviewApp.Model.Character", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 1)));

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("PictureURL");

                    b.HasKey("ID");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("ReviewApp.Model.CharacterActor", b =>
                {
                    b.Property<int>("ActorId");

                    b.Property<int>("CharacterId");

                    b.HasKey("ActorId", "CharacterId");

                    b.HasIndex("CharacterId");

                    b.ToTable("CharacterActors");
                });

            modelBuilder.Entity("ReviewApp.Model.Company", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("PictureURL");

                    b.HasKey("ID");

                    b.ToTable("Studios");
                });

            modelBuilder.Entity("ReviewApp.Model.Genre", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("name")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("ReviewApp.Model.Movie", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("AverageScore");

                    b.Property<string>("BackgroundURL");

                    b.Property<string>("CountryOfRelease")
                        .IsRequired();

                    b.Property<int?>("DirectorID");

                    b.Property<TimeSpan>("Duration");

                    b.Property<string>("PictureURL");

                    b.Property<DateTime>("ReleaseDate");

                    b.Property<string>("Synopsis")
                        .IsRequired();

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<string>("TrailerURL");

                    b.HasKey("ID");

                    b.HasIndex("DirectorID");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("ReviewApp.Model.MovieActor", b =>
                {
                    b.Property<int>("ActorId");

                    b.Property<int>("MovieId");

                    b.HasKey("ActorId", "MovieId");

                    b.HasIndex("MovieId");

                    b.ToTable("MovieActors");
                });

            modelBuilder.Entity("ReviewApp.Model.MovieCharacter", b =>
                {
                    b.Property<int>("CharacterId");

                    b.Property<int>("MovieId");

                    b.HasKey("CharacterId", "MovieId");

                    b.HasIndex("MovieId");

                    b.ToTable("MovieCharacters");
                });

            modelBuilder.Entity("ReviewApp.Model.MovieGenre", b =>
                {
                    b.Property<int>("GenreId");

                    b.Property<int>("MovieId");

                    b.HasKey("GenreId", "MovieId");

                    b.HasIndex("MovieId");

                    b.ToTable("MovieGenres");
                });

            modelBuilder.Entity("ReviewApp.Model.MovieStudio", b =>
                {
                    b.Property<int>("StudioId");

                    b.Property<int>("MovieId");

                    b.HasKey("StudioId", "MovieId");

                    b.HasIndex("MovieId");

                    b.ToTable("MovieStudios");
                });

            modelBuilder.Entity("ReviewApp.Model.MovieWriter", b =>
                {
                    b.Property<int>("WriterId");

                    b.Property<int>("MovieId");

                    b.HasKey("WriterId", "MovieId");

                    b.HasIndex("MovieId");

                    b.ToTable("MovieWriters");
                });

            modelBuilder.Entity("ReviewApp.Model.Person", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CountryOfBirth");

                    b.Property<DateTime?>("DateOfBirth");

                    b.Property<string>("Description");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 1)));

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("PictureURL");

                    b.Property<string>("PlaceOfBirth");

                    b.HasKey("ID");

                    b.ToTable("People");
                });

            modelBuilder.Entity("ReviewApp.Model.Show", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("AverageScore");

                    b.Property<string>("BackgroundURL");

                    b.Property<string>("CountryOfRelease");

                    b.Property<TimeSpan>("EpisodeDuration");

                    b.Property<int>("NumberOfEpisodes");

                    b.Property<string>("PictureURL");

                    b.Property<DateTime>("ReleaseDate");

                    b.Property<string>("Synopsis")
                        .IsRequired();

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<string>("TrailerURL");

                    b.HasKey("ID");

                    b.ToTable("Shows");
                });

            modelBuilder.Entity("ReviewApp.Model.ShowActor", b =>
                {
                    b.Property<int>("ActorId");

                    b.Property<int>("ShowId");

                    b.HasKey("ActorId", "ShowId");

                    b.HasIndex("ShowId");

                    b.ToTable("ShowActors");
                });

            modelBuilder.Entity("ReviewApp.Model.ShowCharacter", b =>
                {
                    b.Property<int>("CharacterId");

                    b.Property<int>("ShowId");

                    b.HasKey("CharacterId", "ShowId");

                    b.HasIndex("ShowId");

                    b.ToTable("ShowCharacters");
                });

            modelBuilder.Entity("ReviewApp.Model.ShowGenre", b =>
                {
                    b.Property<int>("GenreId");

                    b.Property<int>("ShowId");

                    b.HasKey("GenreId", "ShowId");

                    b.HasIndex("ShowId");

                    b.ToTable("ShowGenres");
                });

            modelBuilder.Entity("ReviewApp.Model.ShowStudio", b =>
                {
                    b.Property<int>("StudioId");

                    b.Property<int>("ShowId");

                    b.HasKey("StudioId", "ShowId");

                    b.HasIndex("ShowId");

                    b.ToTable("ShowStudios");
                });

            modelBuilder.Entity("ReviewApp.Model.ShowWriter", b =>
                {
                    b.Property<int>("ShowId");

                    b.Property<int>("WriterId");

                    b.HasKey("ShowId", "WriterId");

                    b.HasIndex("WriterId");

                    b.ToTable("ShowWriters");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ReviewApp.Model.CharacterActor", b =>
                {
                    b.HasOne("ReviewApp.Model.Person", "Actor")
                        .WithMany("CharacterActors")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ReviewApp.Model.Character", "Character")
                        .WithMany("CharacterActors")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ReviewApp.Model.Movie", b =>
                {
                    b.HasOne("ReviewApp.Model.Person", "Director")
                        .WithMany()
                        .HasForeignKey("DirectorID");
                });

            modelBuilder.Entity("ReviewApp.Model.MovieActor", b =>
                {
                    b.HasOne("ReviewApp.Model.Person", "Actor")
                        .WithMany("MovieActors")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ReviewApp.Model.Movie", "Movie")
                        .WithMany("MovieActors")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ReviewApp.Model.MovieCharacter", b =>
                {
                    b.HasOne("ReviewApp.Model.Character", "Character")
                        .WithMany("MovieCharacters")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ReviewApp.Model.Movie", "Movie")
                        .WithMany("MovieCharacters")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ReviewApp.Model.MovieGenre", b =>
                {
                    b.HasOne("ReviewApp.Model.Genre", "Genre")
                        .WithMany("MovieGenres")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ReviewApp.Model.Movie", "Movie")
                        .WithMany("MovieGenres")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ReviewApp.Model.MovieStudio", b =>
                {
                    b.HasOne("ReviewApp.Model.Movie", "Movie")
                        .WithMany("MovieStudios")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ReviewApp.Model.Company", "Studio")
                        .WithMany("MovieStudios")
                        .HasForeignKey("StudioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ReviewApp.Model.MovieWriter", b =>
                {
                    b.HasOne("ReviewApp.Model.Movie", "Movie")
                        .WithMany("MovieWriters")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ReviewApp.Model.Person", "Writer")
                        .WithMany("MovieWriters")
                        .HasForeignKey("WriterId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ReviewApp.Model.ShowActor", b =>
                {
                    b.HasOne("ReviewApp.Model.Person", "Actor")
                        .WithMany("ShowActors")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ReviewApp.Model.Show", "Show")
                        .WithMany("ShowActors")
                        .HasForeignKey("ShowId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ReviewApp.Model.ShowCharacter", b =>
                {
                    b.HasOne("ReviewApp.Model.Character", "Character")
                        .WithMany("ShowCharacters")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ReviewApp.Model.Show", "Show")
                        .WithMany("ShowCharacters")
                        .HasForeignKey("ShowId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ReviewApp.Model.ShowGenre", b =>
                {
                    b.HasOne("ReviewApp.Model.Genre", "Genre")
                        .WithMany("ShowGenres")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ReviewApp.Model.Show", "Show")
                        .WithMany("ShowGenres")
                        .HasForeignKey("ShowId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ReviewApp.Model.ShowStudio", b =>
                {
                    b.HasOne("ReviewApp.Model.Show", "Show")
                        .WithMany("ShowStudios")
                        .HasForeignKey("ShowId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ReviewApp.Model.Company", "Studio")
                        .WithMany("ShowStudios")
                        .HasForeignKey("StudioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ReviewApp.Model.ShowWriter", b =>
                {
                    b.HasOne("ReviewApp.Model.Show", "Show")
                        .WithMany("ShowWriters")
                        .HasForeignKey("ShowId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ReviewApp.Model.Person", "Writer")
                        .WithMany("ShowWriters")
                        .HasForeignKey("WriterId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
