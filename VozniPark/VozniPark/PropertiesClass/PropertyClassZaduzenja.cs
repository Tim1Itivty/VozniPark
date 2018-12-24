﻿
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
    class PropertyClassZaduzenja : PropertyInterface
    {

        #region attributes
        [DisplayName("Zaduzenja ID")]
        [SqlName("ZaduzenjaID")]
        [PrimaryKey]
        public int ZaduzenjaID { get; set; }

        [DisplayName("Vozilo ID")]
        [SqlName("VozilaID")]
        [ForeignKey("dbo.Vozila", "VoziloID", "VozniPark.PropertiesClass.PropertyClassVozila")]
        public int VozilaID { get; set; }

        [DisplayName("Zaposleni ID")]
        [SqlName("ZaposleniID")]
        [ForeignKey("dbo.Zaposleni", "ZaposleniID", "VozniPark.PropertiesClass.PropertyClassZaposleni")]
        public int ZaposleniID { get; set; }


        [Required(AllowEmptyStrings = true)]
        [DisplayName("Predjena kilometraza")]
        [SqlName("PredjenaKilometraza")]
        public int PredjenaKilometraza { get; set; }

        [DisplayName("Datum zaduzenja")]
        [SqlName("DatumZaduzenja")]
        [DateTime]
        public DateTime DatumZaduzenja { get; set; }

        [Required(AllowEmptyStrings = true)]
        [DisplayName("Datum razduzenja")]
        [SqlName("DatumRazduzenja")]
        [DateTime]
        public DateTime DatumRazduzenja { get; set; }

        [DisplayName("Planirano razduzenje")]
        [SqlName("PlaniranoRazduzenje")]
        [DateTime]
        public DateTime PlaniranoRazduzenje { get; set; }

        [DisplayName("ModelID")]
        [SqlName("ModelID")]
        [ForeignField("")]
        public int ModelID { get; set; }

        [DisplayName("Model")]
        [SqlName("Naziv")]
        [ForeignField("Vozilo ID")]
        public string Model { get; set; }

        [DisplayName("Zaposleni")]
        [SqlName("ImeIPrezime")]
        [ForeignField("Zaposleni ID")]
        public string ImeZaposlenog { get; set; }

        #endregion


        #region queries

        public string GetDeleteQuery()
        {
            return @"delete from dbo.Zaduzenja where ZaduzenjaID = @ZaduzenjaID
                     UPDATE dbo.Vozila
                     SET Dostupnost = 'True'
                     where VoziloID = @VozilaID"; 
        }

        public string GetInsertQuery()
        {
            return @"insert into dbo.Zaduzenja (VozilaID,ZaposleniID,DatumZaduzenja,PlaniranoRazduzenje) values (@VozilaID,@ZaposleniID,@DatumZaduzenja,@PlaniranoRazduzenje)
                    
                     UPDATE dbo.Vozila
                     SET Dostupnost = 'False'
                     where VoziloID = @VozilaID";
        }

        public string GetSelectQuery()
        {
            return @"select 
                     ZaduzenjaID,
                     VozilaID,
                     m.ModelID,
                     p.Naziv + ' ' + m.Naziv as Naziv,
                     zap.ZaposleniID,
                     zap.Ime + ' ' + zap.Prezime as ImeIPrezime,
                     DatumZaduzenja,
                     PlaniranoRazduzenje,
                     DatumRazduzenja,
                     PredjenaKilometraza
                     from dbo.Zaduzenja as z
                     join dbo.Zaposleni as zap on z.ZaposleniID = zap.ZaposleniID
                     join dbo.Vozila as v on v.VoziloID = z.VozilaID
                     join dbo.Model as m on m.ModelID = v.ModelID
                     join dbo.Proizvodjac as p on m.ProizvodjacID = p.ProizvodjacID";
        }

        public string GetUpdateQuery()
        {
            return "update dbo.Zaduzenja set VozilaID = @VozilaID,ZaposleniID = @ZaposleniID,  PredjenaKilometraza = @PredjenaKilometraza, DatumZaduzenja = @DatumZaduzenja,DatumRazduzenja=@DatumRazduzenja, PlaniranoRazduzenje=@PlaniranoRazduzenje where ZaduzenjaID = @ZaduzenjaID";
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
            {
                SqlParameter parameter = new SqlParameter("VozilaID", System.Data.SqlDbType.Int);
                parameter.Value = VozilaID;
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
                SqlParameter parameter = new SqlParameter("DatumZaduzenja", System.Data.SqlDbType.DateTime);
                parameter.Value = DatumZaduzenja;
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

        public string GetLookupQuery()
        {
            throw new NotImplementedException();
        }


        #endregion
    }
}
