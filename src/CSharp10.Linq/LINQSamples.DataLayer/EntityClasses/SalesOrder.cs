using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp10.Linq.DataLayer.EntityClasses
{
    public partial class SalesOrder
    {
        public int SalesOrderID { get; set; }
        public short OrderQty { get; set; }
        public int ProductID { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal LineTotal { get; set; }

        #region ToString Override
        public override string ToString()
        {
            StringBuilder sb = new(1024);

            sb.AppendLine($"Order ID: {SalesOrderID}");
            sb.AppendLine($"   Product ID: {ProductID}   Qty: {OrderQty}");
            sb.AppendLine($"   Unit Price: {UnitPrice:c}   Total: {LineTotal:c}");

            return sb.ToString();
        }
        #endregion
    }
}
