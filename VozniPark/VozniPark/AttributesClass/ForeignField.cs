using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VozniPark.AttributesClass
{
    class ForeignField : Attribute
    {
        public string tableKey { get; set; }

        public ForeignField()
        {

        }
        public ForeignField(string key)
        {
            tableKey = key;
        }
    }
}
