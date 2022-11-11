using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseTests
{
    public abstract class Item : Entry
    {
        const string CORNER_RADIUS = "0.8rem";
        const string HEIGHT = "500px";

        public string _Width;
        public string Width {
            get { return _Width; }
            set { _Width = value; }
        }
    }
}
