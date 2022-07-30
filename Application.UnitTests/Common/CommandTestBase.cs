using FinancialManagment.Persistance;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UnitTests.Common
{
    public class CommandTestBase : IDisposable
    {
        protected readonly FinancialDbContext _context;
        protected readonly Mock<FinancialDbContext> _contextMock;
        public CommandTestBase()
        {
            _contextMock = FinancialDbContextFactory.Create();
            _context = _contextMock.Object;
        }
        public void Dispose()
        {
            FinancialDbContextFactory.Destroy(_context);
        }
    }
}
