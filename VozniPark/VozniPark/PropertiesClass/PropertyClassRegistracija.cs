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
  public  class PropertyClassRegistracija:PropertyInterface
    {
        #region Atributi


      
        //[PrimaryKey]
        //[DisplayName("Vozilo ID")]
        //[SqlNameAttribute("VoziloID")]
        //[LookupKey]
        //public int VoziloID { get; set; }

        [ForeignKeyAttribute("dbo.Model", "ModelID", "VozniPark.PropertiesClass.PropertyClassModel")]
        [DisplayName("Model ID")]
        [SqlNameAttribute("ModelID")]
        [LookupValue]
        [ForeignField]
        public int ModelID { get; set; }


        [DisplayName("Godina proizvodnje")]
        [SqlNameAttribute("GodinaProizvodnje")]
        [ForeignField]
        public int GodinaProizvodnje { get; set; }

        [DisplayName("Kilometraza")]
        [SqlNameAttribute("Kilometraza")]
        [ForeignField]
        public int Kilometraza { get; set; }

        [DisplayName("Boja")]
        [SqlNameAttribute("Boja")]
        [ForeignField]
        public string Boja { get; set; }

        [DisplayName("Broj vrata")]
        [SqlNameAttribute("BrojVrata")]
        [ForeignField]
        public int BrojVrata { get; set; }

        [DisplayName("Dostupnost")]
        [SqlNameAttribute("Dostupnost")]
        [ForeignField]
        public bool Dostupnost { get; set; }

        [PrimaryKey]
        [DisplayName("RegistracijaID")]
        [SqlNameAttribute("RegistracijaID")]
        public int RegistracijaID { get; set; }

        
        [DisplayName("Registarski broj")]
        [SqlNameAttribute("RegistracijskiBroj")]
        public string RegistarskiBroj { get; set; }


        [DisplayName("Datum registracije")]
        [SqlNameAttribute("DatumRegistracije")]
        [DateTime]
        public DateTime DatumRegistracije { get; set; }

        [DisplayName("Datum isteka registracije")]
        [SqlNameAttribute("DatumIstekaRegistracije")]
        [DateTime]
        public DateTime DatumIstekaRegistracije { get; set; }


        

       
        [DisplayName("Cijena")]
        [SqlNameAttribute("Cijena")]
        public double Cijena { get; set; }



        [ForeignKey("dbo.Vozila", "VoziloID", "VozniPark.PropertiesClass.PropertyClassVozila")]
        [DisplayName("VoziloID")]
        [SqlNameAttribute("VoziloID")]
        public int VoziloID { get; set; }
        //[ForeignKey("dbo.Vozila","VoziloID", "VozniPark.PropertiesClass.PropertyClassVozila")]
        //[DisplayName("VoziloID")]
        //[SqlNameAttribute("VoziloID")]
        //public int VoziloID { get; set; }

        #endregion


        #region query
        public string GetSelectQuery()
        {
            return @"SELECT 
                    v.ModelID,
                    v.GodinaProizvodnje,
                    v.Kilometraza,
                    v.Boja,
                    v.BrojVrata
                    ,v.Dostupnost,
                    r.RegistracijaID,
                    r.RegistracijskiBroj,
                    r.DatumRegistracije,
                    r.DatumIstekaRegistracije,
                    r.Cijena,
                    v.VoziloID
                    FROM Vozila v
                    left JOIN Registracija r
                    ON v.VoziloID=r.VoziloID
                    WHERE r.DatumIstekaRegistracije<GETDATE() OR r.RegistracijaID is NULL";
        }

        public string GetInsertQuery()
        {
            return @"Insert Into dbo.Vozila (RegistracijskiBroj,DatumRegistracije,DatumIstekaRegistracije,Cijena,VoziloID)values(@RegistracijskiBroj,@DatumRegistracije,@DatumIstekaRegistracije,@Cijena,@VoziloID)";
        }

        public string GetUpdateQuery()
        {
            return @"Update  dbo.Registracija SET RegistarskiBroj=@RegistarskiBroj ,
                           DatumRegistracije=@DatumRegistracije,
                            DatumIstekaRegistracije=@DatumIstekaRegistracije,
                            Cijena=@Cijena, 
                           
                            VoziloID=@VoziloID

                                
                        where RegistracijaID=@RegistracijaID";
        }

        public string GetDeleteQuery()
        {
            return @" DELETE FROM dbo.Registracija WHERE RegistracijaID=@RegistracijaID";
        }

        #endregion



        #region Parametri
        public List<SqlParameter> GetDeleteParameters()
        {
            List<SqlParameter> list = new List<SqlParameter>();


            {
                SqlParameter parameter = new SqlParameter("@RegistracijaID", System.Data.SqlDbType.Int);
                parameter.Value = RegistracijaID;
                list.Add(parameter);
            }
            return list;
        }



        public List<SqlParameter> GetInsertParameters()
        {
            List<SqlParameter> list = new List<SqlParameter>();


            {
                SqlParameter parameter = new SqlParameter("@RegistracijskiBroj", System.Data.SqlDbType.NVarChar);
                parameter.Value = RegistarskiBroj;
                list.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@DatumRegistracije", System.Data.SqlDbType.DateTime);
                parameter.Value = DatumRegistracije;
                list.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@DatumIstekaRegistracije", System.Data.SqlDbType.DateTime);
                parameter.Value = DatumIstekaRegistracije;
                list.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@Cijena", System.Data.SqlDbType.Decimal);
                parameter.Value = Cijena;
                list.Add(parameter);
            }
           
            {
                SqlParameter parameter = new SqlParameter("@VoziloID", System.Data.SqlDbType.Int);
                parameter.Value = VoziloID;
                list.Add(parameter);
            }
            return list;
        }





        public List<SqlParameter> GetUpdateParameters()
        {
            List<SqlParameter> list = new List<SqlParameter>();
            {
                SqlParameter parameter = new SqlParameter("@RegistracijaID", System.Data.SqlDbType.Int);
                parameter.Value = RegistracijaID;
                list.Add(parameter);
            }

            {
                SqlParameter parameter = new SqlParameter("@RegistracijskiBroj", System.Data.SqlDbType.NVarChar);
                parameter.Value = RegistarskiBroj;
                list.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@DatumRegistracije", System.Data.SqlDbType.DateTime);
                parameter.Value = DatumRegistracije;
                list.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@DatumIstekaRegistracije", System.Data.SqlDbType.DateTime);
                parameter.Value = DatumIstekaRegistracije;
                list.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@Cijena", System.Data.SqlDbType.Decimal);
                parameter.Value = Cijena;
                list.Add(parameter);
            }

            {
                SqlParameter parameter = new SqlParameter("@VoziloID", System.Data.SqlDbType.Int);
                parameter.Value = VoziloID;
                list.Add(parameter);
            }
            return list;
        }

        #endregion

    }
}
