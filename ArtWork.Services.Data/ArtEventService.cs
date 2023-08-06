using ArtStroke.Data;
using ArtStroke.Data.Models;
using ArtStroke.Services.Data.Interfaces;
using ArtStroke.Web.ViewModels.ArtEvent;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtStroke.Services.Data
{
    public class ArtEventService : IArtEventService
    {
        private readonly ArtStrokeDbContext dbContext;
        public ArtEventService(ArtStrokeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<AllArtEventByIdViewModel>> AllArtEventsAsync()
        {
            IEnumerable<AllArtEventByIdViewModel> allArtEvents = await this.dbContext
                .ArtEvents
                .Where(e => e.IsActive)
                .Select(e => new AllArtEventByIdViewModel
                {
                    Id = e.Id.ToString(),
                    ImageUrl = e.ImageUrl,
                    Information = e.Information,
                    PublicDate = e.PublicDate.ToString("yyyy"),
                    Title = e.Title
                })
                .ToArrayAsync();

            return allArtEvents;
        }

        public async Task<string> CreateEventAsync(ArtEventFormModel model)
        {
            //DateTime creatingYear;
            //DateTime.TryParseExact(model.PublicDate, "yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out creatingYear);
            int year =model.PublicDate;
            DateTime date = new DateTime(year, 1, 1);

            ArtEvent artEvent = new ArtEvent()
            {
                PublicDate = date,
                Title = model.Title,
                ImageUrl = model.ImageUrl,
                Information = model.Information,
                IsActive = true
            };

            await this.dbContext.ArtEvents.AddAsync(artEvent);
            await this.dbContext.SaveChangesAsync();

            return artEvent.Id.ToString();
        }

    }
}
