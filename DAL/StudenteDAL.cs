using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TASK_universita.models;


namespace TASK_universita.DAL
{
    internal class StudenteDAL : IDal<Studente>
    {
        private string? stringaConnessione;

        public StudenteDAL(IConfiguration? configurazione)
        {
            if (configurazione != null)
                stringaConnessione = configurazione.GetConnectionString("DatabaseLocale");
        }

        public List<Studente> findAll()
        {
            List<Studente> elenco = new List<Studente>();

            using (SqlConnection connessione = new SqlConnection(stringaConnessione))
            {
                string query = "SELECT studenteID,nome, cognome, matricola FROM studente;";
                SqlCommand comando = new SqlCommand(query, connessione);

                connessione.Open();

                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Studente studente = new Studente()
                    {
                        Id = Convert.ToInt32(reader[0]),
                        Nome = reader[1].ToString(),
                        Cognome = reader[2].ToString(),
                        Matricola = reader[3].ToString(),
                    };

                    elenco.Add(studente);
                }

                connessione.Close();
            }

            return elenco;
        }

        public Studente? findById(int id)
        {
            using (SqlConnection connessione = new SqlConnection(stringaConnessione))
            {
                string query = "SELECT studenteID,nome, cognome, matricola FROM Studente WHERE studenteID = @varId;";
                SqlCommand comando = new SqlCommand();
                comando.CommandText = query;
                comando.Parameters.AddWithValue("@varId", id);
                comando.Connection = connessione;

                connessione.Open();

                SqlDataReader reader = comando.ExecuteReader();

                try
                {
                    reader.Read();

                    Studente studente = new Studente()
                    {
                        Id = Convert.ToInt32(reader[0]),
                        Nome = reader[1].ToString(),
                        Cognome = reader[2].ToString(),
                        Matricola = reader[3].ToString(),
                    };

                    connessione.Close();
                    return studente;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    connessione.Close();
                    return null;
                }

            }
        }

        public bool insert(Studente g)
        {
            using (SqlConnection connessione = new SqlConnection(stringaConnessione))
            {
                string query = "INSERT INTO Studente(nome, cognome, matricola) VALUES (@varNome, @varCognome, @varMatricola);";
                SqlCommand comando = new SqlCommand();
                comando.CommandText = query;
                comando.Parameters.AddWithValue("@varNome", g.Nome);
                comando.Parameters.AddWithValue("@varCognome", g.Cognome);
                comando.Parameters.AddWithValue("@varMatricola", g.Matricola);
                comando.Connection = connessione;

                connessione.Open();

                int affRows = comando.ExecuteNonQuery();

                if (affRows > 0)
                    return true;

                return false;
            }
        }
        public bool delete(int id)
        {
            using (SqlConnection connessione = new SqlConnection(stringaConnessione))
            {
                string query = "DELETE FROM Studente WHERE studenteID = @varId";
                SqlCommand comando = new SqlCommand();
                comando.CommandText = query;
                comando.Parameters.AddWithValue("@varId", id);
                comando.Connection = connessione;

                connessione.Open();

                int affRows = comando.ExecuteNonQuery();

                if (affRows > 0)
                    return true;

                return false;
            }
        }


        public bool update(Studente g)
        {
            using (SqlConnection connessione = new SqlConnection(stringaConnessione))
            {
                string query = $"UPDATE Studente SET " +
                                    $"Nome = @varNome, " +
                                    $"Cognome = @varCognome, " +
                                    $"Matricola = @varMatricola " +
                                $"WHERE nazioniID = @varId";
                SqlCommand comando = new SqlCommand();
                comando.CommandText = query;
                comando.Parameters.AddWithValue("@varNome", g.Nome);
                comando.Parameters.AddWithValue("@varCognome", g.Cognome);
                comando.Parameters.AddWithValue("@varMatricola", g.Matricola);
                comando.Parameters.AddWithValue("@varId", g.Id);
                comando.Connection = connessione;
                connessione.Open();

                int affRows = comando.ExecuteNonQuery();

                if (affRows > 0)
                    return true;

                return false;
            }
        }

        public Studente? findByMatricola(string matricola)
        {
            using (SqlConnection connessione = new SqlConnection(stringaConnessione))
            {
                string query = "SELECT studenteID,nome, cognome, matricola FROM Studente WHERE matricola = @varMatricola;";
                SqlCommand comando = new SqlCommand();
                comando.CommandText = query;
                comando.Parameters.AddWithValue("@varMatricola", matricola);
                comando.Connection = connessione;

                connessione.Open();

                SqlDataReader reader = comando.ExecuteReader();

                try
                {
                    reader.Read();

                    Studente studente = new Studente()
                    {
                        Id = Convert.ToInt32(reader[0]),
                        Nome = reader[1].ToString(),
                        Cognome = reader[2].ToString(),
                        Matricola = reader[3].ToString(),
                    };

                    connessione.Close();
                    return studente;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    connessione.Close();
                    return null;
                }

            }
        }

        List<Studente> IDal<Studente>.FindAll()
        {
            throw new NotImplementedException();
        }
    }
}
