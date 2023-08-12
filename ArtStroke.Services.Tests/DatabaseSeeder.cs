

namespace ArtStroke.Services.Tests
{
    using ArtStroke.Data;
    using ArtStroke.Data.Models;
    using System.Globalization;

    public static class DatabaseSeeder
    {

        public static ApplicationUser ArtistUser;
        public static Artist Artist;
        public static ArtWork Artwork;
        public static Style Style;


        public static void SeedDatabase(ArtStrokeDbContext dbContext)
        {
            dbContext.Database.EnsureCreated(); 

            ArtistUser = new ApplicationUser()
            {
                UserName = "Test",
                NormalizedUserName = "TEST",
                Email = "test@test.com",
                NormalizedEmail = "TEST@TESTS.COM",
                EmailConfirmed = true,
                PasswordHash = "8D969EEF6ECAD3C29A3A629280E686CF0C3F5D5A86AFF3CA12020C923ADC6C92",
                SecurityStamp = "82a5dccd-a7a0-4656-a222-63d54c4fe3cb",
                TwoFactorEnabled = false,
                ConcurrencyStamp = "39eaa544-1469-4818-8e95-a29590c32a55",
                FirstName = "Test",
                LastName = "UserTest"
            };

            Artist = new Artist()
            {
                PhoneNumber = "+3593333333333",
                User = ArtistUser,
                Biography= "Test biography",
                Name= "Test Name",
                
            };


            Style = new Style()
            {
                Name = "Classic"
            };

            string yearString = "2022";
            DateTime creatingYear;
            DateTime.TryParseExact(yearString, "yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out creatingYear);

            Artwork = new ArtWork()
            {
                Title = "Single Boat",
                Technique = "Oil on canvas",
                StyleId = 1,
                Width = 35,
                Height = 25,
                ImageUrl = "https://render.fineartamerica.com/images/images-profile-flow/400/images/artworkimages/mediumlarge/1/blue-boat-maria-arnaudova.jpg",
                CreatingYear = creatingYear,
                ArtistId = Artist.Id,
                CreatedOn = creatingYear,
                IsActive = true,
                IsDesignedInPrint = true,
                Style = Style,
                PrintDesigns = new HashSet<PrintDesign>(),        
            };


            dbContext.Users.Add(ArtistUser);
            dbContext.Artists.Add(Artist);
            dbContext.ArtWorks.Add(Artwork);
            dbContext.SaveChanges();
        }

    };
}
