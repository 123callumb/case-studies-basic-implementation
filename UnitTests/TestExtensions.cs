using Microsoft.AspNetCore.Mvc;
using MockQueryable.Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests
{
    public static class TestExtensions
    {
        public static IQueryable<T> GetMockQueryable<T>(this IEnumerable<T> collection) where T : class => collection.AsQueryable().BuildMock().Object;
        public static T ExtractValue<T>(this JsonResult jsonRes, string fieldName)
        {
            Type type = jsonRes.Value.GetType();
            var propInfo = type.GetProperty(fieldName);
            T value = (T)propInfo.GetValue(jsonRes.Value);
            return value;
        }
    }
}
