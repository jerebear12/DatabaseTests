using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using Nest;
using VelocityDb;

namespace DatabaseTests
{
    [ElasticsearchType(IdProperty = nameof(Id))]
    public abstract class Entry : OptimizedPersistable
    {
        public string Uid = Guid.NewGuid().ToString();
        public string _Name;
        public string Name {
            get { return _Name; }
            set { Update(); _Name = value; }
        }
    }
}
