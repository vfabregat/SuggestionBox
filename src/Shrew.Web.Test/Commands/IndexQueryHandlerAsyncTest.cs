
using AutoMapper;
using MediatR;
using Shrew.Web.DependencyResolution;
using Shrew.Web.Infrastructure;
using Shrew.Web.Infrastructure.Mapping;
using Shrew.Web.Infrastructure.SuggestionsBox;
using StructureMap;
using Xunit;
namespace Shrew.Web.Test.Commands
{
    public class IndexQueryHandlerAsyncTest
    {
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
