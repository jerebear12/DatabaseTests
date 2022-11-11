using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using VelocityDb;
using VelocityDb.Session;

namespace DatabaseTests
{
    internal class VelocityDB
    {
        public static readonly string SystemDir = @"QuickStart"; //"QuickStart"; // appended to SessionBase.BaseDatabasePath
        public static UserItem Retrieve(string uid, ServerClientSession session)
        {
            UserItem item = null;
            //using (SessionNoServer session = new SessionNoServer(systemDir))
            //{
            //session.BeginRead();
            IEnumerable<UserItem> items = session.AllObjects<UserItem>();
            var queriedItem = from i in items where i.Uid == uid select i;
            if (queriedItem.Any())
            {
                item = queriedItem.First();
            }
            else
            {
                Console.WriteLine("Retrieve Error: no object found.");
            }
            //session.Commit();
            //}
            return item;
        }
        public static bool PersistUserItem(UserItem item, ServerClientSession session)
        {
            bool success = true;
            //using (SessionNoServer session = new SessionNoServer(systemDir))
            //{
            try
            {
                //session.BeginUpdate();
                session.Persist(item);
                //session.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Persisting Obj: " + ex.Message);
                success = false;
                //session.Abort();
            }
            //}
            return success;
        }
        public static bool DeleteUserItem(UserItem item, ServerClientSession session)
        {
            bool success = true;
            //using (SessionNoServer session = new SessionNoServer(systemDir))
            //{
            try
            {
                //session.BeginUpdate();
                UserItem itemToDelete = Retrieve(item.Uid, session);
                if (itemToDelete != null)
                {
                    //itemToDelete.Unpersist(session);
                }
                else
                {
                    Console.WriteLine("Deletion Error: Could not find object to delete");
                    success = false;
                }
                //session.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Deletion Error: " + ex.Message);
                success = false;
                //session.Abort();
            }
            //}
            return success;
        }
        public static bool UpdateUserItem(UserItem item, ServerClientSession session)
        {
            bool success = true;
            //using (SessionNoServer session = new SessionNoServer(systemDir))
            //{
            try
            {
                //session.BeginUpdate();
                UserItem itemToUpdate = Retrieve(item.Uid, session);
                if (itemToUpdate != null)
                {
                    session.UpdateObject(itemToUpdate);
                }
                else
                {
                    Console.WriteLine("Update Error: Could not find object to update");
                    success = false;
                }
                //session.Commit();
            }
            catch (Exception ex)
            {

                Console.WriteLine("Update Error: " + ex.Message);
                success = false;
                //session.Abort();
            }
            //}
            return success;
        }
    }
}
