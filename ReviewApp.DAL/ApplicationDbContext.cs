using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReviewApp.Model;

namespace ReviewApp.DAL
{
    public class ApplicationDbContext : IdentityDbContext
    {
        protected ApplicationDbContext() { }

        public ApplicationDbContext(DbContextOptions options): base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Show> Shows { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Company> Studios { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<MovieActor> MovieActors { get; set; }
        public DbSet<ShowActor> ShowActors { get; set; }
        public DbSet<MovieWriter> MovieWriters { get; set; }
        public DbSet<MovieStudio> MovieStudios { get; set; }
        public DbSet<ShowWriter> ShowWriters { get; set; }
        public DbSet<ShowStudio> ShowStudios { get; set; }
        public DbSet<MovieCharacter> MovieCharacters { get; set; }
        public DbSet<ShowCharacter> ShowCharacters { get; set; }
        public DbSet<CharacterActor> CharacterActors { get; set; }
        public DbSet<ShowGenre> ShowGenres { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<Rating> Ratings { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieActor>().HasKey(m => new { m.ActorId, m.MovieId });
            modelBuilder.Entity<MovieActor>()
            .HasOne(m => m.Movie)
            .WithMany(a => a.MovieActors)
            .HasForeignKey(ma => ma.MovieId);
            modelBuilder.Entity<MovieActor>()
            .HasOne(a => a.Actor)
            .WithMany(m => m.MovieActors)
            .HasForeignKey(ma => ma.ActorId);

            modelBuilder.Entity<ShowActor>().HasKey(m => new { m.ActorId, m.ShowId });
            modelBuilder.Entity<ShowActor>()
            .HasOne(s => s.Show)
            .WithMany(a => a.ShowActors)
            .HasForeignKey(sa => sa.ShowId);
            modelBuilder.Entity<ShowActor>()
            .HasOne(a => a.Actor)
            .WithMany(m => m.ShowActors)
            .HasForeignKey(sa => sa.ActorId);

            modelBuilder.Entity<MovieWriter>().HasKey(m => new { m.WriterId, m.MovieId });
            modelBuilder.Entity<MovieWriter>()
            .HasOne(m => m.Movie)
            .WithMany(a => a.MovieWriters)
            .HasForeignKey(ma => ma.MovieId);
            modelBuilder.Entity<MovieWriter>()
            .HasOne(w => w.Writer)
            .WithMany(m => m.MovieWriters)
            .HasForeignKey(ma => ma.WriterId);

            modelBuilder.Entity<MovieStudio>().HasKey(m => new { m.StudioId, m.MovieId });
            modelBuilder.Entity<MovieStudio>()
            .HasOne(m => m.Movie)
            .WithMany(a => a.MovieStudios)
            .HasForeignKey(ma => ma.MovieId);
            modelBuilder.Entity<MovieStudio>()
            .HasOne(s => s.Studio)
            .WithMany(m => m.MovieStudios)
            .HasForeignKey(ma => ma.StudioId);

            modelBuilder.Entity<ShowWriter>().HasKey(m => new { m.ShowId, m.WriterId });
            modelBuilder.Entity<ShowWriter>()
            .HasOne(s => s.Show)
            .WithMany(a => a.ShowWriters)
            .HasForeignKey(ma => ma.ShowId);
            modelBuilder.Entity<ShowWriter>()
            .HasOne(w => w.Writer)
            .WithMany(m => m.ShowWriters)
            .HasForeignKey(ma => ma.WriterId);

            modelBuilder.Entity<ShowStudio>().HasKey(m => new { m.StudioId, m.ShowId });
            modelBuilder.Entity<ShowStudio>()
            .HasOne(s => s.Show)
            .WithMany(a => a.ShowStudios)
            .HasForeignKey(sa => sa.ShowId);
            modelBuilder.Entity<ShowStudio>()
            .HasOne(s => s.Studio)
            .WithMany(m => m.ShowStudios)
            .HasForeignKey(ss => ss.StudioId);

            modelBuilder.Entity<MovieCharacter>().HasKey(m => new { m.CharacterId, m.MovieId });
            modelBuilder.Entity<MovieCharacter>()
            .HasOne(m => m.Movie)
            .WithMany(a => a.MovieCharacters)
            .HasForeignKey(mc => mc.MovieId);
            modelBuilder.Entity<MovieCharacter>()
            .HasOne(c => c.Character)
            .WithMany(m => m.MovieCharacters)
            .HasForeignKey(mc => mc.CharacterId);

            modelBuilder.Entity<ShowCharacter>().HasKey(m => new { m.CharacterId, m.ShowId });
            modelBuilder.Entity<ShowCharacter>()
            .HasOne(s => s.Show)
            .WithMany(a => a.ShowCharacters)
            .HasForeignKey(sa => sa.ShowId);
            modelBuilder.Entity<ShowCharacter>()
            .HasOne(c => c.Character)
            .WithMany(m => m.ShowCharacters)
            .HasForeignKey(sc => sc.CharacterId);

            modelBuilder.Entity<CharacterActor>().HasKey(m => new { m.ActorId, m.CharacterId });
            modelBuilder.Entity<CharacterActor>()
            .HasOne(c => c.Character)
            .WithMany(a => a.CharacterActors)
            .HasForeignKey(ca => ca.CharacterId);
            modelBuilder.Entity<CharacterActor>()
            .HasOne(a => a.Actor)
            .WithMany(m => m.CharacterActors)
            .HasForeignKey(ca => ca.ActorId);

            modelBuilder.Entity<ShowGenre>().HasKey(m => new { m.GenreId, m.ShowId });
            modelBuilder.Entity<ShowGenre>()
            .HasOne(s => s.Show)
            .WithMany(a => a.ShowGenres)
            .HasForeignKey(sa => sa.ShowId);
            modelBuilder.Entity<ShowGenre>()
            .HasOne(c => c.Genre)
            .WithMany(m => m.ShowGenres)
            .HasForeignKey(sc => sc.GenreId);

            modelBuilder.Entity<MovieGenre>().HasKey(m => new { m.GenreId, m.MovieId });
            modelBuilder.Entity<MovieGenre>()
            .HasOne(s => s.Movie)
            .WithMany(a => a.MovieGenres)
            .HasForeignKey(sa => sa.MovieId);
            modelBuilder.Entity<MovieGenre>()
            .HasOne(c => c.Genre)
            .WithMany(m => m.MovieGenres)
            .HasForeignKey(sc => sc.GenreId);

            modelBuilder.Entity<Person>().HasData(new Person
            {
                ID = 999,
                FirstName = "Peter",
                LastName = "Weir",
                Gender = 'M',
                Description = "Peter Weir was born on August 21, 1944 in Sydney, New South Wales, Australia as Peter Lindsay Weir. He is a director and writer, known for Master and Commander: The Far Side of the World (2003), The Way Back (2010) and The Truman Show (1998). He has been married to Wendy Stites since 1966. They have two children.",
                PlaceOfBirth = "Sydney",
                CountryOfBirth = "Australia",
                DateOfBirth = DateTime.Parse("05/07/1960")
            });

            modelBuilder.Entity<Movie>().HasData(new Movie
            {
                ID = 9999,
                Title = "The Truman Show",
                ReleaseDate = DateTime.Parse("05/07/1998"),
                CountryOfRelease = "USA",
                Synopsis = "An insurance salesman discovers his whole life is actually a reality TV show. ",
                DurationMinutes = 103,
                DirectorID = 999,
            });


            base.OnModelCreating(modelBuilder);

        }
    }
}
