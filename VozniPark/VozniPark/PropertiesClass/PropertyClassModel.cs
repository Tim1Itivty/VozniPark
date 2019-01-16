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
    class PropertyClassModel : PropertyInterface
    {
        #region properties
        [DisplayName("Model ID")]
        [SqlName("ModelID")]
        [PrimaryKey]
        [LookupKey]
        public int ModelID { get; set; }

        [DisplayName("Proizvodjac")]
        [SqlName("Proizvodjac")]
        [ForeignField]
        [LookupValue]
        public int Proizvodjac { get; set; }

        [DisplayName("Proizvodjac ID")]
        [SqlName("ProizvodjacID")]
        [ForeignKey("dbo.Proizvodjac", "ProizvodjacID", "VozniPark.PropertiesClass.PropertyClassProizvodjac")]
        public int ProizvodjacID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Unesite naziv!")]
        [DisplayName("Naziv")]
        [SqlName("Naziv")]
        [LookupValue]
        public string Naziv { get; set; }

        

        
        #endregion

        #region parameters
        public List<SqlParameter> GetInsertParameters()
        {
            List<SqlParameter> list = new List<SqlParameter>();
            {
                SqlParameter parameter = new SqlParameter("@Naziv", System.Data.SqlDbType.NVarChar);
                parameter.Value = Naziv;
                list.Add(parameter);
            }

            {
                SqlParameter parameter = new SqlParameter("@ProizvodjacID", System.Data.SqlDbType.NVarChar);
                parameter.Value = ProizvodjacID;
                list.Add(parameter);
            }

            return list;

        }

        public List<SqlParameter> GetUpdateParameters()
        {
            List<SqlParameter> list = new List<SqlParameter>();
            {
                SqlParameter parameter = new SqlParameter("@ModelID", System.Data.SqlDbType.Int);
                parameter.Value = ModelID;
                list.Add(parameter);
            }

            {
                SqlParameter parameter = new SqlParameter("@Naziv", System.Data.SqlDbType.NVarChar);
                parameter.Value = Naziv;
                list.Add(parameter);
            }
            {
                SqlParameter parameter = new SqlParameter("@ProizvodjacID", System.Data.SqlDbType.Int);
                parameter.Value = ProizvodjacID;
                list.Add(parameter);
            }

            return list;
        }

        public List<SqlParameter> GetDeleteParameters()
        {
            List<SqlParameter> list = new List<SqlParameter>();
            { 
            SqlParameter parameter = new SqlParameter("@ModelID", System.Data.SqlDbType.Int);
            parameter.Value = ModelID;
            list.Add(parameter);
            }
            return list;
        }
        #endregion

        #region queries
        public string GetSelectQuery()
        {

            return @"SELECT ModelID, Naziv, ProizvodjacID FROM dbo.Model";
        }

        public string GetInsertQuery()
        {
            return @"INSERT INTO dbo.Model(Naziv, ProizvodjacID) VALUES( @Naziv, @ProizvodjacID)";
        }

        public string GetUpdateQuery()
        {
            return @"UPDATE dbo.Model SET  Naziv = @Naziv, SET ProizvodjacID = @ProizvodjacID WHERE  ModelID = @ModelID";
        }

        public string GetDeleteQuery()
        {
            return @"DELETE FROM dbo.Model WHERE ModelID = @ModelID";
        }

        public string GetLookupQuery()
        {
            return @"SELECT 
                     ModelID, 
                     p.Naziv as Proizvodjac,
                     m.Naziv
                     
                     FROM dbo.Model as m
                     JOIN dbo.Proizvodjac as p
                     on m.ProizvodjacID = p.ProizvodjacID";
        }

        #endregion

    }
}
