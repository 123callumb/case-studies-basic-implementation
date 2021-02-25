using MockQueryable.Moq;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests
{
    public static class TestExtensions
    {
        public static IQueryable<T> GetMockQueryable<T>(this IEnumerable<T> collection) where T : class => collection.AsQueryable().BuildMock().Object;
    }
}
