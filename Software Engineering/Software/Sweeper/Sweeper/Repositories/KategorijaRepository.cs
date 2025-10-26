using DBLayer;
using Sweeper.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sweeper.Repositories
{
    public class KategorijaRepository
    {
        public static Kategorija DohvatiKategoriju(int id)
        {
            string sql = $"SELECT * FROM Kategorija WHERE IdKategorija = {id}";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            Kategorija kategorija = null;
            if (reader.HasRows)
            {
                reader.Read();
                kategorija = CreateObject(reader);
            }
            reader.Close();
            DB.CloseConnection();
            return kategorija;
        }

        public static List<Kategorija> DohvatiKategorije()
        {
            List<Kategorija> kategorije = new List<Kategorija>();

            string sql = "SELECT * FROM Kategorija";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            while (reader.Read())
            {
                Kategorija kategorija = CreateObject(reader);
                kategorije.Add(kategorija);
            }

            reader.Close();
            DB.CloseConnection();
            var jedinstveneKategorije = kategorije.GroupBy(k => k.NazivKategorije)
                                  .Select(g => g.First())
                                  .ToList();
            return jedinstveneKategorije;

        }

        private static Kategorija CreateObject(System.Data.SqlClient.SqlDataReader reader)
        {
            int id = int.Parse(reader["IdKategorija"].ToString());
            string nazivKategorije = reader["NazivKategorije"].ToString();

            var kategorija = new Kategorija
            {
                IdKategorija = id,
                NazivKategorije = nazivKategorije
            };

            return kategorija;
        }

        internal static Kategorija DohvatiKategorijuPremaNazivu(object nazivKategorije)
        {
           
                string sql = $"SELECT * FROM Kategorija WHERE NazivKategorije = '{nazivKategorije}'";
                DB.OpenConnection();
                var reader = DB.GetDataReader(sql);
                Kategorija kategorija= null;
                if (reader.HasRows == true)
                {
                    reader.Read();
                    kategorija = CreateObject(reader);
                    reader.Close();
                }
                DB.CloseConnection();
                return kategorija;
            
        }
    }
}
