using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VozniPark.AttributesClass;

namespace VozniPark.PropertiesClass
{
    class PropertyClassServis : PropertyInterface
    {
        #region properties

        [DisplayName("Servis ID")]
        [SqlName("ServisID")]
        [PrimaryKey]
        public int ServisID { get; set; }


        [DisplayName("Tip Servisa")]
        [SqlName("TipServisa")]
        public string TipServisa { get; set; }
        #endregion

        #region Parameteres
        public List<SqlParameter> GetInsertParameters()
        {
            List<SqlParameter> list = new List<SqlParameter>();
            {
                SqlParameter parameter = new SqlParameter("@TipServisa", System.Data.SqlDbType.NVarChar);
                parameter.Value = TipServisa;
                list.Add(parameter);
            }

            return list;

        }

        public List<SqlParameter> GetUpdateParameters()
        {
            List<SqlParameter> list = new List<SqlParameter>();
            {
                SqlParameter parameter = new SqlParameter("@ServisID", System.Data.SqlDbType.Int);
                parameter.Value = ServisID;
                list.Add(parameter);
            }


            {
                SqlParameter parameter = new SqlParameter("@TipServisa", System.Data.SqlDbType.NVarChar);
                parameter.Value = TipServisa;
                list.Add(parameter);
            }

            return list;
        }

        public List<SqlParameter> GetDeleteParameters()
        {
            List<SqlParameter> list = new List<SqlParameter>();
            {
                SqlParameter parameter = new SqlParameter("@ServisID", System.Data.SqlDbType.Int);
                parameter.Value = ServisID;
                list.Add(parameter);
            }
            return list;
        }
        #endregion

        #region queries
        public string GetSelectQuery()
        {

            return @"SELECT ServisID, TipServisa FROM dbo.Servis";
        }

        public string GetInsertQuery()
        {
            return @"INSERT INTO dbo.Servis(TipServisa) VALUES( @TipServisa)";
        }

        public string GetUpdateQuery()
        {
            return @"UPDATE dbo.Servis SET  TipServisa = @TipServisa WHERE  ServisID = @ServisID";
        }

        public string GetDeleteQuery()
        {
            return @"DELETE FROM dbo.Servis WHERE ServisID = @ServisID";
        }

        public string GetLookupQuery()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
