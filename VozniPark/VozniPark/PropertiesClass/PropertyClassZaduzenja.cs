
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
        #region atributtes
        public int zaduzenjaID;
        public int vozilaID;
        public int zaposleniID;
        public int predjenaKilometraza;
        public DateTime datumZaduzenja;
        public DateTime datumRazduzenja;
        public DateTime planiranoRazduzenje;
        #endregion

        #region properties
        [DisplayName ("Zaduzenja ID")]
        [SqlName("ZaduzenjaID")]
        [PrimaryKey]
        public int ZaduzenjaID
        {
            get
            {
                return zaduzenjaID;
            }
            set
            {
                zaduzenjaID = value;
            }
        }

        [DisplayName("Vozila ID")]
        [SqlName("VozilaID")]
        [ForeignKey("dbo.Vozila","VozilaID", "PropertiesClass.VozniPark.PropertyClassVozila")]
        public int VozilaID
        {
            get
            {
                return vozilaID;
            }
            set
            {
                vozilaID = value;
            }
        }

        [DisplayName("Zaposleni ID")]
        [SqlName("ZaposleniID")]
        [ForeignKey("dbo.Zaposleni","ZaposleniID", "PropertiesClass.VozniPark.PropertyClassZaposleni")]
        public int ZaposleniID
        {
            get
            {
                return zaposleniID;
            }
            set
            {
                zaposleniID = value;
            }
        }

        [DisplayName("Predjena kilometraza")]
        [SqlName("PredjenaKilometraza")]
        public int PredjenaKilometraza
        {
            get
            {
                return predjenaKilometraza;
            }
            set
            {
                predjenaKilometraza = value;
            }
        }
        [DisplayName("Datum zaduzenja")]
        [SqlName("DatumZaduzenja")]
        public DateTime DatumZaduzenja
        {
            get
            {
                return datumZaduzenja;
            }
            set
            {
                datumZaduzenja = value;
            }
        }

        [DisplayName("Datum razduzenja")]
        [SqlName("DatumRazduzenja")]
        public DateTime DatumRazduzenja
        {
            get
            {
                return datumRazduzenja;
            }
            set
            {
                datumRazduzenja = value;
            }
        }
        [DisplayName("Planirano razduzenje")]
        [SqlName("PlaniranoRazduzenje")]
        public DateTime PlaniranoRazduzenje
        {
            get
            {
                return planiranoRazduzenje;
            }
            set
            {
                planiranoRazduzenje = value;
            }
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

        public string GetDeleteQuery()
        {
            return "delete from dbo.Zaduzenja where ZaduzenjaID = @ZaduzenjaID";
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

        public string GetInsertQuery()
        {
            return "insert into dbo.Zaduzenja (VozilaID,ZaposleniID,PredjenaKilometraza,DatumZaduzenja,DatumRazduzenja,PlaniranoRazduzenje) values (@ZaduzenjaID,@VozilaID,@ZaposleniID,@PredjenaKilometraza,@DatumZaduzenja,@DatumRazduzenja,@PlaniranoRazduzenje)";
        }

        public string GetSelectQuery()
        {
            return "select ZaduzenjaID,VozilaID,ZaposleniID,PredjenaKilometraza,DatumZaduzenja,DatumRazduzenja,PlaniranoRazduzenje from dbo.Zaduzenja";
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

        public string GetUpdateQuery()
        {
            return "update dbo.Zaposlenja set VozilaID = @VozilaID,ZaposleniID = @ZaposleniID,  PredjenaKilometraza = @PredjenaKilometraza, DatumZaduzenja = @DatumZaduzenja,DatumRazduzenja=@DatumRazduzenja, PlaniranoRazduzenje=@PlaniranoRazduzenje where ZaduzenjaID = @ZaduzenjaID";
        }
        #endregion
    }
}
