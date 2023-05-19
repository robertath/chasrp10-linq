using CSharp10.Linq.Common;
using CSharp10.Linq.Common.ComparerClasses;
using CSharp10.Linq.DataLayer.EntityClasses;

namespace CSharp10.Linq.Contained;

public class SamplesViewModel : ViewModelBase
{
    #region AllQuery
    /// <summary>
    /// Use All() to see if all items in a collection meet a specified condition 
    /// </summary>
    /// <returns>bool</returns>
    public bool AllQuery()
    {
        List<Product> products = GetProducts();

        return (from prod in products
                select prod)
                .All(prod => prod.ListPrice > prod.StandardCost);
    }
    #endregion AllQuery

    #region AllMethod
    /// <summary>
    /// Use All() to see if all items in a collection meet a specified condition
    /// </summary>
    /// <returns>bool</returns>
    public bool AllMethod()
    {
        List<Product> products = GetProducts();

        return products.All(prod => prod.ListPrice > prod.StandardCost);
    }
    #endregion AllMethod

    #region AllSalesQuery
    /// <summary>
    /// Use All() to see if all items in a collection meet a specified condition 
    /// </summary>
    /// <returns>bool</returns>
    public bool AllSalesQuery()
    {
        List<SalesOrder> sales = GetSales();

        return (from sale in sales
                select sale)
                .All(sale => sale.OrderQty >= 1);
    }
    #endregion AllSalesQuery

    #region AllSalesMethod
    /// <summary>
    /// Use All() to see if all items in a collection meet a specified condition
    /// </summary>
    /// <returns>bool</returns>
    public bool AllSalesMethod()
    {
        List<SalesOrder> sales = GetSales();

        return sales.All(sale => sale.OrderQty >= 1);
    }
    #endregion AllSalesMethod

    #region AnyQuery
    /// <summary>
    /// Use Any() to see if at least one item in a collection meets a specified condition
    /// </summary>
    /// <returns>bool</returns>
    public bool AnyQuery()
    {
        List<SalesOrder> sales = GetSales();

        return (from sale in sales
                select sale)
                .Any(sale => sale.LineTotal > 10000);
    }
    #endregion AnyQuery

    #region AnyMethod
    /// <summary>
    /// Use Any() to see if at least one item in a collection meets a specified condition
    /// </summary>
    /// <returns>bool</returns>
    public bool AnyMethod()
    {
        List<SalesOrder> sales = GetSales();

        return sales.Any(sale => sale.LineTotal > 10000);
    }
    #endregion AnyMethod

    #region ContainsQuery
    /// <summary>
    /// Use the Contains() operator to see if a collection contains a specified value
    /// </summary>
    /// <returns>bool</returns>
    public bool ContainsQuery()
    {
        List<int> numbers = new() { 1, 2, 3, 4, 5 };

        return (from num in numbers
                select num)
                .Contains(3);
    }
    #endregion ContainsQuery

    #region ContainsMethod
    /// <summary>
    /// Use the Contains() operator to see if a collection contains a specified value
    /// </summary>
    /// <returns>bool</returns>
    public bool ContainsMethod()
    {
        List<int> numbers = new() { 1, 2, 3, 4, 5 };

        return numbers.Contains(3);
    }
    #endregion ContainsMethod

    #region ContainsCompareQuery
    /// <summary>
    /// Use the Contains() operator to see if a collection contains a specified value
    /// When comparing classes, you need to write a EqualityComparer classe
    /// </summary>
    /// <returns>bool</returns>
    public bool ContainsCompareQuery()
    {
        List<Product> products = GetProducts();
        ProductIdComparer pc = new();
        bool value;

        return (from prod in products
                select prod)
                .Contains(new Product { ProductID = 744 }, pc);
    }
    #endregion ContainsCompareQuery

    #region ContainsCompareMethod
    /// <summary>
    /// Use the Contains() operator to see if a collection contains a specified value
    /// When comparing classes, you need to write a EqualityComparer classe
    /// </summary>
    /// <returns>bool</returns>
    public bool ContainsCompareMethod()
    {
        List <Product> products = GetProducts();
        ProductIdComparer pc = new();
        
        return products.Contains(new Product { ProductID = 744 }, pc);
    }
    #endregion ContainsCompareMethod
}