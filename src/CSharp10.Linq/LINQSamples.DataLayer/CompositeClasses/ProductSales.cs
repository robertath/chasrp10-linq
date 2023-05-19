using CSharp10.Linq.DataLayer.EntityClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp10.Linq.DataLayer.CompositeClasses
{
    public partial class ProductSales
    {
        public Product Product { get; set; }
        public List<SalesOrder> Sales { get; set; }
    }
}
