using System.ComponentModel.DataAnnotations;
using Shrew.Web.Resources;

namespace Shrew.Web.Models.Box
{
    public class CreateModel
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        [Display(ResourceType = typeof(ViewStrings), Name = "Name")]
        public string Name { get; set; }

        [StringLength(200)]
        [Display(ResourceType = typeof(ViewStrings), Name = "Description")]
        public string Description { get; set; }

        [Display(ResourceType = typeof(ViewStrings), Name = "IsPublished")]
        public bool IsPublished { get; set; }
    }
}