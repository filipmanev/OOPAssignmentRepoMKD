using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace DataAccess
{
    public class MyConnectionClass
    {
        public OOPdbEntities Context { get; set; }
        public MyConnectionClass()
        {
            Context = new OOPdbEntities();
        }
    }
}
