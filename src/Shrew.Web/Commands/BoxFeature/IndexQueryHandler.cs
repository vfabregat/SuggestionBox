using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Shrew.Web.Models;

namespace Shrew.Web.Infrastructure.SuggestionsBox
{
    public class IndexQueryHandler : IAsyncRequestHandler<IndexQuery, IList<IndexModel>>
    {
        private readonly Func<ApplicationDbContext> dbSession;
        public IndexQueryHandler(Func<ApplicationDbContext> dbSession)
        {
            this.dbSession = dbSession;
        }

        public async Task<IList<IndexModel>> Handle(IndexQuery message)
        {
            //var boxes = await dbSession().Query<Box>().Where(b => b.IsPublished).ToListAsync();

            var boxes = await dbSession().Boxes.Where(b => b.IsPublished).ToListAsync();
            return null; // boxes.Map().To<IList<IndexModel>>();
        }
    }
}