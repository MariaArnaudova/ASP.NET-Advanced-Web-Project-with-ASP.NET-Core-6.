

namespace ArtStroke.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using ArtStroke.Data;
    using ArtStroke.Web.ViewModels.Artist;
    using Data.Interfaces;
    using ArtStroke.Data.Models;

    public class ArtistService : IArtistService
    {
        private readonly ArtStrokeDbContext dbContext;

        public ArtistService(ArtStrokeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> ArtistExistByPhonenumberAsync(string phonenumber)
        {
            bool result = await this.dbContext
                .Artists
                .AnyAsync(a => a.PhoneNumber == phonenumber);

            return result;
        }

        public async Task Create(string userId, BecomeArtistFormModel model)
        {
            Artist newArtist = new Artist()
            {
                Name = model.Name,
                PhoneNumber = model.PhoneNumber,
                UserId = Guid.Parse(userId),
            };

            await this.dbContext.AddAsync(newArtist);
            await this.dbContext.SaveChangesAsync();

        }


        public async Task<bool> HasArtistByUserIdAsync(string userId)
        {
            bool result = await this.dbContext
             .Artists
             .AnyAsync(u => u.UserId.ToString() == userId);

            return result;
        }
    }
}
