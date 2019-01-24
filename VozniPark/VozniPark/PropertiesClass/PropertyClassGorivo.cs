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
    public class PropertyClassGorivo : PropertyInterface
    {
        #region properties

        [DisplayName("Tocenje goriva ID")]
        [SqlName("TocenjeGorivaID")]
        [PrimaryKey]
        public int TocenjeGorivaID { get; set; }

        [DisplayName("Vozilo ID")]
        [SqlName("VoziloID")]
        [ForeignKey("dbo.Vozilo", "VoziloID", "VozniPark.PropertiesClass.PropertyClassVozila")]
        [LookupValue]
        public int VoziloId { get; set; }

        [DisplayName("Naziv")]
        [SqlName("Naziv")]
        [ForeignField("Vozilo ID")]
        public string Model { get; set; }

        [DisplayName("Količina  goriva")]
        [SqlName("KolicinaGoriva")]
        public decimal KolicinaNatocenogGoriva { get; set; }

        [DisplayName("Cijena")]
        [SqlName("Cijena")]
        public decimal Cijena { get; set; }


        [DisplayName("Datum točenja")]
        [SqlName("DatumTocenja")]
        [DateTimeAttribute]
        public DateTime DatumTocenja { get; set; }

        #endregion

        #region Parameteres
        public List<SqlParameter> GetInsertParameters()
        {
            List<SqlParameter> list = new List<SqlParameter>();
            {
                SqlParameter parameter = new SqlParameter("@VoziloID", System.Data.SqlDbType.Int);
                parameter.Value = VoziloId;
                list.Add(parameter);
            }
           
            {
                SqlParameter parameter = new SqlParameter("@KolicinaGoriva", System.Data.SqlDbType.Decimal);
                parameter.Value = KolicinaNatocenogGoriva;
                list.Add(parameter);
            }
           
            {
                SqlParameter parameter = new SqlParameter("@Cijena", System.Data.SqlDbType.Decimal);
                parameter.Value = Cijena;
                list.Add(parameter);
            }
          
            {
                SqlParameter parameter = new SqlParameter("@DatumTocenja", System.Data.SqlDbType.DateTime);
                parameter.Value = DatumTocenja;
                list.Add(parameter);
            }
            return list;

        }

        public List<SqlParameter> GetUpdateParameters()
        {
            List<SqlParameter> list = new List<SqlParameter>();
            {
                SqlParameter parameter = new SqlParameter("@TocenjeGorivaID", System.Data.SqlDbType.Int);
                parameter.Value = TocenjeGorivaID;
                list.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@VoziloID", System.Data.SqlDbType.Int);
                parameter.Value = VoziloId;
                list.Add(parameter);
            }

            {
                SqlParameter parameter = new SqlParameter("@KolicinaGoriva", System.Data.SqlDbType.Decimal);
                parameter.Value = KolicinaNatocenogGoriva;
                list.Add(parameter);
            }

            {
                SqlParameter parameter = new SqlParameter("@Cijena", System.Data.SqlDbType.Decimal);
                parameter.Value = Cijena;
                list.Add(parameter);
            }

            {
                SqlParameter parameter = new SqlParameter("@DatumTocenja", System.Data.SqlDbType.DateTime);
                parameter.Value = DatumTocenja;
                list.Add(parameter);
            }
            
            return list;
        }

        public List<SqlParameter> GetDeleteParameters()
        {
            List<SqlParameter> list = new List<SqlParameter>();
            {
                SqlParameter parameter = new SqlParameter("@TocenjeGorivaID", System.Data.SqlDbType.Int);
                parameter.Value = TocenjeGorivaID;
                list.Add(parameter);
            }
            return list;
        }
        #endregion

        #region queries
        public string GetSelectQuery()
        {

            return @"SELECT g.TocenjeGorivaID,g.VoziloID,p.naziv+' '+m.Naziv AS Naziv,g.KolicinaGoriva,g.Cijena,g.DatumTocenja
                                            FROM TocenjeGoriva g 
                                            join Vozila v 
                                            on g.voziloID=v.VoziloID
                                            join Model m 
                                            on m.ModelID=v.ModelID
                                            join Proizvodjac p
                                            on p.ProizvodjacID=m.ProizvodjacID";
        }

        public string GetInsertQuery()
        {
            return @"INSERT INTO dbo.TocenjeGoriva(VoziloID,KolicinaGoriva,Cijena,DatumTocenja) VALUES( @VoziloID,@KolicinaGoriva,@Cijena,@DatumTocenja)";
        }

        public string GetUpdateQuery()
        {
            return @"UPDATE dbo.TocenjeGoriva SET  VoziloID=@VoziloID,
                                                   KolicinaGoriva=@KolicinaGoriva,
                                                    Cijena=@Cijena,
                                                    DatumTocenja=@DatumTocenja
                                          WHERE  TocenjeGorivaID = @TocenjeGorivaID";
        }

        public string GetDeleteQuery()
        {
            return @"DELETE FROM dbo.TocenjeGoriva WHERE TocenjeGorivaID = @TocenjeGorivaID";
        }

        public string GetLookupQuery()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
