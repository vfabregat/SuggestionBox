using System;
using System.Threading.Tasks;
using MediatR;
using Raven.Client;

namespace Shrew.Web.Infrastructure
{
    public class UnitOfWorkHandler<TRequest, TResponse> : IAsyncRequestHandler<TRequest, TResponse>
            where TRequest : IAsyncRequest<TResponse>
    {
        private readonly Func<IAsyncDocumentSession> documentSession;
        IAsyncRequestHandler<TRequest, TResponse> inner;
        public UnitOfWorkHandler(IAsyncRequestHandler<TRequest, TResponse> inner, Func<IAsyncDocumentSession> documentSession)
        {
            this.documentSession = documentSession;
            this.inner = inner;
        }

        public async Task<TResponse> Handle(TRequest message)
        {
            var result = await inner.Handle(message);
            await documentSession().SaveChangesAsync();
            return result;
        }
    }
}