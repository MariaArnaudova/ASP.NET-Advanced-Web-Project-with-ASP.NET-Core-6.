
namespace ArtStroke.Services.Tests
{
    using Microsoft.EntityFrameworkCore;
    using ArtStroke.Data;
    using ArtStroke.Services.Data;
    using ArtStroke.Services.Data.Interfaces;
    using static DatabaseSeeder;

    public class ArtistServiceTests
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
            this.artWorkService =  new ArtWorkService(this.dbContext);
        }

        [Test]
        public async Task HasArtistByUserIdAsyncShouldReturnTrueWhenExists()
        {
            string existingArtistId = ArtistUser.Id.ToString();
            bool result = await this.artistService.HasArtistByUserIdAsync(existingArtistId);
            Assert.True(result);
        }

        [Test]
        public async Task HasArtistByUserIdAsyncShouldReturnFalseWhenDoNotExists()
        {
            string existingArtistId = "BB573B0F-06A3-484B-878D-792514CAE7DD";
            bool result = await this.artistService.HasArtistByUserIdAsync(existingArtistId);
            Assert.False(result);
        }

        [Test]
        public async Task HasArtworkByIdAsyncShouldReturnTrueIfExists()
        {
            string artworkId = Artwork.Id.ToString();
            string existingArtistId = ArtistUser.Id.ToString();
            bool result = await this.artistService.HasArtworkByIdAsync(artworkId, existingArtistId);
            Assert.True(result);
        }

        [Test]
        public async Task HasArtworkByIdAsyncShouldReturnFalseIfDoNotExists()
        {
            string artworkId = Artwork.Id.ToString();
            string existingArtistId = "BB573B0F-06A3-484B-878D-792514CAE7DD";
            bool result = await this.artistService.HasArtworkByIdAsync(artworkId, existingArtistId);
            Assert.False(result);
        }

        [Test]
        public async Task GetArtistIdByUserIdAsyncShouldReturnTrueIfExists()
        {
            string artistId = Artist.Id.ToString();
            string existingArtistByUserId = ArtistUser.Id.ToString();
            string result = await this.artistService.GetArtistIdByUserIdAsync(existingArtistByUserId);
            Assert.That(artistId, Is.EqualTo(result));
        }

        [Test]
        public async Task GetArtistIdByUserIdAsyncShouldReturnFalseIfNotExists()
        {
            string artistId = ArtistUser.Id.ToString();
            string existingArtistByUserId = ArtistUser.Id.ToString();
            string result = await this.artistService.GetArtistIdByUserIdAsync(existingArtistByUserId);
            Assert.That(artistId, Is.Not.EqualTo(result));
        }

        [Test]

        public async Task ArtistExistByPhonenumberAsyncReturnTrueIfExists()
        {
            bool existArtistByPhoneNumber = await this.artistService.ArtistExistByPhonenumberAsync("+3593333333333");
            Assert.True(existArtistByPhoneNumber);
        }

        [Test]
        public async Task ArtistExistByPhonenumberAsyncReturnFalseIfNotExists()
        {
            bool existArtistByPhoneNumber = await this.artistService.ArtistExistByPhonenumberAsync("+3593333333344");
            Assert.False(existArtistByPhoneNumber);
        }
    }
}