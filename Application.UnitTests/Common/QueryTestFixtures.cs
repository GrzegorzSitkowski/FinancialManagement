using AutoMapper;
using FinancialManagment.Application.Common.Mappings;
using FinancialManagment.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Common
{
    public class QueryTestFixtures : IDisposable
    {
        public FinancialDbContext Context { get; private set; }
        public IMapper Mapper { get; private set; }

        public QueryTestFixtures()
        {
            Context = FinancialDbContextFactory.Create().Object;

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            Mapper = configurationProvider.CreateMapper();
        }
        public void Dispose()
        {
            FinancialDbContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixtures> { }
}
