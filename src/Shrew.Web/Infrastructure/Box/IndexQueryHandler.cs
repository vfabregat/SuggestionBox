using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Raven.Client;
using Shrew.Infrastructure.Mapping;
using Shrew.Web.Models.Domain;

namespace Shrew.Web.Infrastructure.SuggestionsBox
{
    public class IndexQueryHandler : IAsyncRequestHandler<IndexQuery, IList<IndexModel>>
    {
        private readonly Func<IAsyncDocumentSession> dbSession;
        public IndexQueryHandler(Func<IAsyncDocumentSession> dbSession)
        {
            this.dbSession = dbSession;
        }

        public async Task<IList<IndexModel>> Handle(IndexQuery message)
        {
            var boxes = await dbSession().Query<Box>().Where(b => b.IsPublished).ToListAsync();
            return boxes.Map().To<IList<IndexModel>>();
        }
    }
}