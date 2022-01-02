using Catalog.API.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Data
{
    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetSection("DatabaseSettings").GetValue<string>("ConnectionString"));
            var db = client.GetDatabase(configuration.GetSection("DatabaseSettings").GetValue<string>("Database"));
            Products = db.GetCollection<Product>(configuration.GetSection("DatabaseSettings").GetValue<string>("CollectionName"));
            CatalogContextSeed.SeedData(Products);
        }
        public IMongoCollection<Product> Products { get; }
    }
}
