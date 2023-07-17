using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtStroke.Web.ViewModels.PrintDesigns
{
    public class AllPrintDesignsViewModel
    {
        public string Id { get; set; } = null!;

        public int Width { get; set; }
        public int Height { get; set; }

        public string CreatorName { get; set; } = null!;

        public Guid? UserId { get; set; }
        public Guid ArtWorkId { get; set; }
    }
}
