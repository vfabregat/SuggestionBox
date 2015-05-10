using System;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;

/* Unmerged change from project 'Shrew.Web.DNX Core 5.0'
Before:
using Raven.Client;
using Shrew.Web.Models.Domain;
using Shrew.Core.Domain;
After:
using Shrew.Core.Domain;
*/
using Raven.Client;
using Shrew.Core.Domain;

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