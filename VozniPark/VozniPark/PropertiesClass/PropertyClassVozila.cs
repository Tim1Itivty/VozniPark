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
    public class PropertyClassVozila : PropertyInterface
    {
        #region Atributi
        [PrimaryKey]
        [DisplayName("Vozilo ID")]
        [SqlNameAttribute("VoziloID")]
        [LookupKey]
        public int VoziloID { get; set; }

        [ForeignKeyAttribute("dbo.Model", "ModelID", "VozniPark.PropertiesClass.PropertyClassModel")]
        [DisplayName("Model ID")]
        [SqlNameAttribute("ModelID")]
        public int ModelID { get; set; }

        [DisplayName("Proizvodjac")]
        [SqlName("NazivProizvodjaca")]
        [ForeignField]
        public string NazivProizvodjaca { get; set; }

        [DisplayName("Model")]
        [SqlName("NazivModela")]
        [ForeignField]
        public string Naziv { get; set; }

        

        //[DisplayName("Model")]
        //[SqlNameAttribute("Model")]
        //[ForeignField]
        //[LookupValue]
        //public int Model { get; set; }




        [DisplayName("Godina proizvodnje")]
        [SqlNameAttribute("GodinaProizvodnje")]
        public int GodinaProizvodnje { get; set; }

        [DisplayName("Kilometraza")]
        [SqlNameAttribute("Kilometraza")]
        public int Kilometraza { get; set; }

        [DisplayName("Boja")]
        [SqlNameAttribute("Boja")]
        public string Boja { get; set; }

        [DisplayName("Broj vrata")]
        [SqlNameAttribute("BrojVrata")]
        public int BrojVrata { get; set; }

        [DisplayName("Dostupnost")]
        [SqlNameAttribute("Dostupnost")]
        public bool Dostupnost { get; set; }

        [DisplayName("Registarski broj")]
        [SqlNameAttribute("RegistracijskiBroj")]
        [ForeignField]
        public string RegistarskiBroj { get; set; }


        #endregion


        #region query
        public string GetSelectQuery()
        {
            return @"SELECT v.VoziloID,v.ModelID,p.Naziv as NazivProizvodjaca,m.Naziv AS NazivModela,v.Kilometraza,
                        v.GodinaProizvodnje,v.Boja,v.BrojVrata,v.Dostupnost,r.RegistracijskiBroj
                        FROM Vozila v
                        LEFT JOIN Model m 
                        ON v.ModelID=m.ModelID
                        LEFT JOIN Proizvodjac p 
                        on m.ProizvodjacID=p.ProizvodjacID
                        LEFT JOIN Registracija r 
                        ON r.VoziloID=v.VoziloID";
        }

        public string GetInsertQuery()
        {
            return @"Insert Into dbo.Vozila (ModelID,
                                             GodinaProizvodnje,
                                             Kilometraza,
                                             Boja,
                                             BrojVrata,
                                             Dostupnost)
                    values(@ModelID, @GodinaProizvodnje, @Kilometraza, @Boja, @BrojVrata, @Dostupnost)";
        }

        public string GetUpdateQuery()
        {
            return @"Update  dbo.Vozila SET ModelID=@ModelID ,
                           GodinaProizvodnje=@GodinaProizvodnje,
                            Kilometraza=@Kilometraza,
                            Boja=@Boja, 
                            BrojVrata=@BrojVrata,
                            Dostupnost=@Dostupnost

                                
                        where VoziloID=@VoziloID";
        }

        public string GetDeleteQuery()
        {
            return @" DELETE FROM dbo.Vozila WHERE VoziloID=@VoziloID";
        }

        public string GetLookupQuery()
        {
            return @"select VoziloID, p.Naziv + ' ' + m.Naziv as Model, GodinaProizvodnje, Boja
                    from dbo.Vozila as v
                    join dbo.Model as m on v.ModelId = m.ModelID
                    join dbo.Proizvodjac as p on m.ProizvodjacID = p.ProizvodjacID
                    where v.Dostupnost = 1";
        }
        #endregion



        #region Parametri
        public List<SqlParameter> GetDeleteParameters()
        {
            List<SqlParameter> list = new List<SqlParameter>();


            {
                SqlParameter parameter = new SqlParameter("@VoziloID", System.Data.SqlDbType.Int);
                parameter.Value = VoziloID;
                list.Add(parameter);
            }
            return list;
        }

      

        public List<SqlParameter> GetInsertParameters()
        {
            List<SqlParameter> list = new List<SqlParameter>();
            

            {
                SqlParameter parameter = new SqlParameter("@ModelID", System.Data.SqlDbType.Int);
                parameter.Value = ModelID;
                list.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@GodinaProizvodnje", System.Data.SqlDbType.Int);
                parameter.Value = GodinaProizvodnje;
                list.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@Kilometraza", System.Data.SqlDbType.Int);
                parameter.Value = Kilometraza;
                list.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@Boja", System.Data.SqlDbType.NVarChar);
                parameter.Value = Boja;
                list.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@BrojVrata", System.Data.SqlDbType.SmallInt);
                parameter.Value = BrojVrata;
                list.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@Dostupnost", System.Data.SqlDbType.Bit);
                parameter.Value = Dostupnost;
                list.Add(parameter);
            }
            
            return list;
        }

        

       

        public List<SqlParameter> GetUpdateParameters()
        {
            List<SqlParameter> list = new List<SqlParameter>();
            {
                SqlParameter parameter = new SqlParameter("@VoziloID", System.Data.SqlDbType.Int);
                parameter.Value = VoziloID;
                list.Add(parameter);
            }

            {
                SqlParameter parameter = new SqlParameter("@ModelID", System.Data.SqlDbType.Int);
                parameter.Value = ModelID;
                list.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@GodinaProizvodnje", System.Data.SqlDbType.Int);
                parameter.Value = GodinaProizvodnje;
                list.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@Kilometraza", System.Data.SqlDbType.Int);
                parameter.Value = Kilometraza;
                list.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@Boja", System.Data.SqlDbType.NVarChar);
                parameter.Value = Boja;
                list.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@BrojVrata", System.Data.SqlDbType.SmallInt);
                parameter.Value = BrojVrata;
                list.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@Dostupnost", System.Data.SqlDbType.Bit);
                parameter.Value = Dostupnost;
                list.Add(parameter);
            }
            
            return list;
        }

        

        #endregion

    }
}
