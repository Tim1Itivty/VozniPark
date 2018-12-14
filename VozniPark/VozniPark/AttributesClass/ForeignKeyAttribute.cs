using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VozniPark.AttributesClass
{
    [AttributeUsage(AttributeTargets.Property)]
    class ForeignKeyAttribute : Attribute
    {
        public string referencedTable;
        public string referencedColumn;
        public string referencedClass;

        public ForeignKeyAttribute(string refTable, string refColumn, string refClass)
        {
            this.referencedTable = refTable;
            this.referencedColumn = refColumn;
            referencedClass = refClass;

        }
    }
}
