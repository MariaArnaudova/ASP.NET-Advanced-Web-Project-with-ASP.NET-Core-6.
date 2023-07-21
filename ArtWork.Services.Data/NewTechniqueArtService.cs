
namespace ArtStroke.Services.Data
{
    using ArtStroke.Data;
    using ArtStroke.Data.Models;
    using ArtStroke.Services.Data.Interfaces;
    using ArtStroke.Web.ViewModels.NewTechniqueArt;
    using Microsoft.EntityFrameworkCore;

    public class NewTechniqueArtService : INewTechniqueArtService
    {
        private readonly ArtStrokeDbContext dbContext;

        public NewTechniqueArtService(ArtStrokeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<AllTechniquesViewModel>> AllAsync()
        {

            IEnumerable<AllTechniquesViewModel> allTechnique = await this.dbContext
                .NewTechiqueArts
                .Select(t => new AllTechniquesViewModel()
                {
                    Description = t.Description,
                    ImageUrl = t.ImageUrl,
                    Title = t.Title,
                    UserId = t.UserId.ToString(),
                })
                .ToArrayAsync();      
            return allTechnique;
        }

        public async Task<string> CreateNewTechnique(string userId, TechniqueArtsFormModel model)
        {
            NewTechniqueArt techniqueArt = new NewTechniqueArt()
            {
                Title= model.Title, 
                Description= model.Description, 
                ImageUrl= model.ImageUrl,
                UserId =Guid.Parse(userId),
            };

            await this.dbContext.NewTechiqueArts.AddAsync(techniqueArt);
            await this.dbContext.SaveChangesAsync();

            return techniqueArt.Id.ToString();
        }
    }
}
