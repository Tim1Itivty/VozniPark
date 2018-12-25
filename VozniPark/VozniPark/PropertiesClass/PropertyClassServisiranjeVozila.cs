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
    class PropertyClassServisiranjeVozila : PropertyInterface
    {
        #region properties
        [DisplayName("Servisiranje ID")]
        [SqlName("ServisiranjeID")]
        [PrimaryKey]
        public int ServisiranjeId { get; set; }

        [DisplayName("Vozilo ID")]
        [SqlName("VoziloID")]
        [ForeignKey("dbo.Vozila", "VoziloID", "VozniPark.PropertiesClass.PropertyClassVozila")]
        [LookupKey]
        
        public int VoziloId { get; set; }


        [DisplayName("Naziv")]
        [SqlName("Naziv")]
        [ForeignField("Vozilo ID")]
        public string Model { get; set; }

        //[DisplayName("Servis ID")]  
        //[SqlName("ServisID")]   
        //[ForeignKey("dbo.Servis","ServisID", "VozniPark.PropertiesClass.PropertyClassServis")]
        //public int ServisId { get; set; }

        [DisplayName("Datum servisiranja")]
        [SqlName("DatumServisiranja")]
        [DateTime]
        public DateTime DatumServisiranja { get; set; }

        //[DisplayName("Kolicina natocenog goriva")]
        //[SqlName("KolicinaNatocenogGoriva")]
        //public decimal KolicinaNatocenogGoriva { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Unesite cijenu servisa!")]
        [DisplayName("Cijena servisa")]
        [SqlName("CijenaServisa")]
        public decimal CijenaServisa { get; set; }

       

        #endregion

                
        #region queries
        public string GetSelectQuery()
        {
            return @"SELECT s.ServisiranjeID,s.VoziloID,p.naziv+' '+m.Naziv AS Naziv,s.DatumServisiranja,s.CijenaServisa
                                FROM ServisiranjeVozila s
                                join Vozila v 
                                on s.voziloID=v.VoziloID
                                join Model m 
                                on m.ModelID=v.ModelID
                                join Proizvodjac p
                                on p.ProizvodjacID=m.ProizvodjacID";
        }

        public string GetInsertQuery()

        {
            return @"INSERT INTO dbo.ServisiranjeVozila( VoziloID, DatumServisiranja,  CijenaServisa)
            VALUES( @VoziloID, @DatumServisiranja,  @CijenaServisa)";
        }

        public string GetUpdateQuery()
        {
            return @"UPDATE dbo.ServisiranjeVozila SET 
                                                       DatumServisiranja = @DatumServisiranja,
                                                      
                                                       CijenaServisa = @CijenaServisa, 
                                                       VoziloID = @VoziloID
                    WHERE ServisiranjeID = @ServisiranjeID";
        }

        public string GetDeleteQuery()
        {
            return @"DELETE FROM dbo.ServisiranjeVozila WHERE ServisiranjeID = @ServisiranjeID";
        }

        public string GetLookupQuery()
        {
            throw new NotImplementedException();
        }

        #endregion


        #region parameters

        public List<SqlParameter> GetInsertParameters()
        {
            List<SqlParameter> list = new List<SqlParameter>();
        
            {
                SqlParameter parameter = new SqlParameter("@ServisiranjeID", System.Data.SqlDbType.Int);
                parameter.Value = ServisiranjeId;
                list.Add(parameter);
            }

            {
                SqlParameter parameter = new SqlParameter("@VoziloID", System.Data.SqlDbType.Int);
                parameter.Value = VoziloId;
                list.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@DatumServisiranja", System.Data.SqlDbType.Date);
                parameter.Value = DatumServisiranja;
                list.Add(parameter);
            }

            //{
            //    SqlParameter parameter = new SqlParameter("@KolicinaNatocenogGoriva", System.Data.SqlDbType.Decimal);
            //    parameter.Value = KolicinaNatocenogGoriva;
            //    list.Add(parameter);
            //}

            {
                SqlParameter parameter = new SqlParameter("@CijenaServisa", System.Data.SqlDbType.Decimal);
                parameter.Value = CijenaServisa;
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
            //{
            //    SqlParameter parameter = new SqlParameter("@ServisiranjeID", System.Data.SqlDbType.Int);
            //    parameter.Value = ServisiranjeId;
            //    list.Add(parameter);
            //}

            {
                SqlParameter parameter = new SqlParameter("@DatumServisiranja", System.Data.SqlDbType.Date);
                parameter.Value = DatumServisiranja;
                list.Add(parameter);
            }

            //{
            //    SqlParameter parameter = new SqlParameter("@KolicinaNatocenogGoriva", System.Data.SqlDbType.Decimal);
            //    parameter.Value = KolicinaNatocenogGoriva;
            //    list.Add(parameter);
            //}

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
