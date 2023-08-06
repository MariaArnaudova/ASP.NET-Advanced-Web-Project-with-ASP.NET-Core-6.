using ArtStroke.Web.ViewModels.ArtEvent;
using ArtStroke.Web.ViewModels.ArtWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtStroke.Services.Data.Interfaces
{
    public interface IArtEventService
    {
        Task<IEnumerable<AllArtEventByIdViewModel>> AllArtEventsAsync();

        Task<string> CreateEventAsync(ArtEventFormModel model);
    }
}
