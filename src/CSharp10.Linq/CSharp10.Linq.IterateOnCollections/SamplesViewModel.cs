

using CSharp10.Linq.Common;
using CSharp10.Linq.DataLayer.EntityClasses;
using CSharp10.Linq.DataLayer.RepositoryClasses;

namespace CSharp10.Linq.IterateOnCollections;

public class SamplesViewModel : ViewModelBase
{
    #region ForEachQuery
    /// <summary>
    /// ForEach allows you to iterate over a collection to perform assignments within each object.
    /// Assign the LineTotal from the OrderQty * UnitPrice
    /// When using the Query syntax, assign the result to a temporary variable.
    /// </summary>
    public List<SalesOrder> ForEachQuery()
    {
        // Get all Sales Data
        List<SalesOrder> sales = SalesOrderRepository.GetAll();

        sales = (from sale in sales 
                 let tmp = sale.LineTotal = sale.OrderQty * sale.UnitPrice
                 select sale)
                 .ToList();
                

        return sales;
    }
    #endregion

    #region ForEachMethod
    /// <summary>
    /// ForEach allows you to iterate over a collection to perform assignments within each object.
    /// Assign the LineTotal from the OrderQty * UnitPrice
    /// </summary>
    public List<SalesOrder> ForEachMethod()
    {
        // Get all Sales Data
        List<SalesOrder> sales = SalesOrderRepository.GetAll();

        sales.ForEach(sale => sale.LineTotal = sale.UnitPrice * sale.OrderQty);

        return sales;
    }
    #endregion

    #region ForEachSubQueryQuery
    /// <summary>
    /// Iterate over each object in the collection and call a sub query to calculate total sales
    /// </summary>
    public List<Product> ForEachSubQueryQuery()
    {
        // Get all Product Data
        List<Product> products = ProductRepository.GetAll();
        // Get all Sales Data
        List<SalesOrder> sales = SalesOrderRepository.GetAll();

        // Write Query Syntax Here
        products = (from prod in products
                    let tmp = prod.TotalSales = sales.Where(sale=> sale.ProductID == prod.ProductID).Sum(sale=> sale.LineTotal)
                    select prod)
                    .ToList();

        return products;
    }
    #endregion

    #region ForEachSubQueryMethod
    /// <summary>
    /// Iterate over each object in the collection and call a sub query to calculate total sales
    /// </summary>
    public List<Product> ForEachSubQueryMethod()
    {
        // Get all Product Data
        List<Product> products = ProductRepository.GetAll();
        // Get all Sales Data
        List<SalesOrder> sales = SalesOrderRepository.GetAll();

        products.ForEach(prod => prod.TotalSales = sales
                                                    .Where(sale => sale.ProductID == prod.ProductID)
                                                    .Sum(sale => sale.LineTotal));

        return products;
    }
    #endregion

    #region ForEachQueryCallingMethodQuery
    /// <summary>
    /// Iterate over each object in the collection and call a method to set a property.
    /// This method passes in each Product object into the SalesForProduct() method.
    /// In the CalculateTotalSalesForProduct() method, the total sales for each Product is calculated.
    /// The total is placed into each Product objects' TotalSales property.
    /// </summary>
    public List<Product> ForEachQueryCallingMethodQuery()
    {
        // Get all Product Data
        List<Product> products = ProductRepository.GetAll();
        // Get all Sales Data
        List<SalesOrder> sales = SalesOrderRepository.GetAll();

        // Write Query Syntax Here

        var list = (from prod in products
                   let tmp = prod.TotalSales = CalculateTotalSalesForProduct(prod, sales)
                   select prod);

        list = list.Where(prod => prod.TotalSales > 0);

        return list.ToList();
    }
    #endregion

    #region CalculateTotalSalesForProduct Method
    /// <summary>
    /// Helper method called by LINQ to sum sales for a product
    /// </summary>
    /// <param name="prod">A product</param>
    /// <returns>Total Sales for Product</returns>
    private decimal CalculateTotalSalesForProduct(Product prod, List<SalesOrder> sales)
    {
        return sales.Where(sale => sale.ProductID == prod.ProductID)
                    .Sum(sale => sale.LineTotal);
    }
    #endregion

    #region ForEachQueryCallingMethod
    /// <summary>
    /// Iterate over each object in the collection and call a method to set a property.
    /// This method passes in each Product object into the SalesForProduct() method.
    /// In the CalculateTotalSalesForProduct() method, the total sales for each Product is calculated.
    /// The total is placed into each Product objects' TotalSales property.
    /// </summary>
    public List<Product> ForEachQueryCallingMethod()
    {
        // Get all Product Data
        List<Product> products = ProductRepository.GetAll();
        // Get all Sales Data
        List<SalesOrder> sales = SalesOrderRepository.GetAll();

        products.ForEach(prod => prod.TotalSales = CalculateTotalSalesForProduct(prod, sales));

        return products;
    }
    #endregion







    #region Extra Example
    public List<Product> ForEachQueryCalculateNameLength()
    {
        List<Product> products = GetProducts();
        List<Product> list;

        // Write Query Syntax Here
        list = (from prod in products
                let tmp = prod.NameLength = prod.Name.Length
                select prod).ToList();

        return list;
    }
    #endregion
}
