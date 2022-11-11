using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using VelocityDb.Session;
using System.Net;
using Bogus;
using System.Reflection.Metadata;

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

            FakeData.Init(10000);
            List<UserItem> items = FakeData.UserItems;

            var watch = new System.Diagnostics.Stopwatch();

            watch.Start();

            foreach (UserItem item in items)
            {
                // Insert Item
                await mongo.InsertUserItem(item);
                


                UserItem newItem = mongo.ReadUserItem(item.Uid);

                Console.WriteLine("Read Item's Name: " + newItem.Name);

                /*
                
                // Update Item
                await mongo.UpdateUserItem(item.Uid, "Name", "Bill");

                

                // Read Item
                UserItem updatedItem = mongo.ReadUserItem(item.Uid);
                Console.WriteLine("Updated Name: " + updatedItem.Name);

                

                // Delete Item
                await mongo.DeleteUserItem(item.Uid);

                

                // Read  Item
                UserItem deletedItem = mongo.ReadUserItem(item.Uid);
                if (deletedItem != null) { Console.WriteLine(deletedItem.Name); }

                */
                
            }

            watch.Stop();

            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");

            /*

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
            // Init UserItem object

            /*

            string s_systemHost2 = "localhost";

            List<ReplicaInfo> alternateSystemBoot = new List<ReplicaInfo> { new ReplicaInfo { Path = "Replica1", Host = Dns.GetHostName() }, new ReplicaInfo { Path = "Replica2", Host = Dns.GetHostName() }, new ReplicaInfo { Path = "Replica3", Host = s_systemHost2 } };
            var perfTest = "PerfTest";

            FakeData.Init(1000);

            List<UserItem> items = FakeData.UserItems;

            var watch = new System.Diagnostics.Stopwatch();

            watch.Start();

            using (ServerClientSession session = new ServerClientSession(alternateSystemBoot))
            {
                var originalId = string.Empty;

                foreach (UserItem item in items)
                {
                    // Create

                    session.BeginUpdate();

                    originalId = item.Uid;

                    VelocityDB.PersistUserItem(item, session);

                    session.Commit();

                    /*

                    // Read

                    session.BeginRead();

                    var foundUser1 = VelocityDB.Retrieve(originalId, session);
                    if (foundUser1 != null)
                    {
                        Console.WriteLine(foundUser1.Name);
                    }

                    session.Commit();

                    // Update

                    session.BeginUpdate();

                    item.Name = "Fred";

                    session.Commit();
                    
                    // Read

                    session.BeginRead();

                    var foundUser2 = VelocityDB.Retrieve(originalId, session);
                    if (foundUser2 != null)
                    {
                        Console.WriteLine(foundUser2.Name);
                    }

                    session.Commit();

                    

                    session.BeginUpdate();

                    session.DeleteObject(item.Id);

                    session.Commit();

                    

                    break;
                }
            }

            watch.Stop();

            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");

            */

            /*
            var originalId = string.Empty;
            using (ServerClientSession session = new ServerClientSession(alternateSystemBoot))
            {
                session.BeginUpdate();

                UserItem userItem = new UserItem();
                originalId = userItem.Uid;

                userItem.Name = "Jeremiah";
                userItem.Username = "Jeremiah121222";
                userItem.Email = "jeremiahgavin12@gmail.com";
                userItem.Password = "Test";
                userItem.UserPhone = phone;

                VelocityDB.PersistUserItem(userItem, session);

                session.Commit();
            }

            // Update
            var updatedEmail = "blidnewholmes@gmail.com";
            using (ServerClientSession session = new ServerClientSession(alternateSystemBoot))
            {
                session.BeginUpdate();

                var foundUser = VelocityDB.Retrieve(originalId, session);
                foundUser.Email = updatedEmail;
                VelocityDB.UpdateUserItem(foundUser, session);

                session.Commit();

                Console.WriteLine("User updated");
            }

            // Retrieve
            using (ServerClientSession session = new ServerClientSession(alternateSystemBoot))
            {
                session.BeginRead();

                var foundUser = VelocityDB.Retrieve(originalId, session);
                if (foundUser.Email != updatedEmail)
                {
                    Console.WriteLine("Email was not updated!");
                    Debugger.Break();
                }
                else
                {
                    Console.WriteLine("Email was updated");
                }

                session.Commit();
            }
            */

            //UserItem i = VelocityDB.Retrieve(userItem.Uid, session);
            //if (i != null) Console.WriteLine(i.Email);

            ////userItem.Email = "blidnewholmes@gmail.com";
            //Console.WriteLine(userItem.Uid);
            //Console.WriteLine(userItem.Name);

            //VelocityDB.UpdateUserItem(userItem, session);

            //UserItem j = VelocityDB.Retrieve(userItem.Uid, session);
            //if (j != null) Console.WriteLine(j.Email);

            //VelocityDB.DeleteUserItem(userItem, session);

            //UserItem k = VelocityDB.Retrieve(userItem.Uid, session);
            //if (k != null) Console.WriteLine(k.Email);

            Console.ReadLine();
        }

        public class FakeData
        {
            public static List<UserItem> UserItems = new List<UserItem>();

            public static void Init(int count)
            {
                var phoneNum = 1111111111;
                var phoneFaker = new Faker<UserPhone>()
                   .RuleFor(p => p.Number, p => phoneNum++)
                   .RuleFor(p => p.DeviceName, p => p.Hacker.Phrase())
                   .RuleFor(p => p.Model, p => p.Hacker.Abbreviation())
                   .RuleFor(p => p.OS, p => p.Hacker.Adjective());

                var userFaker = new Faker<UserItem>()
                   .RuleFor(p => p.Name, f => f.Name.FirstName())
                   .RuleFor(p => p.Username, f => f.Name.FullName())
                   .RuleFor(p => p.Email, f => f.Internet.Email())
                   .RuleFor(p => p.Password, f => f.Internet.Password())
                   .RuleFor(p => p.UserPhone, phoneFaker.Generate());
                   

                var items = userFaker.Generate(count);

                FakeData.UserItems.AddRange(items);
            }
        }

    }
}
