
namespace ArtStroke.Web.ViewModels.PrintDesign
{
    using ArtStroke.Web.ViewModels.ArtWork;
    using System.ComponentModel.DataAnnotations;

    public class AllPrintDesignsByArtworkIdViewModel
    {
        public string Id { get; set; } = null!;

        public string Title { get; set; } = null!;
        public int Width { get; set; }
        public int Height { get; set; }

        [Display(Name = "Image Link")]
        public string ImageUrl { get; set; } = null!;

        public string CreatorName { get; set; } = null!;

        public bool IsCreatedByCurrentUser { get; set; }
        public Guid? UserId { get; set; }
        public Guid ArtWorkId { get; set; }
        public ArtworkAllViewModel ArtWork { get; set; } = null!;
    }
}
