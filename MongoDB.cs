using MongoDB.Bson.Serialization;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;
using System.Collections.ObjectModel;

namespace DatabaseTests
{
    public class MongoDB
    {
        MongoClient Client { get; set; }
        string Database { get; set; }
        string Collection { get; set; }
        public MongoDB(string connectionString, string database, string collection)
        {
            Client = new MongoClient(connectionString);
            BsonClassMap.RegisterClassMap<UserItem>();
            BsonClassMap.RegisterClassMap<UserPhone>();
            Database = database;
            Collection = collection;
        }
        public async Task InsertUserItem(UserItem item)
        {
            var db = Client.GetDatabase(Database);
            var collection = db.GetCollection<BsonDocument>(Collection);
            var bsonDocument = item.ToBsonDocument();

            await collection.InsertOneAsync(bsonDocument);
        }
        public async Task<UserItem> ReadUserItem(string itemId)
        {
            IMongoDatabase db = GetDatabase(Database);
            var collection = db.GetCollection<UserItem>(Collection);

            var doc = await collection.Find(x => x.Uid == itemId).FirstOrDefaultAsync();

            if (doc != null)
            {
                Console.WriteLine("Document found: " + doc.Id.ToString());
            }
            return doc;
        }
        public async Task UpdateUserItem(string itemId, string itemKey, string itemValue)
        {
            IMongoDatabase db = GetDatabase(Database);
            var collection = db.GetCollection<UserItem>(Collection);

            var filter = Builders<UserItem>.Filter.Eq("_id", itemId);
            var update = Builders<UserItem>.Update.Set(itemKey, itemValue);

            var result = await collection.UpdateOneAsync(filter, update);
            Console.WriteLine("Update Success: " + result.IsAcknowledged);
        }
        public async Task DeleteUserItem(string itemId)
        {
            IMongoDatabase db = GetDatabase(Database);
            var collection = db.GetCollection<UserItem>(Collection);

            var deleteFilter = Builders<UserItem>.Filter.Eq("_id", itemId);

            var result = await collection.DeleteOneAsync(deleteFilter);
            Console.WriteLine("Deletion Success: " + result.IsAcknowledged);
        }
        private IMongoDatabase GetDatabase(string databaseName)
        {
            return this.Client.GetDatabase(databaseName);
        }
    }
}
