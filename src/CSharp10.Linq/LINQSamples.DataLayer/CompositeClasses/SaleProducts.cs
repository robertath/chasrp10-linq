using CSharp10.Linq.DataLayer.EntityClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp10.Linq.DataLayer.CompositeClasses
{
    public class SaleProducts
    {
        public int SalesOrderID { get; set; }
        public List<Product> Products { get; set; }
    }
}

