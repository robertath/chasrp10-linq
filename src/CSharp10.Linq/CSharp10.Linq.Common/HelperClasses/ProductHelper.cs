using CSharp10.Linq.DataLayer.EntityClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp10.Linq.Common.HelperClasses
{
    public static class ProductHelper
    {
        #region ByColor
        public static IEnumerable<Product> ByColor(this IEnumerable<Product> query, string color)
        {
            return query.Where(p => p.Color == color);
        }
        #endregion
    }
}
