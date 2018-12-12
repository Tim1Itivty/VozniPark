
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
    class PropertyClassServisiranjeVozila : PropertyInterface
    {
        #region properties
        [DisplayName("Servisiranje ID")]
        [SqlName("ServisiranjeID")]
        [PrimaryKey]
        public int ServisiranjeId { get; set; }

        [DisplayName("Servis ID")]  
        [SqlName("ServisID")]   
        [ForeignKey("dbo.Servis","ServisID")]
        public int ServisId { get; set; }

        [DisplayName("Datum servisiranja")]
        [SqlName("DatumServisiranja")]
        public DateTime DatumServisiranja { get; set; }

        [DisplayName("Kolicina natocenog goriva")]
        [SqlName("KolicinaNatocenogGoriva")]
        public decimal KolicinaNatocenogGoriva { get; set; }

        [DisplayName("Cijena servisa")]
        [SqlName("CijenaServisa")]
        public decimal CijenaServisa { get; set; }

        [DisplayName("Vozilo ID")]
        [SqlName("VoziloID")]
        [ForeignKey("dbo.Vozilo", "VoziloID")]
        public int VoziloId { get; set; }

        #endregion

                
        #region queries
        public string GetSelectQuery()
        {
            return @"SELECT ServisiranjeID, ServisID, DatumServisiranja, KolicinaNatocenogGoriva, CijenaServisa, VoziloID FROM dbo.ServisiranjeVozila";
        }

        public string GetInsertQuery()

        {
            return @"INSERT INTO dbo.ServisiranjeVozila(ServisID, DatumServisiranja, KolicinaNatocenogGoriva, CijenaServisa, VoziloID)
            VALUES(@ServisID, @DatumServisiranja, @KolicinaNatocenogGoriva, @CijenaServisa, @VoziloID)";
        }

        public string GetUpdateQuery()
        {
            return @"UPDATE dbo.ServisiranjeVozila SET ServisID = @ServisID,
                                                       DatumServisiranja = @DatumServisiranja,
                                                       KolicinaNatocenogGoriva = @KolicinaNatocenogGoriva,
                                                       CijenaServisa = @CijenaServisa, 
                                                       VoziloID = @VoziloID
                    WHERE ServisiranjeID = @ServisiranjeID";
        }

        public string GetDeleteQuery()
        {
            return @"DELETE FROM dbo.ServisiranjeVozila WHERE ServisiranjeID = @ServisiranjeID";
        }



        #endregion


        #region parameters

        public List<SqlParameter> GetInsertParameters()
        {
            List<SqlParameter> list = new List<SqlParameter>();
        
            {
                SqlParameter parameter = new SqlParameter("@ServisID", System.Data.SqlDbType.Int);
                parameter.Value = ServisId;
                list.Add(parameter);
            }

            {
                SqlParameter parameter = new SqlParameter("@DatumServisiranja", System.Data.SqlDbType.Date);
                parameter.Value = DatumServisiranja;
                list.Add(parameter);
            }

            {
                SqlParameter parameter = new SqlParameter("@KolicinaNatocenogGoriva", System.Data.SqlDbType.Decimal);
                parameter.Value = KolicinaNatocenogGoriva;
                list.Add(parameter);
            }

            {
                SqlParameter parameter = new SqlParameter("@CijenaServisa", System.Data.SqlDbType.Decimal);
                parameter.Value = CijenaServisa;
                list.Add(parameter);
            }

            {
                SqlParameter parameter = new SqlParameter("@VoziloID", System.Data.SqlDbType.Int);
                parameter.Value = VoziloId;
                list.Add(parameter);
            }

            return list;


        }

        public List<SqlParameter> GetUpdateParameters()
        {
            List<SqlParameter> list = new List<SqlParameter>();

            {
                SqlParameter parameter = new SqlParameter("@ServisiranjeID", System.Data.SqlDbType.Int);
                parameter.Value = ServisiranjeId;
                list.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@ServisID", System.Data.SqlDbType.Int);
                parameter.Value = ServisId;
                list.Add(parameter);
            }

            {
                SqlParameter parameter = new SqlParameter("@DatumServisiranja", System.Data.SqlDbType.Date);
                parameter.Value = DatumServisiranja;
                list.Add(parameter);
            }

            {
                SqlParameter parameter = new SqlParameter("@KolicinaNatocenogGoriva", System.Data.SqlDbType.Decimal);
                parameter.Value = KolicinaNatocenogGoriva;
                list.Add(parameter);
            }

            {
                SqlParameter parameter = new SqlParameter("@CijenaServisa", System.Data.SqlDbType.Decimal);
                parameter.Value = CijenaServisa;
                list.Add(parameter);
            }

            {
                SqlParameter parameter = new SqlParameter("@VoziloID", System.Data.SqlDbType.Int);
                parameter.Value = VoziloId;
                list.Add(parameter);
            }

            return list;
        }

        public List<SqlParameter> GetDeleteParameters()
        {
            List<SqlParameter> list = new List<SqlParameter>();
            {
                SqlParameter parameter = new SqlParameter("@ServisiranjeID", System.Data.SqlDbType.Int);
                parameter.Value = ServisiranjeId;
                list.Add(parameter);
            }

            return list;
        }

        #endregion
    }
}
