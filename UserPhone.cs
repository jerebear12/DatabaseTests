﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VelocityDb;

namespace DatabaseTests
{
    public class UserPhone : OptimizedPersistable
    {
        public long _Number;
        public string _DeviceName;
        public string _Model;
        public string _OS;
        public long Number {
            get { return _Number; }
            set { Update(); _Number = value; }
        }
        public string DeviceName {
            get { return _DeviceName; }
            set { Update(); _DeviceName = value; }
        }
        public string Model {
            get { return _Model; }
            set { Update(); _Model = value; }
        }
        public string OS {
            get { return _OS; }
            set { Update(); _OS = value; }
        }
    }
}
