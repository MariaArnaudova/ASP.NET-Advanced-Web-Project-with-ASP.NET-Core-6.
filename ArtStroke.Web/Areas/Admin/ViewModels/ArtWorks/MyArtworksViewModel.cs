
namespace ArtStroke.Web.Areas.Admin.ViewModels.ArtWorks
{
    using ArtStroke.Web.ViewModels.ArtWork;
    public class MyArtworksViewModel
    {
        public IEnumerable<ArtworkAllViewModel> AddedArtworks { get; set; } = null!;
    }
}
