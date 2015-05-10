using MediatR;
using Shrew.Web.Models.Box;

namespace Shrew.Web.Infrastructure.SuggestionsBox
{
    public class CreateCommand : IAsyncRequest
    {
        public CreateModel Details { get; private set; }
        public CreateCommand(CreateModel details)
        {
            this.Details = details;
        }
    }
}