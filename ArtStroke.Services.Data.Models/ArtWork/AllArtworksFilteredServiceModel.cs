using ArtStroke.Web.ViewModels.ArtWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtStroke.Services.Data.Models.ArtWork
{
    public class AllArtworksFilteredServiceModel
    {
        public AllArtworksFilteredServiceModel()
        {
            this.Artworks = new HashSet<ArtworkAllViewModel>();
        }
        public int CountTotalArtworks { get; set; } 

        public IEnumerable<ArtworkAllViewModel> Artworks { get; set; }
    }
}
