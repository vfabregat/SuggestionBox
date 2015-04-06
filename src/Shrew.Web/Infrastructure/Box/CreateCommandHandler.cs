using System;
using System.Threading.Tasks;
using MediatR;
using Raven.Client;
using Shrew.Web.Models.Domain;

namespace Shrew.Web.Infrastructure.SuggestionsBox
{
    public class CreateCommandHandler : AsyncRequestHandler<CreateCommand>
    {
        private readonly Func<IAsyncDocumentSession> ravensession;
        public CreateCommandHandler(Func<IAsyncDocumentSession> ravensession)
        {
            this.ravensession = ravensession;
        }
        protected override Task HandleCore(CreateCommand message)
        {
            return ravensession().StoreAsync(new Box(message.Details.Name, message.Details.Description, message.Details.IsPublished));
        }
    }
}