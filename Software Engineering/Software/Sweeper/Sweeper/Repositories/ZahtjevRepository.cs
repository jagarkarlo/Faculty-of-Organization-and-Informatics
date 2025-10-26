using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBLayer;
using Sweeper.Models;

namespace Sweeper.Repositories
{
    internal class ZahtjevRepository
    {
        public static List<Zahtjev> DohvatiZahtjeve()
        {
            List<Zahtjev> zahtjevi = new List<Zahtjev>();
            string sql = $"SELECT * FROM Zahtjev";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);

            while (reader.Read())
            {
                Zahtjev zahtjev = CreateObject(reader);
                zahtjevi.Add(zahtjev);
            }

            reader.Close();
            DB.CloseConnection();

            return zahtjevi;
        }

        private static Zahtjev CreateObject(System.Data.SqlClient.SqlDataReader reader)
        {
            int id = int.Parse(reader["Id"].ToString());
            string naziv = reader["Naziv"].ToString();

            DateTime vrijemeKreiranja = DateTime.Parse(reader["VrijemeKreiranja"].ToString());

            DateTime terminObavljanja = DateTime.Parse(reader["TerminObavljanja"].ToString());

            string potrebnoVrijemeIzvodenja = reader["PotrebnoVrijemeIzvodenja"].ToString();

            int idZaposlenika = int.Parse(reader["IdZaposlenika"].ToString());
            var zaposlenik = ZaposlenikRepository.DohvatiZaposlenika(idZaposlenika);

            int idKategorije = int.Parse(reader["IdKategorije"].ToString());
            var kategorija = KategorijaRepository.DohvatiKategoriju(idKategorije);


            int idPodkategorije = int.Parse(reader["IdPodkategorije"].ToString());
            var podkategorije = PodkategorijaRepository.DohvatiPodkategoriju(idPodkategorije);
            var zahtjev = new Zahtjev
            {
                Id = id,
                Naziv = naziv,
                VrijemeKreiranja = vrijemeKreiranja,
                TerminObavljanja = terminObavljanja,
                PotrebnoVrijemeIzvodenja = potrebnoVrijemeIzvodenja,
                IdZaposlenika = zaposlenik,
                IdKategorije = kategorija,
                IdPodkategorije = podkategorije
            };

            return zahtjev;
        }

        public static void KreirajZahtjev(string naziv,  DateTime vrijemeKreiranja, Zaposlenik zaposlenik, DateTime terminObavljanja, string potrebnoVrijemeIzvodenja, int idKategorije, int idPodkategorije)

        {
            string VrijemeKreiranjaFormatirano = vrijemeKreiranja.ToString("yyyy-MM-dd HH:mm:ss");
            string TerminObavljanjaFormatirano = terminObavljanja.ToString("yyyy-MM-dd HH:mm:ss");
            string sql = $"INSERT INTO Zahtjev ( naziv, vrijemeKreiranja, terminObavljanja, potrebnoVrijemeIzvodenja, IdZaposlenika, IdKategorije, IdPodkategorije) VALUES ('{naziv}', '{VrijemeKreiranjaFormatirano}', '{TerminObavljanjaFormatirano}', '{potrebnoVrijemeIzvodenja}', '{zaposlenik.Id}', '{idKategorije}', '{idPodkategorije}')";
            DB.OpenConnection();
            DB.ExecuteCommand(sql);
            DB.CloseConnection();
        }

        public static void AzurirajZahtjev(Zahtjev zahtjev, string naziv, DateTime vrijemeKreiranja, Zaposlenik zaposlenik, DateTime terminObavljanja, string potrebnoVrijemeIzvodenja, int idKategorije, int idPodkategorije)
        {
            string VrijemeKreiranjaFormatiran = vrijemeKreiranja.ToString("yyyy-MM-dd HH:mm:ss");
            string TerminObavljanjaFormatiran = terminObavljanja.ToString("yyyy-MM-dd HH:mm:ss");
            string sql = $"UPDATE Zahtjev SET Naziv = '{naziv}',  VrijemeKreiranja = '{VrijemeKreiranjaFormatiran}', IdZaposlenika = '{zaposlenik.Id}', TerminObavljanja = '{TerminObavljanjaFormatiran}', PotrebnoVrijemeIzvodenja = '{potrebnoVrijemeIzvodenja}', IdKategorije = '{idKategorije}', idPodkategorije = '{idPodkategorije}' WHERE Id = '{zahtjev.Id}'";

            DB.OpenConnection();
            DB.ExecuteCommand(sql);
            DB.CloseConnection();
        }

        public static void IzbrisiZahtjev(Zahtjev zahtjev)
        {
            string sql = $"DELETE FROM Zahtjev WHERE Id = '{zahtjev.Id}'";
            DB.OpenConnection();
            DB.ExecuteCommand(sql);
            DB.CloseConnection();
        }

        public static List<Zahtjev> PretražiNazivZahtjeva(string text)
        {

            List<Zahtjev> zahtjevi = new List<Zahtjev>();
            string sql = "SELECT * FROM Zahtjev WHERE Naziv like '" + text + "%'";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);

            while (reader.Read())
            {
                Zahtjev zahtjev = CreateObject(reader);
                zahtjevi.Add(zahtjev);
            }

            reader.Close();
            DB.CloseConnection();

            return zahtjevi;
        }
    }
}
