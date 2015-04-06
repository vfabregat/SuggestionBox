using System;
using System.Collections.Generic;
using System.Threading;
using LiteGuard;
using Raven.Imports.Newtonsoft.Json;
using Shrew.Web.Models.Exceptions;

namespace Shrew.Web.Models.Domain
{
    public class Box
    {
        public string Id { get; set; }
        public string Name { get; private set; }

        public string Description { get; private set; }
        public bool IsPublished { get; private set; }

        [JsonProperty(PropertyName = "Suggestions")]
        private List<Suggestion> suggestions { get; set; }

        public DateTime CreationDate { get; private set; }
        [JsonIgnore]
        public IEnumerable<Suggestion> Suggestions { get { return suggestions; } }

        public string Owner { get; set; }

        public Box(string name, string description, bool isPublished)
            : this(name)
        {
            this.IsPublished = isPublished;
            this.Description = description;
        }
        private Box(string name)
        {
            Guard.AgainstNullArgument("name", name);
            this.Name = name;
            this.CreationDate = DateTime.Now;

            Owner = string.IsNullOrEmpty(Thread.CurrentPrincipal.Identity.Name) ? "Anonimous" : Thread.CurrentPrincipal.Identity.Name;
        }

        public void ChangeDescription(string description)
        {
            this.Description = description;
        }
        public void AddSuggestion(string body)
        {
            if (!IsPublished) throw new SuggestionException("You cannot add suggestions to box not published");
            if (suggestions == null) suggestions = new List<Suggestion>();

            suggestions.Add(new Suggestion(body));
        }

        public void Publish()
        {
            this.IsPublished = true;
        }
    }
}