using CSharp10.Linq.Common;
using CSharp10.Linq.Common.ComparerClasses;
using CSharp10.Linq.DataLayer.EntityClasses;
using CSharp10.Linq.DataLayer.RepositoryClasses;
using System.Collections.Generic;

namespace CSharp10.Linq.DifferenceTwoCollections;

public class SamplesViewModel : ViewModelBase
{
    #region SequenceEqualIntegersQuery
    /// <summary>
    /// SequenceEqual() compares two different collections to see if they are equal
    /// When using simple data types such as int, string, a direct comparison between values is performed
    /// </summary>
    public bool SequenceEqualIntegersQuery()
    {
        List<int> list1 = new() { 5, 2, 3, 4, 5 };
        List<int> list2 = new() { 1, 2, 3, 4, 5 };

        return (from num in list1
                select num)
                .SequenceEqual(list2);
    }
    #endregion

    #region SequenceEqualIntegersMethod
    /// <summary>
    /// SequenceEqual() compares two different collections to see if they are equal
    /// When using simple data types such as int, string, a direct comparison between values is performed
    /// </summary>
    public bool SequenceEqualIntegersMethod()
    {
        List<int> list1 = new() { 5, 2, 3, 4, 5 };
        List<int> list2 = new() { 1, 2, 3, 4, 5 };

        return list1.SequenceEqual(list2);
    }
    #endregion

    #region SequenceEqualObjectsQuery
    /// <summary>
    /// When using a collection of objects, SequenceEqual() performs a comparison to see if the two object references point to the same object
    /// </summary>
    public bool SequenceEqualObjectsQuery()
    {
        List<Product> list1 = new()
      {
        new Product { ProductID = 1, Name = "Product 1" },
        new Product { ProductID = 2, Name = "Product 2" },
      };
        List<Product> list2 = new()
      {
        new Product { ProductID = 1, Name = "Product 1" },
        new Product { ProductID = 2, Name = "Product 2" },
      };

        return (from prod in list1
                select prod)
                .SequenceEqual(list2);
    }
    #endregion

    #region SequenceEqualObjectsMethod
    /// <summary>
    /// When using a collection of objects, SequenceEqual() performs a comparison to see if the two object references point to the same object
    /// </summary>
    public bool SequenceEqualObjectsMethod()
    {
        List<Product> list1 = new()
      {
        new Product { ProductID = 1, Name = "Product 1" },
        new Product { ProductID = 2, Name = "Product 2" },
      };
        List<Product> list2 = new()
      {
        new Product { ProductID = 1, Name = "Product 1" },
        new Product { ProductID = 2, Name = "Product 2" },
      };

        return list1.SequenceEqual(list2);
    }
    #endregion

    #region SequenceEqualUsingComparerQuery
    /// <summary>
    /// Use an EqualityComparer class to determine if the objects are the same based on the values in properties
    /// </summary>
    public bool SequenceEqualUsingComparerQuery()
    {
        ProductComparer pc = new ProductComparer();
        List<Product> list1 = ProductRepository.GetAll();
        List<Product> list2 = ProductRepository.GetAll();

        // Remove an element from 'list1' to make the collections different
        list1.RemoveAt(0);

        return (from prod in list1
                select prod)
                .SequenceEqual(list2, pc);
    }
    #endregion

    #region SequenceEqualUsingComparerMethod
    /// <summary>
    /// Use an EqualityComparer class to determine if the objects are the same based on the values in properties
    /// </summary>
    public bool SequenceEqualUsingComparerMethod()
    {
        ProductComparer pc = new ProductComparer();
        List<Product> list1 = ProductRepository.GetAll();
        List<Product> list2 = ProductRepository.GetAll();

        // Remove an element from 'list1' to make the collections different
        //list1.RemoveAt(0);

        return list1.SequenceEqual(list2, pc);
    }
    #endregion

    #region ExceptIntegersQuery
    /// <summary>
    /// Find all values in one list that are not in the other list
    /// </summary>
    public List<int> ExceptIntegersQuery()
    {
        List<int> list1 = new() { 5, 2, 3, 4, 5 };
        List<int> list2 = new() { 3, 4, 5 };

        return (from prod in list1
                select prod)
                .Except(list2)
                .ToList();
    }
    #endregion

    #region ExceptIntegersMethod
    /// <summary>
    /// Find all values in one list that are not in the other list
    /// </summary>
    public List<int> ExceptIntegersMethod()
    {
        List<int> list1 = new() { 5, 2, 3, 4, 5 };
        List<int> list2 = new() { 3, 4, 5 };

        return list1.Except(list2).ToList();
    }
    #endregion

    #region ExceptProductSalesQuery
    /// <summary>
    /// Find all products that do not have sales
    /// </summary>
    public List<int> ExceptProductSalesQuery()
    {
        List<int> list = null;
        List<Product> products = ProductRepository.GetAll();
        List<SalesOrder> sales = SalesOrderRepository.GetAll();

        list = (from prod in products
                select prod.ProductID)
                .Except(from sale in sales
                        select sale.ProductID)
                .ToList();


        return list;
    }
    #endregion

    #region ExceptProductSalesMethod
    /// <summary>
    /// Find all products that do not have sales
    /// </summary>
    public List<int> ExceptProductSalesMethod()
    {
        List<Product> products = ProductRepository.GetAll();
        List<SalesOrder> sales = SalesOrderRepository.GetAll();

        return products.Select(prod => prod.ProductID)
                        .Except(sales.Select(sale => sale.ProductID))
                        .ToList();
    }
    #endregion

    #region ExceptUsingComparerQuery
    /// <summary>
    /// Find all products that are in one list but not the other using a comparer class
    /// </summary>
    public List<Product> ExceptUsingComparerQuery()
    {
        List<Product> list = null;
        ProductComparer pc = new();
        List<Product> list1 = ProductRepository.GetAll();
        List<Product> list2 = ProductRepository.GetAll();

        // Remove all products with color = "Black" from 'list2'
        // to give us a difference in the two lists
        list2.RemoveAll(prod => prod.Color == "Black");

        return (from prod in list1
                select prod)
                .Except(list2, pc)
                .ToList();
    }
    #endregion

    #region ExceptUsingComparerMethod
    /// <summary>
    /// Find all products that are in one list but not the other using a comparer class
    /// </summary>
    public List<Product> ExceptUsingComparerMethod()
    {
        ProductComparer pc = new();
        List<Product> list1 = ProductRepository.GetAll();
        List<Product> list2 = ProductRepository.GetAll();

        // Remove all products with color = "Black" from 'list2'
        // to give us a difference in the two lists
        list2.RemoveAll(prod => prod.Color == "Black");

        return list1.Except(list2, pc).ToList();
    }
    #endregion

    #region ExceptByQuery
    /// <summary>
    /// ExceptBy() finds products within a collection that DO NOT compare to a List<string> against a specified property in the collection.
    /// The default comparer for ExceptBy() is 'string'
    /// </summary>
    public List<Product> ExceptByQuery()
    {
        List<Product> products = ProductRepository.GetAll();

        List<string> colors = new() { "Red", "Black" };

        return (from prod in products
                select prod)
                .ExceptBy(colors, prod => prod.Color)
                .ToList();
    }
    #endregion

    #region ExceptByMethod
    /// <summary>
    /// ExceptBy() finds products within a collection that DO NOT compare to a List<string> against a specified property in the collection.
    /// The default comparer for ExceptBy() is 'string'
    /// </summary>
    public List<Product> ExceptByMethod()
    {
        List<Product> products = ProductRepository.GetAll();

        List<string> colors = new() { "Red", "Black" };

        return products
            .ExceptBy(colors, prod => prod.Color)
            .ToList();
    }
    #endregion

    #region ExceptByProductSalesQuery
    /// <summary>
    /// Find all products that do not have sales
    /// Change the default comparer for ExceptBy()
    /// </summary>
    public List<Product> ExceptByProductSalesQuery()
    {
        List<Product> products = ProductRepository.GetAll();
        List<SalesOrder> sales = SalesOrderRepository.GetAll();

        return (from prod in products
                select prod)
                .ExceptBy<Product, int>
                (from sale in sales
                 select sale.ProductID, prod => prod.ProductID)
                .ToList();
    }
    #endregion

    #region ExceptByProductSalesMethod
    /// <summary>
    /// Find all products that do not have sales
    /// Change the default comparer for ExceptBy()
    /// </summary>
    public List<Product> ExceptByProductSalesMethod()
    {
        List<Product> products = ProductRepository.GetAll();
        List<SalesOrder> sales = SalesOrderRepository.GetAll();

        return products
            .ExceptBy<Product, int>
                (sales.Select(sale => sale.ProductID), sale => sale.ProductID)
            .ToList();
    }
    #endregion

    #region IntersectIntegersQuery
    /// <summary>
    /// Intersect() finds all values in one list that are also in the other list
    /// </summary>
    public List<int> IntersectIntegersQuery()
    {
        List<int> list1 = new() { 5, 2, 3, 4, 5 };
        List<int> list2 = new() { 3, 4, 5 };

        return (from number in list1
                select number)
                .Intersect(list2)
                .ToList();
    }
    #endregion

    #region IntersectIntegersMethod
    /// <summary>
    /// Intersect() finds all values in one list that are also in the other list
    /// </summary>
    public List<int> IntersectIntegersMethod()
    {
        List<int> list1 = new() { 5, 2, 3, 4, 5 };
        List<int> list2 = new() { 3, 4, 5 };

        return list1.Intersect(list2).ToList();
    }
    #endregion

    #region IntersectProductSalesQuery
    /// <summary>
    /// Find all products that have sales
    /// </summary>
    public List<int> IntersectProductSalesQuery()
    {
        List<int> list = null;
        List<Product> products = ProductRepository.GetAll();
        List<SalesOrder> sales = SalesOrderRepository.GetAll();

        return (from prod in products
                select prod.ProductID)
                .Intersect(from sale in sales
                           select sale.ProductID)
                .ToList();
    }
    #endregion

    #region IntersectProductSalesMethod
    /// <summary>
    /// Find all products that have sales
    /// </summary>
    public List<int> IntersectProductSalesMethod()
    {
        List<int> list = null;
        List<Product> products = ProductRepository.GetAll();
        List<SalesOrder> sales = SalesOrderRepository.GetAll();

        return products
                .Select(prod => prod.ProductID)
                .Intersect(sales.Select(sale => sale.ProductID))
                .ToList();
    }
    #endregion

    #region IntersectUsingComparerQuery
    /// <summary>
    /// Intersect() finds all products that are in common between two collections using a comparer class
    /// </summary>
    public List<Product> IntersectUsingComparerQuery()
    {
        ProductComparer pc = new();
        List<Product> list1 = ProductRepository.GetAll();
        List<Product> list2 = ProductRepository.GetAll();

        list1.RemoveAll(prod => prod.Color == "Black");
        list2.RemoveAll(prod => prod.Color == "Red");

        return (from prod in list1
                select prod)
                .Intersect(list2, pc)
                .ToList();
    }
    #endregion

    #region IntersectUsingComparerMethod
    /// <summary>
    /// Intersect() finds all products that are in common between two collections using a comparer class
    /// </summary>
    public List<Product> IntersectUsingComparerMethod()
    {
        ProductComparer pc = new();
        List<Product> list1 = ProductRepository.GetAll();
        List<Product> list2 = ProductRepository.GetAll();

        list1.RemoveAll(prod => prod.Color == "Black");
        list2.RemoveAll(prod => prod.Color == "Red");

        return list1.Intersect(list2, pc).ToList();
    }
    #endregion

    #region IntersectByQuery
    /// <summary>
    /// Find products within a collection by comparing a List<string> against a specified property in the collection.
    /// </summary>
    public List<Product> IntersectByQuery()
    {
        List<Product> products = ProductRepository.GetAll();

        List<string> colors = new() { "Red", "Black" };

        return (from prod in products
                select prod)
              .IntersectBy(colors, p => p.Color).ToList();
    }
    #endregion

    #region IntersectByMethod
    /// <summary>
    /// IntersectBy() finds DISTINCT products within a collection by comparing a List<string> against a specified property in the collection.
    /// </summary>
    public List<Product> IntersectByMethod()
    {
        List<Product> products = ProductRepository.GetAll();

        List<string> colors = new() { "Red", "Black" };

        return products.IntersectBy(colors, prod => prod.Color).ToList();
    }
    #endregion

    #region IntersectByProductSalesQuery
    /// <summary>
    /// Find all products that have sales using a 'int' key selector
    /// Change the default comparer for IntersectBy()
    /// </summary>
    public List<Product> IntersectByProductSalesQuery()
    {
        List<Product> products = ProductRepository.GetAll();
        List<SalesOrder> sales = SalesOrderRepository.GetAll();

        return (from prod in products
                select prod)
                .IntersectBy<Product, int>(
                    from sale in sales
                    select sale.ProductID, prod => prod.ProductID)
                .ToList();
    }
    #endregion

    #region IntersectByProductSalesMethod
    /// <summary>
    /// Find all products that have sales using a 'int' key selector
    /// Change the default comparer for IntersectBy()
    /// </summary>
    public List<Product> IntersectByProductSalesMethod()
    {
        List<Product> products = ProductRepository.GetAll();
        List<SalesOrder> sales = SalesOrderRepository.GetAll();

        return products
                .IntersectBy<Product, int>
                    (from sale in sales
                    select sale.ProductID, prod => prod.ProductID)
                .ToList();
    }
    #endregion
}
