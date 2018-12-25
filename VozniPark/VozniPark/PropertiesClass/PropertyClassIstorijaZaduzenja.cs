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
    class PropertyClassIstorijaZaduzenja : PropertyInterface
    {
        #region properties
        [PrimaryKey]
        [DisplayName("Istorija zaduzenja ID")]
        [SqlNameAttribute("IstorijaZaduzenjaID")]
        public int IstorijaZaduzenjaID { get; set; }

        [DisplayName("Zaposleni ID")]
        [SqlNameAttribute("ZaposleniID")]
        public int ZaposleniID { get; set; }

        [DisplayName("Zaposleni")]
        [SqlName("Zaposleni")]   
        public string Zaposleni { get; set; }

        [DisplayName("Datum zaduzenja")]
        [SqlName("DatumZaduzenja")]
        public DateTime DatumZaduzenja { get; set; }
     
        [DisplayName("Datum razduzenja")]
        [SqlName("DatumRazduzenja")]
        public DateTime DatumRazduzenja { get; set; }

        public List<SqlParameter> GetDeleteParameters()
        {
            throw new NotImplementedException();
        }

        public string GetDeleteQuery()
        {
            throw new NotImplementedException();
        }

        public List<SqlParameter> GetInsertParameters()
        {
            throw new NotImplementedException();
        }

        public string GetInsertQuery()
        {
            throw new NotImplementedException();
        }

        public string GetLookupQuery()
        {
            throw new NotImplementedException();
        }


        #endregion

        #region queries

        public string GetSelectQuery()
        {
            return @"SELECT iz.IstorijaZaduzenjaID, 
                            iz.ZaposleniID,
                            z.Ime+ ' '+  z.Prezime AS [Zaposleni],
                            iz.DatumZaduzenja, 
                            iz.DatumRazduzenja
                            FROM dbo.IstorijaZaduzenja iz
	                        JOIN dbo.Zaposleni z
	                        ON z.ZaposleniID = iz.ZaposleniID";

             /*return @"SELECT IstorijaZaduzenjaID,ZaposleniID, DatumZaduzenja, DatumRazduzenja FROM IstorijaZaduzenja";*/
        }

        public List<SqlParameter> GetUpdateParameters()
        {
            throw new NotImplementedException();
        }

        public string GetUpdateQuery()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region parameters
        #endregion
    }
}
