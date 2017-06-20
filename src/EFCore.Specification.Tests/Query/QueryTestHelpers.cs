// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Linq;
using Microsoft.EntityFrameworkCore.TestModels.ComplexNavigationsModel;
using Xunit;

namespace Microsoft.EntityFrameworkCore.Query
{
    public interface IExpectedData
    {
        IQueryable<TEntity> Set<TEntity>() where TEntity : class;
    }

    public interface ICustomSetAccessor<TContext> where TContext : DbContext
    {
        IQueryable<TEntity> Set<TEntity>(TContext context) where TEntity : class;
    }

    public class CustomSetAccessor : ICustomSetAccessor<ComplexNavigationsContext>
    {
        public IQueryable<TEntity> Set<TEntity>(ComplexNavigationsContext context) where TEntity : class
        {
            return null;
        }
    }

    public class QueryTestHelpers<TCotext, TExpectedData>
        where TCotext : DbContext
        where TExpectedData : IExpectedData
    {
        private Func<TCotext> _contextCreator;
        private TExpectedData _expectedData;
        private ICustomSetAccessor<TCotext> _customSetAccessor;

        public QueryTestHelpers(
            Func<TCotext> contextCreator, 
            TExpectedData expectedData, 
            ICustomSetAccessor<TCotext> customSetAccessor = null)
        {
            _contextCreator = contextCreator;
            _expectedData = expectedData;
            _customSetAccessor = customSetAccessor;
        }

        public void AssertQuery<TItem1>(
            Func<IQueryable<TItem1>, IQueryable<object>> query,
            Func<dynamic, object> elementSorter = null,
            Action<dynamic, dynamic> elementAsserter = null,
            bool verifyOrdered = false)
            where TItem1 : class
            => AssertQuery(query, query, elementSorter, elementAsserter, verifyOrdered);

        public void AssertQuery<TItem1>(
            Func<IQueryable<TItem1>, IQueryable<object>> efQuery,
            Func<IQueryable<TItem1>, IQueryable<object>> l2oQuery,
            Func<dynamic, object> elementSorter = null,
            Action<dynamic, dynamic> elementAsserter = null,
            bool verifyOrdered = false)
            where TItem1 : class
        {
            using (var context = _contextCreator())
            {
                var actual = efQuery(_customSetAccessor?.Set<TItem1>(context) ?? context.Set<TItem1>()).ToArray();
                var expected = l2oQuery(_expectedData.Set<TItem1>()).ToArray();

                TestHelpers.AssertResults(
                    expected,
                    actual,
                    elementSorter ?? (e => e),
                    elementAsserter ?? ((e, a) => Assert.Equal(e, a)),
                    verifyOrdered);
            }
        }
    }
}
