
using Xunit;
using Shrew.Web.Infrastructure.SuggestionsBox;
using Shrew.Web.Infrastructure;
using MediatR;
using AutoMapper;
using StructureMap;
using Shrew.Infrastructure.Mapping;
using Shrew.Web.DependencyResolution;
using Shrew.Web.Infrastructure.Mapping;
namespace Shrew.Web.Test.Commands
{
    public class IndexQueryHandlerAsyncTest
    {
        [Fact]
        public void IndexQueryHandlerShouldNotReturnUnPublishBoxes()
        {
            var queryHandler = new IndexQueryHandler(null);

            Assert.NotNull(queryHandler);
        }

        [Fact]
        public async void IndexQueryHandlerShouldReturnResults()
        {
            IContainer container = IoC.Initialize();
            var registry = new CommandProcessingRegistry();
            Mapper.AddProfile(new MappingProfile());

            var mediatr = container.GetInstance<IMediator>();

            var result = await mediatr.SendAsync(new IndexQuery());
            Assert.NotNull(result);
        }
    }
}
