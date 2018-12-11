using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VozniPark.AttributesClass
{
    [AttributeUsage(AttributeTargets.Property)]
    class SqlNameAttribute : Attribute
    {
        public string Name;

        public SqlNameAttribute(string name)
        {
            this.Name = name;
        }
    }
}
