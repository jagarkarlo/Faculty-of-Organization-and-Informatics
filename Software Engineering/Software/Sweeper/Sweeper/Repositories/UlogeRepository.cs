using Sweeper.Models;
using DBLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Sweeper.Repositories
{
    public class UlogeRepository
    {

        public static Uloge DohvatiUlogu(int id)
        {
            Uloge uloga = null;
            string sql = $"SELECT * FROM Uloge WHERE IdUloge = {id}";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            if (reader.HasRows)
            {
                reader.Read();
                uloga = CreateObject(reader);
                reader.Close();
            }

            DB.CloseConnection();
            return uloga;


        }

        public static List<Uloge> DohvatiUloge()
        {
            List<Uloge> uloge = new List<Uloge>();
            string sql = "SELECT * FROM Uloge";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            while (reader.Read())
            {
                Uloge uloga = CreateObject(reader);
                uloge.Add(uloga);
            }
            reader.Close();
            DB.CloseConnection();
            return uloge;
        }

        private static Uloge CreateObject(System.Data.SqlClient.SqlDataReader reader)
        {

            int id = int.Parse(reader["IdUloge"].ToString());
            string uloge = reader["NazivUloge"].ToString();


            var uloga = new Uloge
            {
                IdUloge = id,
                NazivUloge = uloge
            };

            return uloga;
        }
    }
}
