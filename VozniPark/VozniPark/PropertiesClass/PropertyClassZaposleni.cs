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
    class PropertyClassZaposleni : PropertyInterface
    {

        #region Atributi

        [DisplayName("ZaposleniID")]
        [SqlName("ZaposleniID")]
        [PrimaryKey]
        [LookupKey]
        public int ZaposleniID { get; set; }

        [DisplayName("Ime")]
        [SqlName("Ime")]
        [LookupValue]
        public string Ime { get; set; }

        [DisplayName("Prezime")]
        [SqlName("Prezime")]
        public string Prezime { get; set; }

        [DisplayName("Radno mjesto")]
        [SqlName("RadnoMjesto")]
        public string RadnoMjesto { get; set; }
        #endregion


        #region queries
        public string GetDeleteQuery()
        {
            return @"DELETE FROM dbo.Zaposleni
                     WHERE ZaposleniID = @ZaposleniID";
        }

        public string GetSelectQuery()
        {
            return @"SELECT ZaposleniID, Ime, Prezime, RadnoMjesto
                     FROM dbo.Zaposleni";
        }

        public string GetInsertQuery()
        {
            return @"INSERT INTO dbo.Zaposleni
                     (Ime, Prezime, RadnoMjesto)
                     VALUES (@Ime, @Prezime, @RadnoMjesto)";
        }

        public string GetUpdateQuery()
        {
            return @"UPDATE dbo.Zaposleni
                     SET Ime = @Ime, Prezime = @Prezime, RadnoMjesto = @RadnoMjesto
                     WHERE = ZaposleniID = @ZaposleniID";
        }
        #endregion
        #region parameters
        public List<SqlParameter> GetDeleteParameters()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            {
                SqlParameter parameter = new SqlParameter("@ZaposleniID", System.Data.SqlDbType.Int);
                parameter.Value = ZaposleniID;
                parameters.Add(parameter);
            }
            return parameters;
        }

        public List<SqlParameter> GetInsertParameters()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            {
                SqlParameter parameter = new SqlParameter("@Ime", System.Data.SqlDbType.Int);
                parameter.Value = Ime;
                parameters.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@Prezime", System.Data.SqlDbType.Int);
                parameter.Value = Prezime;
                parameters.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@RadnoMjesto", System.Data.SqlDbType.Int);
                parameter.Value = RadnoMjesto;
                parameters.Add(parameter);
            }
            return parameters;
        }

        public List<SqlParameter> GetUpdateParameters()
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            {
                SqlParameter parameter = new SqlParameter("@ZaposleniID", System.Data.SqlDbType.Int);
                parameter.Value = ZaposleniID;
                parameters.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@Ime", System.Data.SqlDbType.Int);
                parameter.Value = Ime;
                parameters.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@Prezime", System.Data.SqlDbType.Int);
                parameter.Value = Prezime;
                parameters.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@RadnoMjesto", System.Data.SqlDbType.Int);
                parameter.Value = RadnoMjesto;
                parameters.Add(parameter);
            }
            return parameters;
        }

        #endregion
    }
}
