using MediatR;

namespace Shrew.Web.Infrastructure.SuggestionsBox
{
    public class DetailsCommand : IAsyncRequest
    {
        public DetailsModel Details { get; private set; }
        public DetailsCommand(DetailsModel details)
        {
            this.Details = details;
        }
    }
}