using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtStroke.Web.ViewModels.Artist;

namespace ArtStroke.Web.ViewModels.ArtWork
{
    public class ArtworkDetailsViewModel : ArtworkAllViewModel
    {

        public string Technique { get; set; } = null!;

        [Display(Name = "Width on desighed artwork")]
        public int Width { get; set; }


        [Display(Name = "Height on desighed artwork")]
        public int Height { get; set; }

        [Display(Name = "Year on creating of artwork")]
        public string CreatingYear { get; set; } = null!; 

        public ArtistInfoOnArtworkViewModel Artist { get; set; } = null!;
    }
}
