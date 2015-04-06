using System;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Raven.Client;
using Shrew.Web.Models.Domain;

namespace Shrew.Web.Infrastructure.SuggestionsBox
{
    public class DetailsQueryHandler : IAsyncRequestHandler<DetailsQuery, DetailsModel>
    {

        private readonly Func<IAsyncDocumentSession> session;

        public DetailsQueryHandler(Func<IAsyncDocumentSession> session)
        {
            this.session = session;
        }
        public async Task<DetailsModel> Handle(DetailsQuery message)
        {
            var box = await session()
                .LoadAsync<Box>(message.Id);

            return Mapper.Map<DetailsModel>(box);
        }
    }
}