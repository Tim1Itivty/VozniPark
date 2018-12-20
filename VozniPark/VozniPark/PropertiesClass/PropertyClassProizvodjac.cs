using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VozniPark.AttributesClass;
using System.ComponentModel;
using System.Data.SqlClient;

namespace VozniPark.PropertiesClass
{
    class PropertyClassProizvodjac : PropertyInterface
    {
        #region properties
        [DisplayName("Proizvodjac ID")]
        [SqlName("ProizvodjacID")]
        [PrimaryKey]
        [LookupKey]
        public int ProizvodjacID { get; set; }


        [DisplayName("Naziv")]
        [SqlName("Naziv")]
        [LookupValue]
        public string Naziv { get; set; }

        public List<SqlParameter> GetInsertParameters()
        {
            List<SqlParameter> list = new List<SqlParameter>();
            {
                SqlParameter parameter = new SqlParameter("@Naziv", System.Data.SqlDbType.NVarChar);
                parameter.Value = Naziv;
                list.Add(parameter);
            }

            return list;

        }
        #endregion

        #region parameters
        public List<SqlParameter> GetUpdateParameters()
        {
            List<SqlParameter> list = new List<SqlParameter>();
            {
                SqlParameter parameter = new SqlParameter("@ProizvodjacID", System.Data.SqlDbType.Int);
                parameter.Value = ProizvodjacID;
                list.Add(parameter);
            }

            
            {
                SqlParameter parameter = new SqlParameter("@Naziv", System.Data.SqlDbType.NVarChar);
                parameter.Value = Naziv;
                list.Add(parameter);
            }
            
            return list;
        }

        public List<SqlParameter> GetDeleteParameters()
        {
            List<SqlParameter> list = new List<SqlParameter>();
            {
                SqlParameter parameter = new SqlParameter("@ProizvodjacID", System.Data.SqlDbType.Int);
                parameter.Value = ProizvodjacID;
                list.Add(parameter);
            }
            return list;
        }
        #endregion

        #region queries
        public string GetSelectQuery()
        {

            return @"SELECT ProizvodjacID, Naziv FROM dbo.Proizvodjac";
        }

        public string GetInsertQuery()
        {
            return @"INSERT INTO dbo.Proizvodjac(Naziv) VALUES( @Naziv)";
        }

        public string GetUpdateQuery()
        {
            return @"UPDATE dbo.Proizvodjac SET  Naziv = @Naziv WHERE  ProizvodjacID = @ProizvodjacID";
        }

        public string GetDeleteQuery()
        {
            return @"DELETE FROM dbo.Proizvodjac WHERE ProizvodjacID = @ProizvodjacID";
        }

        public string GetLookupQuery()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
