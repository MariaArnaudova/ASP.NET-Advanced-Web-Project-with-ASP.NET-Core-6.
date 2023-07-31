
namespace ArtStroke.Web.ViewModels.PrintDesign
{
    public class PrintDesignDetailsViewModel
    {
        public string Id { get; set; } = null!;
        public string Title { get; set; } = null!;

        public int Width { get; set; }

        public int Height { get; set; }

        public string CreatorName { get; set; } = null!;

        public string? Description { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public string ArtWorkId { get; set; } = null!;

    }
}
