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
    public abstract class Entry // : OptimizedPersistable
    {
        protected Entry()
        {
            this.Uid = Guid.NewGuid().ToString();
            this._id = Guid.NewGuid().ToString();
        }
        public string _id { get; private set; }
        public string Uid { get; private set; }
        //public string Uid = Guid.NewGuid().ToString();
        public string _Name;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
    }
}
