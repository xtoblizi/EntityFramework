//// Copyright (c) .NET Foundation. All rights reserved.
//// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

//using System;
//using JetBrains.Annotations;
//using System.Linq.Expressions;

//namespace Microsoft.EntityFrameworkCore.Query.Expressions.Internal
//{

//    /// <summary>
//    ///     This API supports the Entity Framework Core infrastructure and is not intended to be used
//    ///     directly from your code. This API may change or be removed in future releases.
//    /// </summary>
//    public class ProjectCollectionNavigationExpression : Expression
//    {
//        /// <summary>
//        ///     This API supports the Entity Framework Core infrastructure and is not intended to be used
//        ///     directly from your code. This API may change or be removed in future releases.
//        /// </summary>
//        public ProjectCollectionNavigationExpression([NotNull] Expression entity, [NotNull] Expression collectionAccessor)
//        {
//            Entity = entity;
//            CollectionAccessor = collectionAccessor;
//        }

//        /// <summary>
//        ///     This API supports the Entity Framework Core infrastructure and is not intended to be used
//        ///     directly from your code. This API may change or be removed in future releases.
//        /// </summary>
//        public Expression Entity { get; }

//        /// <summary>
//        ///     This API supports the Entity Framework Core infrastructure and is not intended to be used
//        ///     directly from your code. This API may change or be removed in future releases.
//        /// </summary>
//        public Expression CollectionAccessor { get; }


//        /// <summary>
//        ///     This API supports the Entity Framework Core infrastructure and is not intended to be used
//        ///     directly from your code. This API may change or be removed in future releases.
//        /// </summary>
//        public override bool CanReduce => true;

//        /// <summary>
//        ///     This API supports the Entity Framework Core infrastructure and is not intended to be used
//        ///     directly from your code. This API may change or be removed in future releases.
//        /// </summary>
//        public override Type Type => CollectionAccessor.Type;

//        /// <summary>
//        ///     This API supports the Entity Framework Core infrastructure and is not intended to be used
//        ///     directly from your code. This API may change or be removed in future releases.
//        /// </summary>
//        public override ExpressionType NodeType => ExpressionType.Extension;

//        /// <summary>
//        ///     This API supports the Entity Framework Core infrastructure and is not intended to be used
//        ///     directly from your code. This API may change or be removed in future releases.
//        /// </summary>
//        public override Expression Reduce()
//        {

//        }
//            => Operand;

//        /// <summary>
//        ///     This API supports the Entity Framework Core infrastructure and is not intended to be used
//        ///     directly from your code. This API may change or be removed in future releases.
//        /// </summary>
//        protected override Expression VisitChildren(ExpressionVisitor visitor)
//            => visitor.Visit(Operand);



//    }
//}
