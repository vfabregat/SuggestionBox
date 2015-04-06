namespace Shrew.Web.Infrastructure
{
    public interface ISession
    {
        MongoDB.Driver.MongoCollection<T> Collection<T>();
    }
}
