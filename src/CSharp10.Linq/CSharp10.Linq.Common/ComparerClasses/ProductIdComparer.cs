using CSharp10.Linq.DataLayer.EntityClasses;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp10.Linq.Common.ComparerClasses
{
    public class ProductIdComparer : EqualityComparer<Product>
    {
        public override bool Equals(Product? x, Product? y)
        {
            return (x.ProductID == y.ProductID);
        }

        public override int GetHashCode([DisallowNull] Product obj)
        {
            return obj.ProductID.GetHashCode();
        }
    }
}
