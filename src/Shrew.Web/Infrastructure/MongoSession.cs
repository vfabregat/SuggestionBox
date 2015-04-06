using System.Configuration;
using Humanizer;
using MongoDB.Driver;

namespace Shrew.Web.Infrastructure
{
    public class Session : ISession
    {
        MongoClient client;
        MongoDatabase database;
        readonly string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        readonly string databaseName = ConfigurationManager.AppSettings["DatabaseName"];


        public Session()
        {
            client = new MongoClient(connectionString);
            database = client.GetServer().GetDatabase(databaseName);
            //database = clientclient.GetServer().GetDatabase(databaseName);
        }

        private string GetCollectionName<T>()
        {
            return typeof(T).Name.Pluralize();
        }

        public MongoCollection<T> Collection<T>()
        {
            return database.GetCollection<T>(GetCollectionName<T>());
        }
    }
}