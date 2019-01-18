using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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

        [DisplayName("Zaposleni ID")]
        [SqlName("ZaposleniID")]
        [PrimaryKey]
        [LookupKey]
        public int ZaposleniID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Unesite ime!")]
        [DisplayName("Ime")]
        [SqlName("Ime")]
        [LookupValue]
        
        public string Ime { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Unesite prezime!")]
        [DisplayName("Prezime")]
        [SqlName("Prezime")]
        [LookupValue]
        public string Prezime { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Unesite radno mjesto!")]
        [DisplayName("Radno mjesto")]
        [SqlName("RadnoMjesto")]
       
        public string RadnoMjesto { get; set; }
        #endregion


        #region queries
        public string GetDeleteQuery()
        {
            return @"DELETE FROM dbo.Zaposleni
                     WHERE ZaposleniID = @ZaposleniID ";
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
                     WHERE ZaposleniID = @ZaposleniID";
        }

        public string GetLookupQuery()
        {
            return @"SELECT ZaposleniID, Ime, Prezime, RadnoMjesto
                     FROM dbo.Zaposleni";
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
                SqlParameter parameter = new SqlParameter("@Ime", System.Data.SqlDbType.NVarChar);
                parameter.Value = Ime;
                parameters.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@Prezime", System.Data.SqlDbType.NVarChar);
                parameter.Value = Prezime;
                parameters.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@RadnoMjesto", System.Data.SqlDbType.NVarChar);
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
                SqlParameter parameter = new SqlParameter("@Ime", System.Data.SqlDbType.NVarChar);
                parameter.Value = Ime;
                parameters.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@Prezime", System.Data.SqlDbType.NVarChar);
                parameter.Value = Prezime;
                parameters.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@RadnoMjesto", System.Data.SqlDbType.NVarChar);
                parameter.Value = RadnoMjesto;
                parameters.Add(parameter);
            }
            return parameters;
        }

        

        #endregion
    }
}
