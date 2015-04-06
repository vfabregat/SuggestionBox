
using System.Collections.Generic;
using Shrew.Web.Models.Domain;
namespace Shrew.Web.ViewModels
{
    public class SuggestionBoxIndex
    {
        public string Name { get; set; }
        public IEnumerable<Suggestion> Suggestions { get; set; }

    }
}