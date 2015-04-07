using AutoMapper;
using AutoMapper.Mappers;
using Shrew.Web.Infrastructure.Mapping;

namespace Shrew.Web.Test
{
    public class AutoMapperConfiguration
    {
        private readonly object LockObject = new object();
        private volatile bool _isMappinginitialized;
        private MappingEngine _mappingEngine;

        private void Configure()
        {
            var configStore = new ConfigurationStore(new TypeMapFactory(), MapperRegistry.Mappers);

            configStore.AddProfile(new MappingProfile());
            _mappingEngine = new MappingEngine(configStore);

            _isMappinginitialized = true;
        }
        public void InitializeMapping()
        {
            if (!_isMappinginitialized)
            {
                lock (LockObject)
                {
                    if (!_isMappinginitialized)
                    {
                        Configure();
                    }
                }
            }
        }
        public void SelfTest()
        {
            InitializeMapping();
            _mappingEngine.ConfigurationProvider.AssertConfigurationIsValid();
        }
        public TEntity Map<TSource, TEntity>(TSource source)
            where TEntity : class
            where TSource : class
        {
            InitializeMapping();

            return _mappingEngine.Map<TSource, TEntity>(source);
        }
    }
}
