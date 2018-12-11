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

        public ForeignKeyAttribute(string refTable, string refColumn)
        {
            this.referencedTable = refTable;
            this.referencedColumn = refColumn;

        }
    }
}
