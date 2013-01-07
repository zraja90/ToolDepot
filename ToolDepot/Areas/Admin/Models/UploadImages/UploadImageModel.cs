using System.ComponentModel.DataAnnotations;
using System.Web;

namespace ToolDepot.Areas.Admin.Models.UploadImages
{
    public class UploadImageModel
    {
        public string Name { get; set; }
        public string FileSize { get; set; }
        public string ImageUrl { get; set; }
    }
}