using FluentValidation;
using MediatR;
using StructureMap.Configuration.DSL;

namespace Shrew.Web.Infrastructure
{
    public class CommandProcessingRegistry : Registry
    {
        public CommandProcessingRegistry()
        {
            Scan(scan =>
            {
                scan.AssemblyContainingType<IMediator>();
                scan.AssemblyContainingType<CommandProcessingRegistry>();

                scan.AddAllTypesOf(typeof(IRequestHandler<,>));
                scan.AddAllTypesOf(typeof(IAsyncRequestHandler<,>));
                scan.AddAllTypesOf(typeof(IValidator<>));

                scan.WithDefaultConventions();
            });

            For(typeof(IAsyncRequestHandler<,>)).DecorateAllWith(typeof(UnitOfWorkHandler<,>),
                filter =>
                    filter.ReturnedType.BaseType != null &&
                    filter.ReturnedType.BaseType.IsGenericType &&
                    filter.ReturnedType.BaseType.GetGenericTypeDefinition() == typeof(AsyncRequestHandler<>)
                );
            For<SingleInstanceFactory>().Use<SingleInstanceFactory>(ctx => t => ctx.GetInstance(t));
            For<MultiInstanceFactory>().Use<MultiInstanceFactory>(ctx => t => ctx.GetAllInstances(t));
        }
    }
}