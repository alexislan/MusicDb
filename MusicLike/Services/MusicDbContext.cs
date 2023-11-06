using Microsoft.EntityFrameworkCore;
using MusicLike.Models.Artists;
using MusicLike.Models.Country;
using MusicLike.Models.Gender;
using MusicLike.Models.Genres;
using MusicLike.Models.Prueba;
using MusicLike.Models.Rating;
using MusicLike.Models.Releases;
using MusicLike.Models.Review;
using MusicLike.Models.Users;
using MusicLike.Models.UserType;

namespace MusicLike.Services
{
    public class MusicDbContext : DbContext
    {
        public MusicDbContext(DbContextOptions<MusicDbContext> options) : base(options) {}
        public DbSet<Prueba> pruebas { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Releases> Releases { get; set; }
        public DbSet<Genres> Genres { get; set; }
        public DbSet<Rating> Rating { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>()
                .HasOne(Artist => Artist.Gender)
                .WithMany()
                .HasForeignKey(Artist => Artist.GenderId);
            modelBuilder.Entity<Artist>()
                .HasOne(Artist => Artist.Country)
                .WithMany()
                .HasForeignKey(Artist => Artist.CountryId);

            modelBuilder.Entity<Users>()
                .HasOne(user => user.UserType)
                .WithMany()
                .HasForeignKey(user => user.UserTypeId);

            modelBuilder.Entity<Users>()
                .HasOne(user => user.Gender)
                .WithMany()
                .HasForeignKey(user => user.GenderId);

            modelBuilder.Entity<Users>()
                .HasOne(user => user.Country)
                .WithMany()
                .HasForeignKey(user => user.CountryId);

            modelBuilder.Entity<Artist>().HasMany(e => e.Releases).WithMany().UsingEntity<ReleaseArtist>(
                l => l.HasOne<Releases>().WithMany().HasForeignKey(e => e.ReleaseId),
                r => r.HasOne<Artist>().WithMany().HasForeignKey(e => e.ArtistId)
            );
            modelBuilder.Entity<Releases>().HasMany(e => e.Genres).WithMany().UsingEntity<GenresRelease>(
                l => l.HasOne<Genres>().WithMany().HasForeignKey(e => e.GenreId),
                r => r.HasOne<Releases>().WithMany().HasForeignKey(e => e.ReleaseId)
            );
            modelBuilder.Entity<Releases>()
                .HasOne(Release => Release.ReleaseType)
                .WithMany()
                .HasForeignKey(Release => Release.ReleaseTypeId);
            modelBuilder.Entity<Rating>()
                .HasOne(Rating => Rating.User)
                .WithMany()
                .HasForeignKey(Rating => Rating.UserId);
            modelBuilder.Entity<Rating>()
                .HasOne(Rating => Rating.Releases)
                .WithMany()
                .HasForeignKey(Rating => Rating.ReleaseId);
            modelBuilder.Entity<Review>()
                .HasOne(Review => Review.User)
                .WithMany()
                .HasForeignKey(Review => Review.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Review>()
                .HasOne(Review => Review.Rating)
                .WithMany()
                .HasForeignKey(Review => Review.RatingId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Review>()
                .HasOne(Review => Review.Release)
                .WithMany()
                .HasForeignKey(Review => Review.ReleaseId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserType>().HasData(
                new UserType { Id = 1, Name = "User"},
                new UserType { Id = 2, Name = "Admin"}
            );
            modelBuilder.Entity<Country>().HasData(
                new Country { Id = 1, Name = "Estados Unidos" },
                new Country { Id = 2, Name = "Canadá" },
                new Country { Id = 3, Name = "Reino Unido" },
                new Country { Id = 4, Name = "Francia" },
                new Country { Id = 5, Name = "Alemania" },
                new Country { Id = 6, Name = "España" },
                new Country { Id = 7, Name = "Italia" },
                new Country { Id = 8, Name = "Argentina" },
                new Country { Id = 9, Name = "Brasil" },
                new Country { Id = 10, Name = "México" }
            );
            modelBuilder.Entity<Gender>().HasData(
                new Gender { Id = 1, Name = "Female"},
                new Gender { Id = 2, Name = "Male"}
            );
            modelBuilder.Entity<Genres>().HasData(
                new Genres { Id = 1, Name = "Rock" },
                new Genres { Id = 2, Name = "Pop" },
                new Genres { Id = 3, Name = "Hip-Hop" },
                new Genres { Id = 4, Name = "Country" },
                new Genres { Id = 5, Name = "Electronic" },
                new Genres { Id = 6, Name = "Jazz" },
                new Genres { Id = 7, Name = "Classical" },
                new Genres { Id = 8, Name = "R&B" },
                new Genres { Id = 9, Name = "Reggae" },
                new Genres { Id = 10, Name = "Metal" }
            );
        }
    }
}
