using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Shrew.Web.Models.Domain;
using Shrew.Web.Resources;

namespace Shrew.Web.Infrastructure.SuggestionsBox
{
    public class DetailsModel
    {
        public int Id { get; set; }
        [Display(ResourceType = typeof(ViewStrings),
            Name = "Name")]
        public string Name { get; set; }
        public List<Suggestion> Suggestions { get; set; }
        [Display(ResourceType = typeof(ViewStrings),
            Name = "CreationDate")]
        public DateTime CreationDate { get; set; }

        [Required]
        [Display(ResourceType = typeof(ViewStrings),
            Name = "NewSuggestion")]
        public string NewSuggestion { get; set; }

    }
}