using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtStroke.Web.ViewModels.Artist
{
    public class ArtistInfoOnArtworkViewModel
    {
        public string FullName { get; set; } = null!;

        [Display(Name="Author name of original")]
        public string Name { get; set; } = null!;
        public string Biography { get; set; } = null!;
    }
}
