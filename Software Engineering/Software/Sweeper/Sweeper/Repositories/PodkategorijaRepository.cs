using DBLayer;
using Sweeper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweeper.Repositories
{
    public class PodkategorijaRepository
    {

        public static Podkategorija DohvatiPodkategoriju(int id)
        {
            Podkategorija podkategorija = null;
            string sql = $"SELECT * FROM Podkategorija WHERE IdPodkategorija = {id}";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            if (reader.HasRows)
            {
                reader.Read();
                podkategorija = CreateObject(reader);
                reader.Close();
            }

            DB.CloseConnection();
            return podkategorija;
        }

        internal static List<Podkategorija> DohvatiPodkategorije(int idKategorije)
        {
            List<Podkategorija> listaPodakategorija = new List<Podkategorija>();
            string sql = $"SELECT * FROM Podkategorija WHERE IdKategorije = {idKategorije}";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            while (reader.Read())
            {
                Podkategorija podkategorija = CreateObject(reader);
                listaPodakategorija.Add(podkategorija);
            }

            reader.Close();
            DB.CloseConnection();
            if (listaPodakategorija != null)
            {
                return listaPodakategorija;
            }
            else
            {
                return null;
            }
        }

        internal static Podkategorija DohvatiPodkategorijuPremaNazivu(object nazivPodkategorije)
        {
            string sql = $"SELECT * FROM Podkategorija WHERE NazivPodkategorije = '{nazivPodkategorije}'";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            Podkategorija podkategorija = null;
            if (reader.HasRows == true)
            {
                reader.Read();
                podkategorija = CreateObject(reader);
                reader.Close();
            }
            DB.CloseConnection();
            return podkategorija;
        }

        private static Podkategorija CreateObject(System.Data.SqlClient.SqlDataReader reader)
        {

            int id = int.Parse(reader["IdPodkategorija"].ToString());
            string podkategorije = reader["NazivPodkategorije"].ToString();
            int idKategorije = int.Parse(reader["IdKategorije"].ToString());

            var podkategorija = new Podkategorija
            {
                IdPodkategorija = id,
                NazivPodkategorije = podkategorije,
                IdKategorije = idKategorije
            };

            return podkategorija;
        }
    }
}
