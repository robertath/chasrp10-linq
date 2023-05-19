using CSharp10.Linq.Common;
using CSharp10.Linq.DataLayer.CompositeClasses;
using CSharp10.Linq.DataLayer.EntityClasses;
using CSharp10.Linq.DataLayer.RepositoryClasses;

namespace CSharp10.Linq.GoupedSubQuery;

public class SamplesViewModel : ViewModelBase
{
    #region GroupByQuery
    /// <summary>
    /// Group products by Size property. orderby is optional, but generally used
    /// </summary>
    public List<IGrouping<string, Product>> GroupByQuery()
    {
        List<IGrouping<string, Product>> list = null;
        List<Product> products = ProductRepository.GetAll();

        list = (from prod in products
                orderby prod.Size
                group prod by prod.Size
                ).ToList();

        return list;
    }
    #endregion

    #region GroupByMethod
    /// <summary>
    /// Group products by Size property. orderby is optional, but generally used
    /// </summary>
    public List<IGrouping<string, Product>> GroupByMethod()
    {
        List<IGrouping<string, Product>> list = null;
        // Load all Product Data
        List<Product> products = ProductRepository.GetAll();

        list = products
            .OrderBy( prod => prod.Name )
            .GroupBy( prod => prod.Size )
            .ToList();

        return list;
    }
    #endregion

    #region GroupByIntoQuery
    /// <summary>
    /// Group products by Size property. 'into' is optional.
    /// </summary>
    public List<IGrouping<string, Product>> GroupByIntoQuery()
    {
        List<IGrouping<string, Product>> list = null;
        // Load all Product Data
        List<Product> products = ProductRepository.GetAll();

        list = (from prod in products
                group prod by prod.Size into sizes
                select sizes)
                .ToList();

        return list;
    }
    #endregion

    #region GroupByUsingKeyQuery
    /// <summary>
    /// After selecting 'into' new variable, can sort on the 'Key' property. Key property has the value of what you grouped on.
    /// </summary>
    public List<IGrouping<string, Product>> GroupByUsingKeyQuery()
    {
        List<IGrouping<string, Product>> list = null;
        // Load all Product Data
        List<Product> products = ProductRepository.GetAll();

        list = (from prod in products
                group prod by prod.Size into sizes
                orderby sizes.Key
                select sizes
                )
                .ToList();

        return list;
    }
    #endregion

    #region GroupByUsingKeyMethod
    /// <summary>
    /// After selecting 'into' new variable, can sort on the 'Key' property. Key property has the value of what you grouped on.
    /// </summary>
    public List<IGrouping<string, Product>> GroupByUsingKeyMethod()
    {
        List<IGrouping<string, Product>> list = null;
        // Load all Product Data
        List<Product> products = ProductRepository.GetAll();

        list = products
            .GroupBy(p=> p.Size)
            .OrderBy(size => size.Key)
            .Select(sizes => sizes)
            .ToList();

        return list;
    }
    #endregion

    #region GroupByWhereQuery
    /// <summary>
    /// Group products by Size property and where the group has more than 2 members
    /// This simulates a HAVING clause in SQL
    /// </summary>
    public List<IGrouping<string, Product>> GroupByWhereQuery()
    {
        List<IGrouping<string, Product>> list = null;
        // Load all Product Data
        List<Product> products = ProductRepository.GetAll();

        list = ( from prod in products
                 group prod by prod.Size into sizes
                 where sizes.Count() > 2
                 select sizes)
                 .ToList();

        return list;
    }
    #endregion

    #region GroupByWhereMethod
    /// <summary>
    /// Group products by Size property and where the group has more than 2 members
    /// This simulates a HAVING clause in SQL
    /// </summary>
    public List<IGrouping<string, Product>> GroupByWhereMethod()
    {
        List<IGrouping<string, Product>> list = null;
        // Load all Product Data
        List<Product> products = ProductRepository.GetAll();

        list = products.OrderBy(p=> p.Size)
            .GroupBy(prod => prod.Size)
            .Where(sizes => sizes.Count() > 2)
            .Select(sizes => sizes)            
            .ToList();

        return list;
    }
    #endregion

    #region GroupBySubQueryQuery
    /// <summary>
    /// Group Sales by SalesOrderID, add Products into new Sales Order object using a subquery
    /// </summary>
    public List<SaleProducts> GroupBySubQueryQuery()
    {
        List<SaleProducts> list = null;
        // Load all Product Data
        List<Product> products = ProductRepository.GetAll();
        // Load all Sales Data
        List<SalesOrder> sales = SalesOrderRepository.GetAll();

        list = (from sale in sales
                orderby sale.SalesOrderID
                group sale by sale.SalesOrderID into newSales
                select new SaleProducts
                {
                    SalesOrderID = newSales.Key,
                    Products = (from prod in products
                                orderby prod.ProductID
                                join sale in sales
                                on prod.ProductID equals sale.ProductID
                                where sale.SalesOrderID == newSales.Key
                                select prod)
                                .ToList()
                })
                .ToList();

        return list;
    }
    #endregion

    #region GroupBySubQueryMethod
    /// <summary>
    /// Group Sales by SalesOrderID, add Products into new Sales Order object using a subquery
    /// </summary>
    public List<SaleProducts> GroupBySubQueryMethod()
    {
        List<SaleProducts> list = null;
        // Load all Product Data
        List<Product> products = ProductRepository.GetAll();
        // Load all Sales Data
        List<SalesOrder> sales = SalesOrderRepository.GetAll();

        list = sales
            .OrderBy(sale=> sale.SalesOrderID)
            .GroupBy(sale => sale.SalesOrderID)
            .Select(newSales => new SaleProducts
            {
                SalesOrderID = newSales.Key,
                Products = products
                            .OrderBy(p=> p.ProductID)
                            .Join(newSales, 
                                prod => prod.ProductID,
                                sale => sale.ProductID,
                                (prod, sale) => prod).ToList()                            
            }).ToList();

        return list;
    }
    #endregion

    #region GroupByDistinctQuery
    /// <summary>
    /// The Distinct() operator can be simulated using the GroupBy() and FirstOrDefault() operators
    /// In this sample you put distinct product colors into another collection using LINQ
    /// </summary>
    public List<string> GroupByDistinctQuery()
    {
        List<string> list = null;
        // Load all Product Data
        List<Product> products = ProductRepository.GetAll();

        list = (from prod in products
                orderby prod.Color
                group prod by prod.Color into groupedColors
                select groupedColors.FirstOrDefault().Color)
                .ToList();

        return list;
    }
    #endregion

    #region GroupByDistinctMethod
    /// <summary>
    /// The Distinct() operator can be simulated using the GroupBy() and FirstOrDefault() operators
    /// In this sample you put distinct product colors into another collection using LINQ
    /// </summary>
    public List<string> GroupByDistinctMethod()
    {
        List<string> list = null;
        // Load all Product Data
        List<Product> products = ProductRepository.GetAll();

        list = products
            .GroupBy(p => p.Color)
            .Select(groupedColor => groupedColor.FirstOrDefault().Color)
            .OrderBy(color => color)
            .ToList();


        return list;
    }
    #endregion
}
