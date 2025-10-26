using DBLayer;
using Sweeper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweeper.Repositories
{
    public static class ZaposlenikRepository
    {

        public static Zaposlenik DohvatiZaposlenika(int id)
        {
            string sql = $"SELECT * FROM Zaposlenik WHERE IdZaposlenika = {id}";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            Zaposlenik zaposlenik = null;
            if (reader.HasRows == true)
            {
                reader.Read();
                zaposlenik = CreateObject(reader);
                reader.Close();
            }
            DB.CloseConnection();
            return zaposlenik;
        }

        public static List<Zaposlenik> DohvatiZaposlenike()
        {
            List<Zaposlenik> zaposlenici = new List<Zaposlenik>();

            string sql = "SELECT * FROM Zaposlenik";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            while (reader.Read())
            {
                Zaposlenik zaposlenik = CreateObject(reader);
                zaposlenici.Add(zaposlenik);
            }

            reader.Close();
            DB.CloseConnection();

            return zaposlenici;
        }

        public static object DohvatiZaposlenikaPremaImenu(object nazivZaposlenika)
        {
            string sql = $"SELECT * FROM Zaposlenik WHERE Ime+' '+Prezime = '{nazivZaposlenika}'";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            Zaposlenik zaposlenik = null;
            if (reader.HasRows == true)
            {
                reader.Read();
                zaposlenik = CreateObject(reader);
                reader.Close();
            }
            DB.CloseConnection();
            return zaposlenik;
        }

        private static Zaposlenik CreateObject(System.Data.SqlClient.SqlDataReader reader)
        {
            int idZaposlenika = int.Parse(reader["IdZaposlenika"].ToString());
            string ime = reader["Ime"].ToString();
            string prezime = reader["Prezime"].ToString();
            int idUloga = int.Parse(reader["IdUloga"].ToString());
            var zaposlenik = new Zaposlenik
            {
                Id = idZaposlenika,
                Ime = ime,
                Prezime = prezime,
                IdUloga = idUloga
            };

            return zaposlenik;
        }
    }
}
