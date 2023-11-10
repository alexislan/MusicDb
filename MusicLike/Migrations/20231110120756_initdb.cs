using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MusicLike.Migrations
{
    /// <inheritdoc />
    public partial class initdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ratting = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReleaseType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReleaseType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GenderId = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Artists_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Artists_Gender_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Gender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserTypeId = table.Column<int>(type: "int", nullable: false),
                    GenderId = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Gender_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Gender",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_UserTypes_UserTypeId",
                        column: x => x.UserTypeId,
                        principalTable: "UserTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Releases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UrlImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseTypeId = table.Column<int>(type: "int", nullable: false),
                    ArtistId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Releases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Releases_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Releases_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Releases_ReleaseType_ReleaseTypeId",
                        column: x => x.ReleaseTypeId,
                        principalTable: "ReleaseType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ReleaseId = table.Column<int>(type: "int", nullable: false),
                    RatingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Rating_RatingId",
                        column: x => x.RatingId,
                        principalTable: "Rating",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Releases_ReleaseId",
                        column: x => x.ReleaseId,
                        principalTable: "Releases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Estados Unidos" },
                    { 2, "Canadá" },
                    { 3, "Reino Unido" },
                    { 4, "Francia" },
                    { 5, "Alemania" },
                    { 6, "España" },
                    { 7, "Italia" },
                    { 8, "Argentina" },
                    { 9, "Brasil" },
                    { 10, "México" }
                });

            migrationBuilder.InsertData(
                table: "Gender",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Female" },
                    { 2, "Male" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Rock" },
                    { 2, "Pop" },
                    { 3, "Hip-Hop" },
                    { 4, "Country" },
                    { 5, "Electronic" },
                    { 6, "Jazz" },
                    { 7, "Classical" },
                    { 8, "R&B" },
                    { 9, "Reggae" },
                    { 10, "Metal" }
                });

            migrationBuilder.InsertData(
                table: "Rating",
                columns: new[] { "Id", "Ratting" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 }
                });

            migrationBuilder.InsertData(
                table: "ReleaseType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Live" },
                    { 2, "Studio" }
                });

            migrationBuilder.InsertData(
                table: "UserTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "User" },
                    { 2, "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "Id", "CountryId", "FullName", "GenderId" },
                values: new object[,]
                {
                    { 1, 1, "John Doe", 1 },
                    { 2, 2, "Jane Smith", 2 },
                    { 3, 3, "Alice Johnson", 1 },
                    { 4, 1, "Bob Brown", 2 },
                    { 5, 2, "Charlie Davis", 1 },
                    { 6, 3, "Eva Wilson", 2 },
                    { 7, 1, "Samuel Miller", 1 },
                    { 8, 2, "Olivia Taylor", 2 },
                    { 9, 3, "Maxwell Anderson", 1 },
                    { 10, 1, "Sophia White", 2 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CountryId", "Email", "GenderId", "Name", "Password", "UserName", "UserTypeId" },
                values: new object[,]
                {
                    { 1, 1, "john.doe@example.com", 1, "John Doe", "password123", "johndoe", 1 },
                    { 2, 2, "jane.smith@example.com", 2, "Jane Smith", "password456", "janesmith", 1 },
                    { 3, 3, "bob.johnson@example.com", 1, "Bob Johnson", "password789", "bobjohnson", 1 },
                    { 4, 4, "alice.brown@example.com", 2, "Alice Brown", "passwordABC", "alicebrown", 1 },
                    { 5, 5, "charlie.davis@example.com", 1, "Charlie Davis", "passwordDEF", "charliedavis", 1 },
                    { 6, 6, "eva.wilson@example.com", 2, "Eva Wilson", "passwordGHI", "evawilson", 1 },
                    { 7, 7, "david.lee@example.com", 1, "David Lee", "passwordJKL", "davidlee", 1 },
                    { 8, 8, "fiona.miller@example.com", 2, "Fiona Miller", "passwordMNO", "fionamiller", 1 },
                    { 9, 9, "gary.turner@example.com", 1, "Gary Turner", "passwordPQR", "garyturner", 1 },
                    { 10, 10, "heather.white@example.com", 2, "Heather White", "passwordSTU", "heatherwhite", 1 }
                });

            migrationBuilder.InsertData(
                table: "Releases",
                columns: new[] { "Id", "ArtistId", "Description", "GenreId", "Name", "ReleaseDate", "ReleaseTypeId", "UrlImage" },
                values: new object[,]
                {
                    { 1, 1, "Explora un mundo de sonidos etéreos y melodías que te transportarán a paisajes oníricos.", 1, "Pescado Rabioso", new DateTime(1973, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "https://i.scdn.co/image/ab67616d0000b27350db5a166ea23d5d6c4cd387" },
                    { 2, 1, "Explora un mundo de sonidos etéreos y melodías que te transportarán a paisajes oníricos.", 1, "Album One", new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "https://e.snmc.io/i/600/w/315b12fb229529b6eca8d59ce5548e62/6595402/fiona-apple-when-the-pawn-Cover-Art.jpg" },
                    { 3, 2, "Explora un mundo de sonidos etéreos y melodías que te transportarán a paisajes oníricos.", 2, "Greatest Hits", new DateTime(2022, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://e.snmc.io/i/600/w/81d2709f05fece1955b1a9460fb7a611/6558603/wu-tang-clan-enter-the-wu-tang-36-chambers-Cover-Art.jpg" },
                    { 4, 4, "Explora un mundo de sonidos etéreos y melodías que te transportarán a paisajes oníricos.", 4, "Epic Symphony", new DateTime(2022, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "https://e.snmc.io/i/600/w/600ed05da538856e6e3363351e09d2ea/11480922/dreamwell-in-my-saddest-dreams-i-am-beside-you-Cover-Art.jpg" },
                    { 5, 5, "Explora un mundo de sonidos etéreos y melodías que te transportarán a paisajes oníricos.", 5, "Jazz Reflections", new DateTime(2022, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://e.snmc.io/i/600/w/f1765ef46d3357f09691d50235f90a2e/5801416/burial-untrue-Cover-Art.jpg" },
                    { 6, 6, "Explora un mundo de sonidos etéreos y melodías que te transportarán a paisajes oníricos.", 6, "Rhythmic Beats", new DateTime(2022, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "https://e.snmc.io/i/600/w/d5e6dc13402fb655ccfade4edfb8ffdd/11447491/the-beatles-now-and-then-Cover-Art.jpg" },
                    { 7, 7, "Explora un mundo de sonidos etéreos y melodías que te transportarán a paisajes oníricos.", 7, "Electric Dreams", new DateTime(2022, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "https://e.snmc.io/i/600/w/24c337b2e03f3e164e81f76349f749de/11299233/sampha-lahai-Cover-Art.jpg" },
                    { 8, 8, "Explora un mundo de sonidos etéreos y melodías que te transportarán a paisajes oníricos.", 8, "Soulful Serenade", new DateTime(2022, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://e.snmc.io/i/600/w/35e27de2a71fb6c6d549b2bfa44b26db/11378087/king-gizzard-and-the-lizard-wizard-the-silver-cord-Cover-Art.jpg" },
                    { 9, 9, "Explora un mundo de sonidos etéreos y melodías que te transportarán a paisajes oníricos.", 9, "Harmonic Fusion", new DateTime(2022, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "https://e.snmc.io/i/600/w/b3b909e2b34f516f0fafe47f374f5092/11357573/katie-dey-never-falter-hero-girl-Cover-Art.jpg" },
                    { 10, 10, "Explora un mundo de sonidos etéreos y melodías que te transportarán a paisajes oníricos.", 10, "Lyrical Journeys", new DateTime(2022, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "https://e.snmc.io/i/600/w/b86f77bdd57cc8ef80a33f908c0d154c/7017197/nirvana-mtv-unplugged-in-new-york-Cover-Art.jpg" },
                    { 11, 1, "Explora un mundo de sonidos etéreos y melodías que te transportarán a paisajes oníricos.", 10, "Funky Grooves", new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://e.snmc.io/i/600/w/6cf98641e1c9a01b80136c3a2bf9155d/8276371/tom-waits-bone-machine-Cover-Art.jpg" },
                    { 12, 2, "Explora un mundo de sonidos etéreos y melodías que te transportarán a paisajes oníricos.", 2, "Cinematic Soundscape", new DateTime(2023, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://e.snmc.io/i/600/w/4f148d18a53679fceb8fce7e1506d150/2109326/pulp-different-class-Cover-Art.jpg" },
                    { 13, 3, "Explora un mundo de sonidos etéreos y melodías que te transportarán a paisajes oníricos.", 3, "Ethereal Echoes", new DateTime(2023, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "https://e.snmc.io/i/600/w/bca2b066738e487fc4caeaeb5c9bb92d/11429205/reverend-kristin-michael-hayter-saved-Cover-Art.jpg" },
                    { 14, 4, "Explora un mundo de sonidos etéreos y melodías que te transportarán a paisajes oníricos.", 4, "Symphonic Resonance", new DateTime(2023, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "https://e.snmc.io/i/600/w/4ab09302801f94f26587acc12e7811ed/11404652/mike-burning-desire-Cover-Art.png" },
                    { 15, 5, "Explora un mundo de sonidos etéreos y melodías que te transportarán a paisajes oníricos.", 1, "Acoustic Melodies", new DateTime(2023, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "https://e.snmc.io/i/600/w/03408244d0416498486a81e5b479fb9a/11229865/ana-frango-eletrico-me-chama-de-gato-que-eu-sou-sua-Cover-Art.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "RatingId", "ReleaseId", "Text", "UserId" },
                values: new object[,]
                {
                    { 1, 5, 1, "A masterpiece! Loved every moment.", 1 },
                    { 2, 4, 2, "Great album, amazing beats.", 2 },
                    { 3, 3, 3, "Not my style, but impressive nonetheless.", 3 },
                    { 4, 5, 4, "Classic vibes! Nostalgia at its best.", 4 },
                    { 5, 4, 5, "Unexpectedly good. Worth a listen.", 5 },
                    { 6, 3, 6, "Could be better, but not bad.", 6 },
                    { 7, 5, 7, "Incredible vocals! A must-listen.", 7 },
                    { 8, 4, 8, "Jazzy and smooth. Perfect for relaxation.", 8 },
                    { 9, 3, 9, "Not my cup of tea, but I see the appeal.", 9 },
                    { 10, 5, 10, "A musical journey! Loved every track.", 10 },
                    { 11, 4, 11, "Energetic and catchy. Can't stop listening.", 1 },
                    { 12, 3, 12, "Unique sound, but not my favorite.", 2 },
                    { 13, 5, 13, "A sonic masterpiece! Brilliantly composed.", 3 },
                    { 14, 4, 14, "Smooth and soulful. Great for late nights.", 4 },
                    { 15, 3, 15, "Not my genre, but I appreciate the talent.", 5 },
                    { 16, 5, 6, "Epic! Can't get enough of it.", 6 },
                    { 17, 4, 7, "Captivating lyrics. Hits you in the feels.", 7 },
                    { 18, 3, 8, "Decent. Has some good moments.", 8 },
                    { 19, 5, 9, "Pure brilliance! A modern classic.", 9 },
                    { 20, 4, 10, "Groovy and fun. Great for parties.", 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artists_CountryId",
                table: "Artists",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Artists_GenderId",
                table: "Artists",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Releases_ArtistId",
                table: "Releases",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Releases_GenreId",
                table: "Releases",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Releases_ReleaseTypeId",
                table: "Releases",
                column: "ReleaseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_RatingId",
                table: "Reviews",
                column: "RatingId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ReleaseId",
                table: "Reviews",
                column: "ReleaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CountryId",
                table: "Users",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_GenderId",
                table: "Users",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserTypeId",
                table: "Users",
                column: "UserTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "Releases");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "ReleaseType");

            migrationBuilder.DropTable(
                name: "UserTypes");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Gender");
        }
    }
}
