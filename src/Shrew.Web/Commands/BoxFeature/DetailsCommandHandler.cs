using System;
using System.Threading.Tasks;
using MediatR;
using Shrew.Core.Domain;
using Raven.Client;

namespace Shrew.Web.Infrastructure.SuggestionsBox
{
    public class DetailsCommandHandler : AsyncRequestHandler<DetailsCommand>
    {
        private readonly Func<IAsyncDocumentSession> session;

        public DetailsCommandHandler(Func<IAsyncDocumentSession> session)
        {
            this.session = session;
        }
        protected override async Task HandleCore(DetailsCommand message)
        {
            var box = await session().LoadAsync<Box>(message.Details.Id);
            box.AddSuggestion(message.Details.NewSuggestion);
        }
    }
}