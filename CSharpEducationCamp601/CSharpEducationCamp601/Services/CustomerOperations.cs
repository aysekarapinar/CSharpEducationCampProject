using CSharpEducationCamp601.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEducationCamp601.Services
{
    public class CustomerOperations
    {
        public void AddCustomer(Customer customer)
        {
            var connection = new MongoDbConnection();
            var customerConnection = connection.GetCustomersCollection();

            var document = new BsonDocument
            {
                { "CustomerName", customer.CustomerName },
                { "CustomerSurname", customer.CustomerSurname },
                { "CustomerCity", customer.CustomerCity },
                { "CustomerBalance", customer.CustomerBalance },
                { "CustomerShoppingCount", customer.CustomerShoppingCount }
            };

            customerConnection.InsertOne(document);
        }

        public List<Customer> GetAllCustomer()
        {
            var connection = new MongoDbConnection();
            var customerCollection = connection.GetCustomersCollection();
            var customers = customerCollection.Find(new BsonDocument()).ToList();
            List<Customer> customerList = new List<Customer>();
            foreach (var customer in customers)
            {
                customerList.Add(new Customer
                {
                    CustomerID = customer["_id"].ToString(),
                    CustomerBalance = decimal.Parse(customer["CustomerBalance"].ToString()),
                    CustomerCity = customer["CustomerCity"].ToString(),
                    CustomerName = customer["CustomerName"].ToString(),
                    CustomerShoppingCount = int.Parse(customer["CustomerShoppingCount"].ToString()),
                    CustomerSurname = customer["CustomerSurname"].ToString()
                });
            }

            return customerList;
        }

        public void DeleteCustomer(string id)
        {
            var connection = new MongoDbConnection();
            var customerCollection = connection.GetCustomersCollection();
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
            customerCollection.DeleteOne(filter);
        }

        public void updateCustomer(Customer customer) 
        {
            var connection = new MongoDbConnection();
            var customerCollection = connection.GetCustomersCollection();
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(customer.CustomerID));
                var updatedValue=Builders<BsonDocument>.Update
                .Set("CustomerName", customer.CustomerName)
                .Set("CustomerSurname", customer.CustomerSurname)
                .Set("CustomerCity", customer.CustomerCity)
                .Set("CustomerBalance", customer.CustomerBalance)
                .Set("CustomerShoppingCount", customer.CustomerShoppingCount);
            customerCollection.UpdateOne(filter, updatedValue);  
        }

        public Customer GetCustomerByID(string id)
        {
            var connection = new MongoDbConnection();
            var customerCollection = connection.GetCustomersCollection();
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
            var result = customerCollection.Find(filter).FirstOrDefault();
            return new Customer
            {
                CustomerBalance = decimal.Parse(result["CustomerBalance"].ToString()),
                CustomerCity = result["CustomerCity"].ToString(),
                CustomerID = id,
                CustomerName = result["CustomerName"].ToString(),
                CustomerShoppingCount = int.Parse(result["CustomerShoppingCount"].ToString()),
                CustomerSurname = result["CustomerSurname"].ToString()
            };

        }
    }
}
