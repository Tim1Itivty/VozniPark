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
  public  class PropertyClassRegistracija
    {
        #region Atributi
        [PrimaryKey]
        [DisplayName("Registracija ID")]
        [SqlNameAttribute("RegistracijaID")]
        public int RegistracijaID { get; set; }

        
        [DisplayName("Registarski broj")]
        [SqlNameAttribute("RegistarskiBroj")]
        public string RegistarskiBroj { get; set; }


        [DisplayName("Datum registracije")]
        [SqlNameAttribute("DatumRegistracije")]
        public DateTime DatumRegistracije { get; set; }

        [DisplayName("Datum isteka registracije")]
        [SqlNameAttribute("DatumIstekaRegistracije")]
        public DateTime DatumIstekaRegistracije { get; set; }


        

       
        [DisplayName("Cijena")]
        [SqlNameAttribute("Cijena")]
        public double Cijena { get; set; }

        [ForeignKey("dbo.Vozila","VoziloID", "VozniPark.PropertiesClass.PropertyClassVozila")]
        [DisplayName("Vozilo id")]
        [SqlNameAttribute("VoziloID")]
        public int VoziloID { get; set; }

        #endregion


        #region query
        public string GetSelectQuery()
        {
            return @"select RegistracijaID,RegistracijskiBroj,DatumRegistracije,DatumIstekaRegistracije,Cijena,VoziloID
                    from dbo.Registracija";
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
