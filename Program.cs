using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB;
using Elastic;
using Elasticsearch.Net;
using Nest;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Threading;
using VelocityDB;

namespace DatabaseTests
{
    internal class Program
    {
        async static Task Main(string[] args)
        {
            const string mongoConnStr = "mongodb://localhost:27017";
            const string mongoDatabase = "local";
            const string mongoCollection = "Entries";

            MongoDB mongo = new MongoDB(mongoConnStr, mongoDatabase, mongoCollection);

            const string elasticConnStr = "http://localhost:9200";
            const string fingerprint = "f480bcea71864b6d25c17dd5c2c0c5bf560635324de896660d310ab880cab460";
            const string username = "JerebearsBallerPC";
            const string password = "uDd3jtj4n*yW_u8qytU1";

            Elastic elastic = new Elastic(elasticConnStr);

            // Init UserPhone object
            UserPhone phone = new UserPhone();

            phone.Number = 7633073077;
            phone.DeviceName = "OnePlus 7 Pro";
            phone.Model = "GM1915";
            phone.OS = "Android 11";

            // Init UserItem object
            UserItem userItem = new UserItem();

            userItem.Name = "Jeremiah";
            userItem.Username = "Jeremiah121222";
            userItem.Email = "jeremiahgavin12@gmail.com";
            userItem.Password = "Test";
            userItem.UserPhone = phone;

            /*

            // Insert Item
            await mongo.InsertUserItem(userItem);
            // Read Item
            UserItem newItem = await mongo.ReadUserItem(userItem.Id);

            Console.WriteLine(newItem.Name);
            Console.WriteLine(newItem.UserPhone.Number);

            // Update Item
            await mongo.UpdateUserItem(userItem.Id, "Name", "Bill");
            // Read Item
            UserItem updatedItem = await mongo.ReadUserItem(userItem.Id);
            Console.WriteLine(updatedItem.Name);

            // Delete Item
            await mongo.DeleteUserItem(userItem.Id);
            // Read  Item
            UserItem deletedItem = await mongo.ReadUserItem(userItem.Id);
            if (deletedItem != null) { Console.WriteLine(deletedItem.Name); }


            var response1 = await elastic.IndexEntry(userItem);

            var id = response1.Id;

            Thread.Sleep(5000); // Wait for re-index

            await elastic.GetEntries();

            var returnedItem1 = await elastic.SearchEntries(id);
            Console.WriteLine();
            Console.WriteLine("returnedItem: " + returnedItem1.ToJson());

            userItem.Email = "blidnewholmes@gmail.com";
            await elastic.UpdateEntry(id, userItem);

            Thread.Sleep(5000); // Wait for re-index

            var returnedItem2 = await elastic.SearchEntries(id);
            Console.WriteLine();
            Console.WriteLine("returnedItem: " + returnedItem2.ToJson());

            Console.ReadLine();

            await elastic.DeleteEntry(id);

            Thread.Sleep(5000); // Wait for re-index

            var returnedItem3 = await elastic.SearchEntries(id);
            Console.WriteLine();
            Console.WriteLine("returnedItem: " + returnedItem3.ToJson());

            Console.ReadLine();

            */

            VelocityDB.PersistUserItem(userItem);

            userItem.Email = "blidnewholmes@gmail.com";

            UserItem i = VelocityDB.Retrieve(userItem.Uid);
            if (i != null) Console.WriteLine(i.Email);

            //userItem.Email = "blidnewholmes@gmail.com";
            Console.WriteLine(userItem.Uid);
            Console.WriteLine(userItem.Name);

            VelocityDB.UpdateUserItem(userItem);

            UserItem j = VelocityDB.Retrieve(userItem.Uid);
            if (j != null) Console.WriteLine(j.Email);

            VelocityDB.DeleteUserItem(userItem);

            UserItem k = VelocityDB.Retrieve(userItem.Uid);
            if (k != null) Console.WriteLine(k.Email);

            Console.ReadLine();
        }

    }
}
