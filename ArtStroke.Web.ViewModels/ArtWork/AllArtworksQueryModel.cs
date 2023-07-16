
namespace ArtStroke.Web.ViewModels.ArtWork
{
    using System.ComponentModel.DataAnnotations;
    using ArtStroke.Web.ViewModels.ArtWork.Enums;
    using static Common.GeneralApplicationConstants;
    public class AllArtworksQueryModel
    {
        public AllArtworksQueryModel()
        {
            this.CurrentPage = DefaultPage;
            this.ArtworksPerPage = EntitiesPerPage;
            this.Styles = new HashSet<string>();
            this.Artwoks = new HashSet<ArtworkAllViewModel>();
        }
        public string? Style { get; set; } = null!;

        [Display(Name = ("Search by text"))]
        public string? SearchTerm { get; set; } = null!;

        [Display(Name = ("Sort arts by ..."))]
        public ArtWorkSorting WorksSorting { get; set; }

        public int CurrentPage { get; set; }

        [Display(Name = "Show Artworks On Page")]
        public int ArtworksPerPage { get; set; }

        public int TotalArtworks { get; set; }

        public IEnumerable<string> Styles { get; set; } = null!;
        public IEnumerable<ArtworkAllViewModel> Artwoks { get; set; } = null!;
    }
}
