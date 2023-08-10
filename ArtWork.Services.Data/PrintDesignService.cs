
namespace ArtStroke.Services.Data
{
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    using ArtStroke.Web.ViewModels.PrintDesign;
    using ArtStroke.Data;
    using ArtStroke.Services.Data.Interfaces;
    using ArtStroke.Data.Models;
    using ArtStroke.Web.ViewModels.ArtWork;
    using System.Security.Cryptography.X509Certificates;
    using System.Globalization;

    public class PrintDesignService : IPrintDesignService
    {

        private readonly ArtStrokeDbContext dbContext;
        public PrintDesignService(ArtStrokeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<AllPrintDesignsViewModel>> AllAsync()
        {
            IEnumerable<AllPrintDesignsViewModel> prints = await this.dbContext
                  .PrintDesigns
                  .Include(pd => pd.ArtWork)
                  .Where(p => p.IsActive)
                  .Select(pd => new AllPrintDesignsViewModel()
                  {
                      Id = pd.Id.ToString(),
                      Title = pd.Title,
                      CreatorName = pd.CreatorName,
                      Height = pd.Height,
                      Width = pd.Width,
                      ImageUrl = pd.ImageUrl,
                      UserId = pd.UserId.ToString(),
                      ArtWorkId = pd.ArtWorkId.ToString(),
                      ArtWork = new ArtworkAllViewModel()
                      {
                          Id = pd.ArtWork.Id.ToString(),
                          Title = pd.ArtWork.Title,
                          ImageUrl = pd.ArtWork.ImageUrl,
                          IsDesignedInPrint = pd.ArtWork.IsDesignedInPrint,
                          Style = pd.ArtWork.Style.Name,
                      }
                  })
                  .ToListAsync();

            return prints;
        }

        public async Task<IEnumerable<AllPrintDesignsByArtworkIdViewModel>> AllArtworksPrintsByUserIdAndArtworkIdAsync(string artworkId, string userId)
        {

            ArtWork atrworkById = await this.dbContext
                .ArtWorks
                .Include(a => a.Style)
                .Where(a => a.IsActive)
                .FirstAsync(a => a.Id.ToString() == artworkId);

            ArtworkAllViewModel artworkModel = new ArtworkAllViewModel()
            {
                Id = artworkId,
                ImageUrl = atrworkById.ImageUrl,
                IsDesignedInPrint = atrworkById.IsDesignedInPrint,
                Style = atrworkById.Style.Name,
                Title = atrworkById.Title,
            };

            IEnumerable<AllPrintDesignsByArtworkIdViewModel> allPrintsByArtworkId = await this.dbContext
                 .PrintDesigns
                 .Where(p => p.IsActive)
                 .Where(p => p.ArtWorkId.ToString() == artworkId)
                 .Select(p => new AllPrintDesignsByArtworkIdViewModel()
                 {
                     Id = p.Id.ToString(),
                     Title = p.Title,
                     UserId = p.UserId.ToString(),
                     ArtWorkId = p.ArtWorkId.ToString(),
                     //ArtWorkId = p.ArtWorkId.GetValueOrDefault(),
                     ////ArtWorkId = p.ArtWorkId,
                     CreatorName = p.CreatorName,
                     Height = p.Height,
                     Width = p.Width,
                     ImageUrl = p.ImageUrl,
                     ArtWork = artworkModel,
                     IsCreatedByCurrentUser = p.UserId.ToString() == userId,
                 }).ToArrayAsync();

            return allPrintsByArtworkId;
        }

        public async Task<PrintDesignDetailsViewModel> GetPrintById(string printId)
        {
            PrintDesign print = await this.dbContext
                 .PrintDesigns
                 .Where(p => p.IsActive)
               .FirstAsync(p => p.Id.ToString() == printId);


            return new PrintDesignDetailsViewModel()
            {
                Id = print.Id.ToString(),
                Title = print.Title,
                CreatorName = print.CreatorName,
                Height = print.Height,
                Width = print.Width,
                ImageUrl = print.ImageUrl,
                Description = print.Description,
                ArtWorkId = print.ArtWorkId?.ToString(),
                //ArtWorkId = print.ArtWorkId.ToString(),
            };
        }


        public async Task<bool> ExistPrintByIdAsync(string printId)
        {
            bool result = await this.dbContext
                .PrintDesigns
                .Where(p => p.IsActive)
               .AnyAsync(p => p.Id.ToString() == printId);


            return result;
        }

        public async Task<int> GetPrintsCollectionByidCount(string printId)
        {
            IEnumerable<PrintDesign> printsCount = await this.dbContext
                .PrintDesigns
                .Where(p => p.IsActive)
                .Where(p => p.Id.ToString() == printId)
               .ToListAsync();

            int count = printsCount.Count();
            return count;
        }

        public async Task<IEnumerable<AllPrintsByUserIdModel>> GetPrintsByUserId(string userId)
        {
            IEnumerable<AllPrintsByUserIdModel> printsByUserId = await this.dbContext
                .PrintDesigns
                .Where(p => p.IsActive)
                .Where(p => p.UserId.ToString() == userId)
                .Select(p => new AllPrintsByUserIdModel
                {
                    Title = p.Title,
                    ImageUrl = p.ImageUrl,
                    CreatorName = p.CreatorName,
                    Height = p.Height,
                    Width = p.Width,
                    Id = p.Id.ToString(),
                    ArtWorkId = p.ArtWorkId.GetValueOrDefault(),
                    //ArtWorkId = p.ArtWorkId,
                    UserId = p.UserId
                })
                .ToArrayAsync();

            return printsByUserId;
        }

        public async Task<bool> IsCratedPrintByUserIdAsync(string printId, string userId)
        {
            PrintDesign print = await this.dbContext
                .PrintDesigns
                .FirstAsync(p => p.Id.ToString() == printId);


            return print.UserId.ToString() == userId;

        }

        public async Task<bool> ExistByIdAsync(string printId)
        {
            bool result = await this.dbContext
                .PrintDesigns
                .Where(a => a.IsActive)
                .AnyAsync(a => a.Id.ToString() == printId);

            return result;
        }

        public async Task<bool> IsUserCreatorOfPrint(string printId, string userId)
        {
            PrintDesign print = await this.dbContext
                .PrintDesigns
                .Where(a => a.IsActive)
                .FirstAsync(a => a.Id.ToString() == printId);


            return print.UserId.ToString() == userId;
        }

        public async Task<PrintCreateFormModel> GetPrintForEditByIdAsync(string printId)
        {
            PrintDesign print = await this.dbContext
               .PrintDesigns
               .Where(a => a.IsActive)
               .Include(a => a.ArtWork)
               .Include(a => a.User)
               .FirstAsync(a => a.Id.ToString() == printId);


            return new PrintCreateFormModel
            {
                Id = print.Id.ToString(),
                Title = print.Title,
                Width = print.Width,
                Height = print.Height,
                CreatorName = print.CreatorName,
                Description = print.Description,
                ImageUrl = print.ImageUrl,
                IsActive = print.IsActive,
                UserId = print.User.Id.ToString(),
                ArtWorkId = print.ArtWork.Id.ToString(),
            };
        }

        public async Task EditPrintBtIdInFormModelAsync(string printId, PrintCreateFormModel model)
        {
            PrintDesign print = await this.dbContext
                .PrintDesigns
                .Where(a => a.IsActive)
                .FirstAsync(a => a.Id.ToString() == printId);


            print.Title = model.Title;
            print.Width = model.Width;
            print.Height = model.Height;
            print.ImageUrl = model.ImageUrl;
            print.IsActive = true;
            print.Description = model.Description;
            print.ArtWorkId = Guid.Parse(model.ArtWorkId);
            print.UserId = Guid.Parse(model.UserId);
            print.CreatorName = model.CreatorName;

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<PrintDeleteViewModel> GetPrintDeleteBtIdInAsync(string printId)
        {

            PrintDesign print = await this.dbContext
            .PrintDesigns
            .Where(a => a.IsActive)
                .FirstAsync(a => a.Id.ToString() == printId);

            return new PrintDeleteViewModel
            {
                Id = printId,
                Title = print.Title,
                ImageUrl = print.ImageUrl,
                Creator = print.CreatorName,
            };
        }

        public async Task DeletePrintDesignByIdAsync(string printId)
        {
            PrintDesign print = await this.dbContext
                  .PrintDesigns
                  .Where(a => a.IsActive)
                  .FirstAsync(a => a.Id.ToString() == printId);

            ArtWork artwork = await this.dbContext
                .ArtWorks
                .Where(a => a.IsActive)
                .FirstAsync(a => a.Id.ToString() == print.ArtWorkId.ToString());

            artwork.IsDesignedInPrint = false;

            //if (this.dbContext
            //    .ArtWorks.Count() == 0)
            //{

            //    var artworks = await this.dbContext
            //        .ArtWorks
            //        .Where(a => a.IsActive)
            //        .Select(a => a.IsDesignedInPrint == false)
            //        .ToArrayAsync();

            //    await this.dbContext.SaveChangesAsync();
            //}
            print.IsActive = false;

            await this.dbContext.SaveChangesAsync();
        }


    }
}
