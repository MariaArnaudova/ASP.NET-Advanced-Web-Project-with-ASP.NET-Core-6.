namespace ArtStroke.Web.ViewModels.PrintDesign
{
    using System.ComponentModel.DataAnnotations;
    public class PrintDeleteViewModel
    {
        public string Id { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;

        [Display(Name = "Creator name")]
        public string Creator { get; set; } = null!;
    }
}
