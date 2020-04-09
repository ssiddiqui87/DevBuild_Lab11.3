using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.Models
{
    public class DAL
    {
        SqlConnection connection;

        public DAL(string connectionString)
        {
            connection = new SqlConnection(connectionString);
        }
        public IEnumerable<Products> GetProductCategories()
        {
            string queryString = "SELECT DISTINCT Category FROM Products";
            IEnumerable<Products> Products = connection.Query<Products>(queryString);

            return Products;
        }

        public IEnumerable<Products> GetProductsAll()
        {
            string queryString = "SELECT * FROM Products";
            IEnumerable<Products> Products = connection.Query<Products>(queryString);

            return Products;
        }
        public Products GetProductById(int id)
        {
            string queryString = "SELECT * FROM Products WHERE Id = @val";
            Products prod = connection.QueryFirstOrDefault<Products>(queryString, new { val = id });

            return prod;
        }

        public IEnumerable<Products> GetProductsInCategory(string cat)
        {
            string queryString = "SELECT * FROM Products WHERE Category = @val";
            IEnumerable<Products> Products = connection.Query<Products>(queryString, new { val = cat });

            return Products;
        }

        public int CreateProduct(Products prod)
        {
            string addString = "INSERT INTO Products (Name, Category, Description, Price) ";
            addString += "VALUES (@Name, @Category, @Description, @Price)";
            return connection.Execute(addString, prod);
        }

        public int DeleteProductById(int id)
        {
            string deleteString = "DELETE FROM Products WHERE Id = @val";
            return connection.Execute(deleteString, new { val = id });
        }

        public int UpdateProductById(Products prod)
        {
            string editString = "UPDATE Products SET Name = @Name, Description = @Description, ";
            editString += "Category = @Category, Price = @Price WHERE Id = @Id";
            return connection.Execute(editString, prod);
        }
    }
}
