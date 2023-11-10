using Microsoft.EntityFrameworkCore;
using MusicLike.Models.Artists;
using MusicLike.Models.Country;
using MusicLike.Models.Gender;
using MusicLike.Models.Genres;
using MusicLike.Models.Rating;
using MusicLike.Models.Releases;
using MusicLike.Models.ReleaseType;
using MusicLike.Models.Review;
using MusicLike.Models.Users;
using MusicLike.Models.UserType;

namespace MusicLike.Services
{
    public class MusicDbContext : DbContext
    {
        public MusicDbContext(DbContextOptions<MusicDbContext> options) : base(options) {}
        public DbSet<Users> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Releases> Releases { get; set; }
        public DbSet<Genres> Genres { get; set; }
        public DbSet<Rating> Rating { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ReleaseType> ReleaseType { get; set; }


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
            modelBuilder.Entity<Releases>()
                .HasOne(Release => Release.Genre)
                .WithMany()
                .HasForeignKey(Release => Release.GenreId);
            modelBuilder.Entity<Releases>()
                .HasOne(Release => Release.ReleaseType)
                .WithMany()
                .HasForeignKey(Release => Release.ReleaseTypeId);
            modelBuilder.Entity<Review>()
                .HasOne(Review => Review.User)
                .WithMany()
                .HasForeignKey(Review => Review.UserId);
            modelBuilder.Entity<Review>()
                .HasOne(Review => Review.Rating)
                .WithMany()
                .HasForeignKey(Review => Review.RatingId);
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
            modelBuilder.Entity<ReleaseType>().HasData(
                new ReleaseType { Id = 1, Name = "Live"},
                new ReleaseType { Id = 2, Name = "Studio"}

            );
            modelBuilder.Entity<Rating>().HasData(

                new Rating { Id = 1, Ratting = 1 },
                new Rating { Id = 2, Ratting = 2 },
                new Rating { Id = 3, Ratting = 3 },
                new Rating { Id = 4, Ratting = 4 },
                new Rating { Id = 5, Ratting = 5 }
            );
            modelBuilder.Entity<Users>().HasData(
                new Users
                {
                    Id = 1,
                    Name = "John Doe",
                    Email = "john.doe@example.com",
                    Password = "password123",
                    UserName = "johndoe",
                    UserTypeId = 1,
                    GenderId = 1,
                    CountryId = 1
                },
                new Users
                {
                    Id = 2,
                    Name = "Jane Smith",
                    Email = "jane.smith@example.com",
                    Password = "password456",
                    UserName = "janesmith",
                    UserTypeId = 1,
                    GenderId = 2,
                    CountryId = 2
                },
                new Users
                {
                    Id = 3,
                    Name = "Bob Johnson",
                    Email = "bob.johnson@example.com",
                    Password = "password789",
                    UserName = "bobjohnson",
                    UserTypeId = 1,
                    GenderId = 1,
                    CountryId = 3
                },
                new Users
                {
                    Id = 4,
                    Name = "Alice Brown",
                    Email = "alice.brown@example.com",
                    Password = "passwordABC",
                    UserName = "alicebrown",
                    UserTypeId = 1,
                    GenderId = 2,
                    CountryId = 4
                },
                new Users
                {
                    Id = 5,
                    Name = "Charlie Davis",
                    Email = "charlie.davis@example.com",
                    Password = "passwordDEF",
                    UserName = "charliedavis",
                    UserTypeId = 1,
                    GenderId = 1,
                    CountryId = 5
                },
                new Users
                {
                    Id = 6,
                    Name = "Eva Wilson",
                    Email = "eva.wilson@example.com",
                    Password = "passwordGHI",
                    UserName = "evawilson",
                    UserTypeId = 1,
                    GenderId = 2,
                    CountryId = 6
                },
                new Users
                {
                    Id = 7,
                    Name = "David Lee",
                    Email = "david.lee@example.com",
                    Password = "passwordJKL",
                    UserName = "davidlee",
                    UserTypeId = 1,
                    GenderId = 1,
                    CountryId = 7
                },
                new Users
                {
                    Id = 8,
                    Name = "Fiona Miller",
                    Email = "fiona.miller@example.com",
                    Password = "passwordMNO",
                    UserName = "fionamiller",
                    UserTypeId = 1,
                    GenderId = 2,
                    CountryId = 8
                },
                new Users
                {
                    Id = 9,
                    Name = "Gary Turner",
                    Email = "gary.turner@example.com",
                    Password = "passwordPQR",
                    UserName = "garyturner",
                    UserTypeId = 1,
                    GenderId = 1,
                    CountryId = 9
                },
                new Users
                {
                    Id = 10,
                    Name = "Heather White",
                    Email = "heather.white@example.com",
                    Password = "passwordSTU",
                    UserName = "heatherwhite",
                    UserTypeId = 1,
                    GenderId = 2,
                    CountryId = 10
                }
            );
            modelBuilder.Entity<Artist>().HasData(
                new Artist
                { Id = 1, FullName = "John Doe", GenderId = 1, CountryId = 1 },
                new Artist
                { Id = 2, FullName = "Jane Smith", GenderId = 2, CountryId = 2 },
                new Artist
                { Id = 3, FullName = "Alice Johnson", GenderId = 1, CountryId = 3 },
                new Artist
                { Id = 4, FullName = "Bob Brown", GenderId = 2, CountryId = 1 },
                new Artist
                { Id = 5, FullName = "Charlie Davis", GenderId = 1, CountryId = 2 },
                new Artist
                { Id = 6, FullName = "Eva Wilson", GenderId = 2, CountryId = 3 },
                new Artist
                { Id = 7, FullName = "Samuel Miller", GenderId = 1, CountryId = 1 },
                new Artist
                { Id = 8, FullName = "Olivia Taylor", GenderId = 2, CountryId = 2 },
                new Artist
                { Id = 9, FullName = "Maxwell Anderson", GenderId = 1, CountryId = 3 },
                new Artist
                { Id = 10, FullName = "Sophia White", GenderId = 2, CountryId = 1 }
            );
            modelBuilder.Entity<Releases>().HasData(
                new Releases
                {
                    Id = 1,
                    Name = "Pescado Rabioso",
                    ReleaseDate = new DateTime(1973, 10, 7),
                    UrlImage = "https://i.scdn.co/image/ab67616d0000b27350db5a166ea23d5d6c4cd387",
                    Description = "Explora un mundo de sonidos etéreos y melodías que te transportarán a paisajes oníricos.",
                    ReleaseTypeId = 1,
                    ArtistId = 1,
                    GenreId = 1
                },
                new Releases
                {
                    Id = 2,
                    Name = "Album One",
                    ReleaseDate = new DateTime(2022, 1, 15),
                    UrlImage = "https://e.snmc.io/i/600/w/315b12fb229529b6eca8d59ce5548e62/6595402/fiona-apple-when-the-pawn-Cover-Art.jpg",
                    Description = "Explora un mundo de sonidos etéreos y melodías que te transportarán a paisajes oníricos.",
                    ReleaseTypeId = 1,
                    ArtistId = 1,
                    GenreId = 1
                },
                new Releases
                {
                    Id = 3,
                    Name = "Greatest Hits",
                    ReleaseDate = new DateTime(2022, 3, 20),
                    UrlImage = "https://e.snmc.io/i/600/w/81d2709f05fece1955b1a9460fb7a611/6558603/wu-tang-clan-enter-the-wu-tang-36-chambers-Cover-Art.jpg",
                    Description = "Explora un mundo de sonidos etéreos y melodías que te transportarán a paisajes oníricos.",
                    ReleaseTypeId = 2,
                    ArtistId = 2,
                    GenreId = 2
                },
                new Releases
                {
                    Id = 4,
                    Name = "Epic Symphony",
                    ReleaseDate = new DateTime(2022, 5, 5),
                    UrlImage = "https://e.snmc.io/i/600/w/600ed05da538856e6e3363351e09d2ea/11480922/dreamwell-in-my-saddest-dreams-i-am-beside-you-Cover-Art.jpg",
                    Description = "Explora un mundo de sonidos etéreos y melodías que te transportarán a paisajes oníricos.",
                    ReleaseTypeId = 1,
                    ArtistId = 4,
                    GenreId = 4
                },
                new Releases
                {
                    Id = 5,
                    Name = "Jazz Reflections",
                    ReleaseDate = new DateTime(2022, 6, 12),
                    UrlImage = "https://e.snmc.io/i/600/w/f1765ef46d3357f09691d50235f90a2e/5801416/burial-untrue-Cover-Art.jpg",
                    Description = "Explora un mundo de sonidos etéreos y melodías que te transportarán a paisajes oníricos.",
                    ReleaseTypeId = 2,
                    ArtistId = 5,
                    GenreId = 5
                },
                new Releases
                {
                    Id = 6,
                    Name = "Rhythmic Beats",
                    ReleaseDate = new DateTime(2022, 7, 8),
                    UrlImage = "https://e.snmc.io/i/600/w/d5e6dc13402fb655ccfade4edfb8ffdd/11447491/the-beatles-now-and-then-Cover-Art.jpg",
                    Description = "Explora un mundo de sonidos etéreos y melodías que te transportarán a paisajes oníricos.",
                    ReleaseTypeId = 1,
                    ArtistId = 6,
                    GenreId = 6
                },
                new Releases
                {
                    Id = 7,
                    Name = "Electric Dreams",
                    ReleaseDate = new DateTime(2022, 9, 3),
                    UrlImage = "https://e.snmc.io/i/600/w/24c337b2e03f3e164e81f76349f749de/11299233/sampha-lahai-Cover-Art.jpg",
                    Description = "Explora un mundo de sonidos etéreos y melodías que te transportarán a paisajes oníricos.",
                    ReleaseTypeId = 1,
                    ArtistId = 7,
                    GenreId = 7
                },
                new Releases
                {
                    Id = 8,
                    Name = "Soulful Serenade",
                    ReleaseDate = new DateTime(2022, 10, 20),
                    UrlImage = "https://e.snmc.io/i/600/w/35e27de2a71fb6c6d549b2bfa44b26db/11378087/king-gizzard-and-the-lizard-wizard-the-silver-cord-Cover-Art.jpg",
                    Description = "Explora un mundo de sonidos etéreos y melodías que te transportarán a paisajes oníricos.",
                    ReleaseTypeId = 2,
                    ArtistId = 8,
                    GenreId = 8
                },
                new Releases
                {
                    Id = 9,
                    Name = "Harmonic Fusion",
                    ReleaseDate = new DateTime(2022, 11, 15),
                    UrlImage = "https://e.snmc.io/i/600/w/b3b909e2b34f516f0fafe47f374f5092/11357573/katie-dey-never-falter-hero-girl-Cover-Art.jpg",
                    Description = "Explora un mundo de sonidos etéreos y melodías que te transportarán a paisajes oníricos.",
                    ReleaseTypeId = 1,
                    ArtistId = 9,
                    GenreId = 9
                },
                new Releases
                {
                    Id = 10,
                    Name = "Lyrical Journeys",
                    ReleaseDate = new DateTime(2022, 12, 1),
                    UrlImage = "https://e.snmc.io/i/600/w/b86f77bdd57cc8ef80a33f908c0d154c/7017197/nirvana-mtv-unplugged-in-new-york-Cover-Art.jpg",
                    Description = "Explora un mundo de sonidos etéreos y melodías que te transportarán a paisajes oníricos.",
                    ReleaseTypeId = 1,
                    ArtistId = 10,
                    GenreId = 10
                },
                new Releases
                {
                    Id = 11,
                    Name = "Funky Grooves",
                    ReleaseDate = new DateTime(2023, 1, 10),
                    UrlImage = "https://e.snmc.io/i/600/w/6cf98641e1c9a01b80136c3a2bf9155d/8276371/tom-waits-bone-machine-Cover-Art.jpg",
                    Description = "Explora un mundo de sonidos etéreos y melodías que te transportarán a paisajes oníricos.",
                    ReleaseTypeId = 2,
                    ArtistId = 1,
                    GenreId = 10
                },
                new Releases
                {
                    Id = 12,
                    Name = "Cinematic Soundscape",
                    ReleaseDate = new DateTime(2023, 2, 18),
                    UrlImage = "https://e.snmc.io/i/600/w/4f148d18a53679fceb8fce7e1506d150/2109326/pulp-different-class-Cover-Art.jpg",
                    Description = "Explora un mundo de sonidos etéreos y melodías que te transportarán a paisajes oníricos.",
                    ReleaseTypeId = 2,
                    ArtistId = 2,
                    GenreId = 2
                },
                new Releases
                {
                    Id = 13,
                    Name = "Ethereal Echoes",
                    ReleaseDate = new DateTime(2023, 3, 5),
                    UrlImage = "https://e.snmc.io/i/600/w/bca2b066738e487fc4caeaeb5c9bb92d/11429205/reverend-kristin-michael-hayter-saved-Cover-Art.jpg",
                    Description = "Explora un mundo de sonidos etéreos y melodías que te transportarán a paisajes oníricos.",
                    ReleaseTypeId = 1,
                    ArtistId = 3,
                    GenreId = 3
                },
                new Releases
                {
                    Id = 14,
                    Name = "Symphonic Resonance",
                    ReleaseDate = new DateTime(2023, 4, 22),
                    UrlImage = "https://e.snmc.io/i/600/w/4ab09302801f94f26587acc12e7811ed/11404652/mike-burning-desire-Cover-Art.png",
                    Description = "Explora un mundo de sonidos etéreos y melodías que te transportarán a paisajes oníricos.",
                    ReleaseTypeId = 2,
                    ArtistId = 4,
                    GenreId = 4
                },
                new Releases
                {
                    Id = 15,
                    Name = "Acoustic Melodies",
                    ReleaseDate = new DateTime(2023, 5, 17),
                    UrlImage = "https://e.snmc.io/i/600/w/03408244d0416498486a81e5b479fb9a/11229865/ana-frango-eletrico-me-chama-de-gato-que-eu-sou-sua-Cover-Art.jpg",
                    Description = "Explora un mundo de sonidos etéreos y melodías que te transportarán a paisajes oníricos.",
                    ReleaseTypeId = 1,
                    ArtistId = 5,
                    GenreId = 1
                }

            ); ;
            modelBuilder.Entity<Review>().HasData(
                new Review
                {
                    Id = 1,
                    Text = "A masterpiece! Loved every moment.",
                    UserId = 1,
                    ReleaseId = 1,
                    RatingId = 5
                },
                new Review
                {
                    Id = 2,
                    Text = "Great album, amazing beats.",
                    UserId = 2,
                    ReleaseId = 2,
                    RatingId = 4
                },
                new Review
                {
                    Id = 3,
                    Text = "Not my style, but impressive nonetheless.",
                    UserId = 3,
                    ReleaseId = 3,
                    RatingId = 3
                },
                new Review
                {
                    Id = 4,
                    Text = "Classic vibes! Nostalgia at its best.",
                    UserId = 4,
                    ReleaseId = 4,
                    RatingId = 5
                },
                new Review
                {
                    Id = 5,
                    Text = "Unexpectedly good. Worth a listen.",
                    UserId = 5,
                    ReleaseId = 5,
                    RatingId = 4
                },
                new Review
                {
                    Id = 6,
                    Text = "Could be better, but not bad.",
                    UserId = 6,
                    ReleaseId = 6,
                    RatingId = 3
                },
                new Review
                {
                    Id = 7,
                    Text = "Incredible vocals! A must-listen.",
                    UserId = 7,
                    ReleaseId = 7,
                    RatingId = 5
                },
                new Review
                {
                    Id = 8,
                    Text = "Jazzy and smooth. Perfect for relaxation.",
                    UserId = 8,
                    ReleaseId = 8,
                    RatingId = 4
                },
                new Review
                {
                    Id = 9,
                    Text = "Not my cup of tea, but I see the appeal.",
                    UserId = 9,
                    ReleaseId = 9,
                    RatingId = 3
                },
                new Review
                {
                    Id = 10,
                    Text = "A musical journey! Loved every track.",
                    UserId = 10,
                    ReleaseId = 10,
                    RatingId = 5
                },
                new Review
                {
                    Id = 11,
                    Text = "Energetic and catchy. Can't stop listening.",
                    UserId = 1,
                    ReleaseId = 11,
                    RatingId = 4
                },
                new Review
                {
                    Id = 12,
                    Text = "Unique sound, but not my favorite.",
                    UserId = 2,
                    ReleaseId = 12,
                    RatingId = 3
                },
                new Review
                {
                    Id = 13,
                    Text = "A sonic masterpiece! Brilliantly composed.",
                    UserId = 3,
                    ReleaseId = 13,
                    RatingId = 5
                },
                new Review
                {
                    Id = 14,
                    Text = "Smooth and soulful. Great for late nights.",
                    UserId = 4,
                    ReleaseId = 14,
                    RatingId = 4
                },
                new Review
                {
                    Id = 15,
                    Text = "Not my genre, but I appreciate the talent.",
                    UserId = 5,
                    ReleaseId = 15,
                    RatingId = 3
                },
                new Review
                {
                    Id = 16,
                    Text = "Epic! Can't get enough of it.",
                    UserId = 6,
                    ReleaseId = 6,
                    RatingId = 5
                },
                new Review
                {
                    Id = 17,
                    Text = "Captivating lyrics. Hits you in the feels.",
                    UserId = 7,
                    ReleaseId = 7,
                    RatingId = 4
                },
                new Review
                {
                    Id = 18,
                    Text = "Decent. Has some good moments.",
                    UserId = 8,
                    ReleaseId = 8,
                    RatingId = 3
                },
                new Review
                {
                    Id = 19,
                    Text = "Pure brilliance! A modern classic.",
                    UserId = 9,
                    ReleaseId = 9,
                    RatingId = 5
                },
                new Review
                {
                    Id = 20,
                    Text = "Groovy and fun. Great for parties.",
                    UserId = 10,
                    ReleaseId = 10,
                    RatingId = 4
                }
            );
        }
    }
}
