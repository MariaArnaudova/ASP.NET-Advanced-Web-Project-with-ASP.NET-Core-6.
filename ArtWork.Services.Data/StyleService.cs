using ArtStroke.Data;
using ArtStroke.Services.Data.Interfaces;
using ArtStroke.Web.ViewModels.Styles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtStroke.Services.Data
{
    public class StyleService : IStyleService
    {
        private readonly ArtStrokeDbContext dbContext;
        public StyleService( ArtStrokeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Task<IEnumerable<ArtWorkStyleViewModel>> AllStylesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
