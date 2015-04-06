using System.ComponentModel.DataAnnotations;
using Shrew.Web.Resources;
namespace Shrew.Web.Infrastructure.SuggestionsBox
{
    public class IndexModel
    {
        public int Id { get; set; }

        [Display(ResourceType = typeof(ViewStrings), Name = "Name")]
        public string Name { get; set; }
        public string NameSlug { get; set; }

        [Display(ResourceType = typeof(ViewStrings), Name = "Description")]
        public string Description { get; set; }

        [Display(ResourceType = typeof(ViewStrings), Name = "Suggestions")]
        public int Suggestions { get; set; }

        [Display(ResourceType = typeof(ViewStrings), Name = "CreationDate")]
        public string CreationDate { get; set; }

        [Display(ResourceType = typeof(ViewStrings), Name = "Owner")]
        public string Owner { get; set; }
    }
}