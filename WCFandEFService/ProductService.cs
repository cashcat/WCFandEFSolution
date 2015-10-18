using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFandEFService
{
    public class ProductService : IProductService
    {
        public Product GetProduct(int id)
        {
            // TODO: retrieve the real product info from DB using EF
            /*
            Product product = new Product();
            product.ProductID = id;
            product.ProductName = "fake product name";
            product.UnitPrice = (decimal)10.0;
                */

            NorthwindEntities context = new NorthwindEntities();
            var productEntity = (from p
                                in context.ProductEntities
                                where p.ProductID == id
                                select p).FirstOrDefault();

            if (productEntity != null)
                return TranslateProductEntityToProduct(productEntity);
            else
                throw new Exception("Invalid product id");
        }

        public Employee GetEmployee(int id)
        {
            // TODO: retrieve the real product info from DB using EF
   

            NorthwindEntities context = new NorthwindEntities();
            var employeeEntity = (from p
                                in context.EmployeeEntities
                                 where p.EmployeeID == id
                                 select p).FirstOrDefault();

            if (employeeEntity != null)
                return TranslateEmployeeEntityToProduct(employeeEntity);
            else
                throw new Exception("Invalid Employee id");
        }


        private Product TranslateProductEntityToProduct(
            ProductEntity productEntity)
        {
            Product product = new Product();

            product.ProductID = productEntity.ProductID;
            product.ProductName = productEntity.ProductName;
            product.QuantityPerUnit = productEntity.QuantityPerUnit;
            product.UnitPrice = (decimal)productEntity.UnitPrice;
            product.Discontinued = productEntity.Discontinued;

            return product;
        }


        private Employee TranslateEmployeeEntityToProduct(
       EmployeeEntity employeeEntity)
        {
            Employee employee = new Employee();

            employee.EmployeeID = employeeEntity.EmployeeID;
            employee.LastName = employeeEntity.LastName;
            employee.FirstName = employeeEntity.FirstName;
            employee.Title = employeeEntity.Title;


            return employee;
        }

    }
}
