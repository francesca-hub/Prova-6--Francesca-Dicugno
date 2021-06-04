using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova_6__Francesca_Dicugno
{
    static class DbManagerConnectedMode
    {
        const string connectionString = @"Data Source= (localdb)\MSSQLLocalDB;" +
                                          "Initial Catalog = ProvaAgenti;" +
                                          "Integrated Security=true;";

        // creo un metodo per la connessione
        public static void Connessione(out SqlConnection connection, out SqlCommand cmd)
        {
            connection = new SqlConnection(connectionString);
            //apro la connessione
            connection.Open();
            //creo il comando
            cmd = new SqlCommand();
            //gli associo la connesione 
            cmd.Connection = connection;
            cmd.CommandType = System.Data.CommandType.Text;
        }

        internal static List<Agente> GetAllAgenti()
        {
            Connessione(out SqlConnection connection, out SqlCommand cmd);
            cmd.CommandText = "select * from dbo.Agente;";
            //eseguo il comando
            SqlDataReader reader = cmd.ExecuteReader();
            List<Agente> Agenti = new List<Agente>();
            Console.WriteLine("Ecco la lista degli agenti:");
            while (reader.Read())
            {
                int id = (int)reader[0];
                string nome = (string)reader[1];
                string cognome = (string)reader[2];
                string codicefiscale = (string)reader[3];
                string area = (string)reader[4];
                int annoinizio = (int)reader[5];

                Agente agente1 = new Agente(nome, cognome, codicefiscale, area, annoinizio);
                Agenti.Add(agente1);

                //  Console.WriteLine($"Nome: {nome} - Cognome: {cognome} - Codice fiscale:{codicefiscale} - Area geografica servizio: {areaservizio} - Anno inizio servizio: {annoinizioservizio}");

            }
            return Agenti;
        }

        internal static List<Agente> GetAgenteperArea(string arearichiesta)
        {

            // Console.WriteLine("Inserire area geografica");
            // string areageo = Console.ReadLine();

            Connessione(out SqlConnection connection, out SqlCommand cmd);
            cmd.CommandText = "select * from dbo.Agente where AreaGeografica = @AreaGeografica;";
            cmd.Parameters.AddWithValue("@AreaGeografica", arearichiesta);

            SqlDataReader reader = cmd.ExecuteReader();
            List<Agente> Agenti = new List<Agente>();
            while (reader.Read())
            {
                int id = (int)reader[0];
                string nome = (string)reader[1];
                string cognome = (string)reader[2];
                string codicefiscale = (string)reader[3];
                string area = (string)reader[4];
                int annoinizio = (int)reader[5];

                Agente agente1 = new Agente(nome, cognome, codicefiscale, area, annoinizio);
                Agenti.Add(agente1);
            }
            return Agenti;

        }

        internal static void AddAgente(Agente agente)
        {
            Connessione(out SqlConnection connection, out SqlCommand cmd);
            cmd.CommandText = "insert into dbo.Agenti values(@Nome, @Cognome, @CodiceFiscale, @AreaGeografica, @AnnoInizioServizio)";
            cmd.Parameters.AddWithValue("@Nome", agente.Nome);
            cmd.Parameters.AddWithValue("@Cognome", agente.Cognome);
            cmd.Parameters.AddWithValue("@CodiceFiscale", agente.CodiceFiscale);
            cmd.Parameters.AddWithValue("@AreaGeografica", agente.CodiceFiscale);
            cmd.Parameters.AddWithValue("@AnnoInizioServizio", agente.AnnoInizioServizio);

            cmd.ExecuteNonQuery();

            connection.Close();
        }

        internal static bool VerificaEsistenzaAgente(string codicefiscale)
        {

            {
                Connessione(out SqlConnection connection, out SqlCommand cmd);


                cmd.CommandText = "select * from dbo.Agenti where CodiceFiscale = @CodiceFiscale";
                cmd.Parameters.AddWithValue("@CodiceFiscale", codicefiscale);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                    return true;
                connection.Close();
                return false;
            }
        }
    }
}
