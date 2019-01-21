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
    public class PropertyClassVozila : PropertyInterface
    {
        #region Atributi
        [PrimaryKey]
        [DisplayName("Vozilo ID")]
        [SqlNameAttribute("VoziloID")]
        [LookupKey]
        public int VoziloID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Unesite ID modela!")]
        [ForeignKeyAttribute("dbo.Model", "ModelID", "VozniPark.PropertiesClass.PropertyClassModel")]
        [DisplayName("Model ID")]
        [SqlNameAttribute("ModelID")]
        public int ModelID { get; set; }

        [DisplayName("Model")]
        [SqlNameAttribute("Model")]
        [ForeignField("Model ID")]
        [LookupValue]
        public string Model { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Unesite godinu proizvodnje!")]
        [DisplayName("Godina proizvodnje")]
        [SqlNameAttribute("GodinaProizvodnje")]
        public int GodinaProizvodnje { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Unesite predjenu kilometrazu!")]
        [DisplayName("Kilometraža")]
        [SqlNameAttribute("Kilometraza")]
        public int Kilometraza { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Unesite boju!")]
        [DisplayName("Boja")]
        [SqlNameAttribute("Boja")]
        public string Boja { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Unesite boju!")]
        [DisplayName("Broj vrata")]
        [SqlNameAttribute("BrojVrata")]
        public int BrojVrata { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Unesite dostupnost!")]
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
            return @"SELECT distinct v.VoziloID,v.ModelID,p.Naziv + ' ' + m.Naziv AS Model,v.Kilometraza,
                        v.GodinaProizvodnje,v.Boja,v.BrojVrata,
                        case
                        when v.Dostupnost = 1 then 'Dostupno'
                        when v.Dostupnost = 0 then 'Nije dostupno'
                        end as Dostupnost,r.RegistracijskiBroj
                        FROM Vozila v
                        JOIN Model m 
                        ON v.ModelID=m.ModelID
                        JOIN Proizvodjac p 
                        on m.ProizvodjacID=p.ProizvodjacID
                        LEFT JOIN Registracija r 
                        ON r.VoziloID=v.VoziloID
                        where v.Obrisano = 0";
        }

        public string GetInsertQuery()
        {
            return @"Insert Into dbo.Vozila (ModelID,
                                             GodinaProizvodnje,
                                             Kilometraza,
                                             Boja,
                                             BrojVrata,
                                             Dostupnost)
                    values(@ModelID, @GodinaProizvodnje, @Kilometraza, @Boja, @BrojVrata, 'True')";
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
            return @" UPDATE dbo.Vozila SET Obrisano = 1 WHERE VoziloID=@VoziloID
                      UPDATE dbo.Registracija SET Obrisano = 1 WHERE  VoziloID=@VoziloID";
        }

        public string GetLookupQuery()
        {
            return @"select VoziloID, p.Naziv + ' ' + m.Naziv as Model, GodinaProizvodnje, Boja
                    from dbo.Vozila as v
                    join dbo.Model as m on v.ModelId = m.ModelID
                    join dbo.Proizvodjac as p on m.ProizvodjacID = p.ProizvodjacID
                    where v.Dostupnost = 'True' AND VoziloID in (SELECT r.VoziloID FROM dbo.Registracija as r WHERE r.DatumIstekaRegistracije > GETDATE()) ";
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
