using System.Collections.Generic;
using MediatR;

namespace Shrew.Web.Infrastructure.SuggestionsBox
{
    public class IndexQuery : IAsyncRequest<IList<IndexModel>>
    {
    }
}