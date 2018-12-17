
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
    class PropertyClassZaduzenja : PropertyInterface
    {

        #region attributes
        [DisplayName("Zaduzenja ID")]
        [SqlName("ZaduzenjaID")]
        [PrimaryKey]
        public int ZaduzenjaID { get; set; }

        [DisplayName("Vozila ID")]
        [SqlName("VozilaID")]
        [ForeignKey("dbo.Vozila", "VozilaID", "VozniPark.PropertiesClass.PropertyClassVozila")]
        public int VozilaID { get; set; }

        [DisplayName("Zaposleni ID")]
        [SqlName("ZaposleniID")]
        [ForeignKey("dbo.Zaposleni", "ZaposleniID", "VozniPark.PropertiesClass.PropertyClassZaposleni")]
        public int ZaposleniID { get; set; }

        [DisplayName("Predjena kilometraza")]
        [SqlName("PredjenaKilometraza")]
        public int PredjenaKilometraza { get; set; }

        [DisplayName("Datum zaduzenja")]
        [SqlName("DatumZaduzenja")]
        [DateTime]
        public DateTime DatumZaduzenja { get; set; }

        [DisplayName("Datum razduzenja")]
        [SqlName("DatumRazduzenja")]
        [DateTime]
        public DateTime DatumRazduzenja { get; set; }
        [DisplayName("Planirano razduzenje")]
        [SqlName("PlaniranoRazduzenje")]
        [DateTime]
        public DateTime PlaniranoRazduzenje { get; set; }

        [DisplayName("Model")]
        [SqlName("Naziv")]
        [ForeignField]
        public string Model { get; set; }

        [DisplayName("Ime zaposlenog")]
        [SqlName("Ime")]
        [ForeignField]
        public string ImeZaposlenog { get; set; }

        [DisplayName("Prezime zaposlenog")]
        [SqlName("Prezime")]
        [ForeignField]
        public string PrezimeZaposlenog { get; set; }
        #endregion


        #region queries

        public string GetDeleteQuery()
        {
            return "delete from dbo.Zaduzenja where ZaduzenjaID = @ZaduzenjaID";
        }

        public string GetInsertQuery()
        {
            return "insert into dbo.Zaduzenja (VozilaID,ZaposleniID,PredjenaKilometraza,DatumZaduzenja,DatumRazduzenja,PlaniranoRazduzenje) values (@VozilaID,@ZaposleniID,@PredjenaKilometraza,@DatumZaduzenja,@DatumRazduzenja,@PlaniranoRazduzenje)";
        }

        public string GetSelectQuery()
        {
            return @"select 
                     ZaduzenjaID,
                     m.Naziv,
                     zap.Ime,
                     zap.Prezime,
                     DatumZaduzenja,
                     PlaniranoRazduzenje,
                     DatumRazduzenja,
                     PredjenaKilometraza
                     from dbo.Zaduzenja as z
                     join dbo.Zaposleni as zap on z.ZaposleniID = zap.ZaposleniID
                     join dbo.Vozila as v on v.VoziloID = z.VozilaID
                     join dbo.Model as m on m.ModelID = v.ModelID";
        }

        public string GetUpdateQuery()
        {
            return "update dbo.Zaposlenja set VozilaID = @VozilaID,ZaposleniID = @ZaposleniID,  PredjenaKilometraza = @PredjenaKilometraza, DatumZaduzenja = @DatumZaduzenja,DatumRazduzenja=@DatumRazduzenja, PlaniranoRazduzenje=@PlaniranoRazduzenje where ZaduzenjaID = @ZaduzenjaID";
        }

        #endregion

        #region parameters
        public List<SqlParameter> GetDeleteParameters()
        {
            List<SqlParameter> list = new List<SqlParameter>();
            {
                SqlParameter parameter = new SqlParameter("ZaduzenjaID", System.Data.SqlDbType.Int);
                parameter.Value = ZaduzenjaID;
                list.Add(parameter);
            }
            return list;
        }

        

        public List<SqlParameter> GetInsertParameters()
        {
            List<SqlParameter> list = new List<SqlParameter>();
          
            {
                SqlParameter parameter = new SqlParameter("VozilaID", System.Data.SqlDbType.Int);
                parameter.Value = VozilaID;
                list.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("ZaposleniID", System.Data.SqlDbType.Int);
                parameter.Value = ZaposleniID;
                list.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("PredjenaKilometraza", System.Data.SqlDbType.Int);
                parameter.Value = PredjenaKilometraza;
                list.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("DatumZaduzenja", System.Data.SqlDbType.DateTime);
                parameter.Value = DatumZaduzenja;
                list.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("DatumRazduzenja", System.Data.SqlDbType.DateTime);
                parameter.Value = DatumRazduzenja;
                list.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("PlaniranoRazduzenje", System.Data.SqlDbType.DateTime);
                parameter.Value = PlaniranoRazduzenje;
                list.Add(parameter);
            }
            return list;
        }

        

        public List<SqlParameter> GetUpdateParameters()
        {
            List<SqlParameter> list = new List<SqlParameter>();
            {
                SqlParameter parameter = new SqlParameter("ZaduzenjaID", System.Data.SqlDbType.Int);
                parameter.Value = ZaduzenjaID;
                list.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("VozilaID", System.Data.SqlDbType.Int);
                parameter.Value = VozilaID;
                list.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("ZaposleniID", System.Data.SqlDbType.Int);
                parameter.Value = ZaposleniID;
                list.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("PredjenaKilometraza", System.Data.SqlDbType.Int);
                parameter.Value = PredjenaKilometraza;
                list.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("DatumZaduzenja", System.Data.SqlDbType.DateTime);
                parameter.Value = DatumZaduzenja;
                list.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("DatumRazduzenja", System.Data.SqlDbType.DateTime);
                parameter.Value = DatumRazduzenja;
                list.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("PlaniranoRazduzenje", System.Data.SqlDbType.DateTime);
                parameter.Value = PlaniranoRazduzenje;
                list.Add(parameter);
            }
            return list;
        }

        
        #endregion
    }
}
