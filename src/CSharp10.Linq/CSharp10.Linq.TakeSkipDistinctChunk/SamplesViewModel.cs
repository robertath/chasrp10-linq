using CSharp10.Linq.Common;
using CSharp10.Linq.DataLayer.EntityClasses;

namespace CSharp10.Linq.TakeSkipDistinctChunk;

public class SamplesViewModel : ViewModelBase
{
    #region TakeQuery
    /// <summary>
    /// Use Take() to select a specified number  of items from the begining of a collection
    /// </summary>
    /// <returns>List<Product></returns>
    public List<Product> TakeQuery()
    {
        List<Product> products = GetProducts();
        
        return (from prod in products
                orderby prod.Name
                select prod)
                .Take(5)
                .ToList();
    }
    #endregion TakeQuery

    #region TakeMethod
    /// <summary>
    /// Use Take() to select a specified number  of items from the begining of a collection
    /// </summary>
    /// <returns>List<Product></returns>
    public List<Product> TakeMethod()
    {
        List<Product> products = GetProducts();
        
        return products.OrderBy(prod => prod.Name)
                        .Take(5)
                        .ToList();
    }
    #endregion TakeMethod

    #region TakeRangeQuery
    /// <summary>
    /// Use Take() to select a specified number of items from the begining of a collection using the Range operator
    /// </summary>
    /// <returns>List<Product></returns>
    public List<Product> TakeRangeQuery()
    {
        List<Product> products = GetProducts();

        return (from prod in products
                orderby prod.Name
                select prod)
                .Take(5..8)
                .ToList();
    }
    #endregion TakeRangeQuery

    #region TakeRangeMethod
    /// <summary>
    /// Use Take() to select a specified number of items from the begining of a collection using the Range operator
    /// </summary>
    /// <returns>List<Product></returns>
    public List<Product> TakeRangeMethod()
    {
        List<Product> products = GetProducts();

        return products.OrderBy(prod => prod.Name)
                        .Take(5..8)
                        .ToList();
    }
    #endregion TakeRangeMethod


    #region TakeWhileQuery
    /// <summary>
    /// Use Take() to select a specified number of items from the begining of a collection using the Range operator
    /// </summary>
    /// <returns>List<Product></returns>
    public List<Product> TakeWhileQuery()
    {
        List<Product> products = GetProducts();

        return (from prod in products
                orderby prod.Name
                select prod)
                .TakeWhile(prod =>                    
                    prod.Name.StartsWith("A"))
                .ToList();
    }
    #endregion TakeWhileQuery

    #region TakeWhileMethod
    /// <summary>
    /// Use Take() to select a specified number of items from the begining of a collection using the Range operator
    /// </summary>
    /// <returns>List<Product></returns>
    public List<Product> TakeWhileMethod()
    {
        List<Product> products = GetProducts();

        return products.OrderBy(prod => prod.Name)
                        .TakeWhile(prod => prod.Name.StartsWith("A"))
                        .ToList();
    }
    #endregion TakeWhileMethod

    #region SkipQuery
    /// <summary>
    /// Use Skip() to move past a specified number of items from the beginning of a collection
    /// </summary>
    /// <returns>List<Product></returns>
    public List<Product> SkipQuery()
    {
        List<Product> products = GetProducts();

        return (from prod in products
                orderby prod.Name
                select prod)
                .Skip(30)
                .ToList();
    }
    #endregion SkipQuery

    #region SkipMethod
    /// <summary>
    /// Use Skip() to move past a specified number of items from the beginning of a collection
    /// </summary>
    /// <returns>List<Product></returns>
    public List<Product> SkipMethod()
    {
        List<Product> products = GetProducts();

        return products.OrderBy(prod => prod.Name)
                        .Skip(30)
                        .ToList();
    }
    #endregion SkipMethod

    #region SkipWhileQuery
    /// <summary>
    /// Use SkipWhile() to move past a specified number of items from the beginning of a collection based on true condition
    /// </summary>
    /// <returns>List<Product></returns>
    public List<Product> SkipWhileQuery()
    {
        List<Product> products = GetProducts();

        return (from prod in products
                orderby prod.Name
                select prod)
                .SkipWhile(prod => prod.Name.StartsWith("A"))
                .ToList();
    }
    #endregion SkipWhileQuery

    #region SkipWhileMethod
    /// <summary>
    /// Use SkipWhile() to move past a specified number of items from the beginning of a collection based on true condition
    /// </summary>
    /// <returns>List<Product></returns>
    public List<Product> SkipWhileMethod()
    {
        List<Product> products = GetProducts();

        return products.OrderBy(prod => prod.Name)
                        .SkipWhile(prod => prod.Name.StartsWith("A"))
                        .ToList();
    }
    #endregion SkipWhileMethod


    #region DistinctQuery
    /// <summary>
    /// The Distinct() operator finds all unique values within a collection
    /// In this sample you put distinct product colors into another collection using linq
    /// </summary>
    /// <returns>List<string></returns>
    public List<string> DistinctQuery()
    {
        List<Product> products = GetProducts();

        return (from prod in products
                select prod.Color)
                .Distinct()
                .OrderBy(prod => prod)
                .ToList();
    }
    #endregion DistinctQuery

    #region DistinctMethod
    /// <summary>
    /// The Distinct() operator finds all unique values within a collection
    /// In this sample you put distinct product colors into another collection using linq
    /// </summary>
    /// <returns>List<string></returns>
    public List<string> DistinctMethod()
    {
        List<Product> products = GetProducts();

        return products.Select(prod => prod.Color)
                        .Distinct()
                        .OrderBy(prod => prod)
                        .ToList();
    }
    #endregion DistinctMethod

    #region DistinctByQuery
    /// <summary>
    /// The DistinctBy() operator finds all unique values within a collection using a property
    /// It returns a collection of Product Objects
    /// </summary>
    /// <returns>List<Product></returns>
    public List<Product> DistinctByQuery()
    {
        List<Product> products = GetProducts();

        return (from prod in products
                select prod)
              .DistinctBy(prod => prod.Color)
              .OrderBy(p => p.Color).ToList();
    }
    #endregion DistinctByQuery

    #region DistinctByMethod
    /// <summary>
    /// The DistinctBy() operator finds all unique values within a collection using a property
    /// It returns a collection of Product Objects
    /// </summary>
    /// <returns>List<Product></returns>
    public List<Product> DistinctByMethod()
    {
        List<Product> products = GetProducts();

        return products.DistinctBy(prod => prod.Color, default)
                        .OrderBy(prod => prod.Color)
                        .ToList();
    }
    #endregion DistinctByMethod


    #region ChunkQuery
    /// <summary>
    /// The Chunk() splits the elements of a larger list into a collection of arrays of
    /// a specified size where each element of the collection is an array of those items
    /// </summary>
    /// <returns>List<Product[]></returns>
    public List<Product[]> ChunkQuery()
    {
        List<Product> products = GetProducts();

        return (from prod in products
                select prod)
              .Chunk(5).ToList();
    }
    #endregion ChunkQuery

    #region ChunkMethod
    /// <summary>
    /// The Chunk() splits the elements of a larger list into a collection of arrays of
    /// a specified size where each element of the collection is an array of those items
    /// </summary>
    /// <returns>List<Product[]></returns>
    public List<Product[]> ChunkMethod()
    {
        List<Product> products = GetProducts();

        return products.Chunk(5)
                        .ToList();
    }
    #endregion ChunkMethod
}
