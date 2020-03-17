﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.TestModels.ManyToManyModel;
using Xunit;

namespace Microsoft.EntityFrameworkCore.Query
{
    public abstract class ManyToManyQueryTestBase<TFixture> : QueryTestBase<TFixture>
        where TFixture : ManyToManyQueryFixtureBase, new()
    {
        public ManyToManyQueryTestBase(TFixture fixture)
            : base(fixture)
        {
        }

        [ConditionalTheory]
        [MemberData(nameof(IsAsyncData))]
        public virtual Task Dummy_test_remove_later(bool async)
        {
            return AssertQuery(
                async,
                ss => ss.Set<EntityOne>().Where(e => e.Id > 1));
        }

        protected ManyToManyContext CreateContext() => Fixture.CreateContext();

        protected virtual void ClearLog()
        {
        }
    }
}
