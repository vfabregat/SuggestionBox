
using MediatR;
using Shrew.Web.DependencyResolution;
using Shrew.Web.Infrastructure;
using Shrew.Web.Infrastructure.SuggestionsBox;
using StructureMap;
using Xunit;
namespace Shrew.Web.Test.Commands
{
    public class UnitOfWorkHandlerTest
    {
        [Fact]
        public void RequestHandlerShouldBeDecorated()
        {
            IContainer container = IoC.Initialize();
            var registry = new CommandProcessingRegistry();
            var requestsHandlers = container.GetInstance<IAsyncRequestHandler<DetailsCommand, Unit>>();

            var result = requestsHandlers.Handle(new DetailsCommand(new DetailsModel()));
            Assert.NotNull(requestsHandlers);
        }
    }
}
