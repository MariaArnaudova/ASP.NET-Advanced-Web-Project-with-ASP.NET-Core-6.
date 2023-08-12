
namespace ArtStroke.Services.Tests
{
    using Microsoft.EntityFrameworkCore;
    using ArtStroke.Data;
    using ArtStroke.Services.Data.Interfaces;
    using ArtStroke.Services.Data;
    using ArtStroke.Web.ViewModels.ArtWork;
    using static DatabaseSeeder;

    public class ArtWorkServiceTest
    {

        private DbContextOptions<ArtStrokeDbContext> dbOptions;
        private ArtStrokeDbContext dbContext;
        private IArtistService artistService;
        private IArtWorkService artWorkService;


        [OneTimeSetUp]
        public void OnTimeSetUp()
        {

            this.dbOptions = new DbContextOptionsBuilder<ArtStrokeDbContext>()
                .UseInMemoryDatabase("ArtStrokeInMemory" + Guid.NewGuid().ToString())
                .Options;

            this.dbContext = new ArtStrokeDbContext(this.dbOptions);
            this.dbContext.Database.EnsureCreated();
            SeedDatabase(this.dbContext);

            this.artistService = new ArtistService(this.dbContext);
            this.artWorkService = new ArtWorkService(this.dbContext);
        }

        [Test]
        public async Task AllArtworksByArtistIdAsyncReturnTrueIfExist()
        {
            string artistId = Artist.Id.ToString();
            IEnumerable<ArtworkAllViewModel> models = new List<ArtworkAllViewModel>()
            {
                 new ArtworkAllViewModel()
                  {
                      Id = Artwork.Id.ToString(),
                      ImageUrl = "https://render.fineartamerica.com/images/images-profile-flow/400/images/artworkimages/mediumlarge/1/blue-boat-maria-arnaudova.jpg",
                      IsDesignedInPrint = true,
                      Style = Style.Name,
                      Title = "Single Boat",
                  }

             };

            var result = await this.artWorkService.AllArtworksByArtistIdAsync(artistId);
            Assert.AreEqual(models.Count(), result.Count());
        }

        [Test]
        public async Task AllArtworksByArtistIdAsyncReturnFalseIfNotExist()
        {
            string artistId = Artist.Id.ToString();
            IEnumerable<ArtworkAllViewModel> models = new List<ArtworkAllViewModel>() { };

            var result = await this.artWorkService.AllArtworksByArtistIdAsync(artistId);
            Assert.AreNotEqual(models.Count(), result.Count());
        }

        [Test]

        public async Task CreateArtworkIsSuccess()
        {
            string artistId = Artist.Id.ToString();

            var artwork = Artwork;
            ArtWorkFormModel model = new ArtWorkFormModel()
            {
                CreatingYear = 2022,
                Height = 50,
                ImageUrl = "https://render.fineartamerica.com/images/images-profile-flow/400/images/artworkimages/mediumlarge/1/swirling-of-life-maria-arnaudova.jpg",
                IsDesignedInPrint = true,
                StyleId = 4,
                Technique = "Aquarel",
                Width = 50,
                Title = "Swirling",
            };
            string createdArtworkId = await this.artWorkService.CreateArtworkAsync(artistId, model);

            Assert.IsNotNull(createdArtworkId);
        }



        [Test]

        public async Task CreateArtworkIsNotSuccessIfModelIsInvalid()
        {
            string artistId = Artist.Id.ToString();

            var artwork = Artwork;
            ArtWorkFormModel model = new ArtWorkFormModel()
            {
                CreatingYear = 1,
                Height = 50,
                ImageUrl = "https://render.fineartamerica.com/images/images-profile-flow/400/images/artworkimages/mediumlarge/1/swirling-of-life-maria-arnaudova.jpg",
                IsDesignedInPrint = true,
                StyleId = 4,
                Technique = "Aquarel",
                Width = 50,
                Title = "Swirling",
            };
            string createdArtworkId = await this.artWorkService.CreateArtworkAsync(artistId, model);

            Assert.IsNotNull(createdArtworkId);
        }


        [Test]

        public async Task CreateDesignArtworkAsyncIsSuccess()
        {
            string artistId = Artist.Id.ToString();
            string artworkId = Artwork.Id.ToString();
            ArtWorkBecomePrintDesignFormModel model = new ArtWorkBecomePrintDesignFormModel()
            {
                Title = "Monstera",
                CreatorName = "Pepi",
                Description = "New print with original artwork",
                Height = 50,
                Width = 50,
                ImageUrl = "https://render.fineartamerica.com/images/images-profile-flow/400/images/artworkimages/mediumlarge/3/plam-leaf-monstera-maria-arnaudova.jpg",
            };
            string printId = await this.artWorkService.CreateDesignArtworkAsync(artistId, artworkId, model);

            Assert.IsNotNull(printId);
        }

        [Test]

        public async Task DeleteArtworkSuccessfully()
        {
            string artworkId = Artwork.Id.ToString();
            await this.artWorkService.DeleteArtworkByIdAsync(artworkId);

            Assert.AreEqual(Artwork.IsActive, false);
        }

        [Test]

        public async Task ExistByIdIsTrue()
        {
            string artworkId = Artwork.Id.ToString();
            bool isExist = await this.artWorkService.ExistByIdAsync(artworkId);
            Assert.False(isExist);
        }

        //[Test]  
        //public async Task GetArtworkDeleteBtIdIsNotSuccess()
        //{
        //    string artworkId = Artwork.Id.ToString();
        //    ArtworkDeleteViewModel model = new ArtworkDeleteViewModel()
        //    {
        //        Author = Artwork.Artist.Name,
        //        ImageUrl = Artwork.ImageUrl,
        //        Style = Artwork.Style.Name,
        //        Title = Artwork.Title,
        //    };
        //    var artworkModel = await this.artWorkService.GetArtworkDeleteBtIdInAsync(artworkId);

            
        //}
    }
}
