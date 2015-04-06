using MediatR;

namespace Shrew.Web.Infrastructure.SuggestionsBox
{
    public class DetailsQuery : IAsyncRequest<DetailsModel>
    {
        public int Id { get; private set; }
        public DetailsQuery(int id)
        {
            this.Id = id;
        }
    }
}