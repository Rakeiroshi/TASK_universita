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
    internal class CorsoDAL : IDal<Corso>
    {
        private string? stringaConnessione;

        public CorsoDAL(IConfiguration? configurazione)
        {
            if (configurazione != null)
                stringaConnessione = configurazione.GetConnectionString("DatabaseLocale");
        }

        public List<Corso> findAll()
        {
            List<Corso> elenco = new List<Corso>();

            using (SqlConnection connessione = new SqlConnection(stringaConnessione))
            {
                string query = "SELECT corsoID, titolo, codice, crediti FROM corso;";
                SqlCommand comando = new SqlCommand(query, connessione);

                connessione.Open();

                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Corso corso = new Corso()
                    {
                        Id = Convert.ToInt32(reader[0]),
                        Titolo = reader[1].ToString(),
                        Codice = reader[2].ToString(),
                        Crediti = Convert.ToInt32(reader[3]),
                    };

                    elenco.Add(corso);
                }

                connessione.Close();
            }

            return elenco;
        }

        public Corso? findById(int id)
        {
            using (SqlConnection connessione = new SqlConnection(stringaConnessione))
            {
                string query = "SELECT corsoID, titolo, codice, crediti FROM corso WHERE corsoID = @varId;";
                SqlCommand comando = new SqlCommand();
                comando.CommandText = query;
                comando.Parameters.AddWithValue("@varId", id);
                comando.Connection = connessione;

                connessione.Open();

                SqlDataReader reader = comando.ExecuteReader();

                try
                {
                    reader.Read();

                    Corso corso = new Corso()
                    {
                        Id = Convert.ToInt32(reader[0]),
                        Titolo = reader[1].ToString(),
                        Codice = reader[2].ToString(),
                        Crediti = Convert.ToInt32(reader[3]),
                    };

                    connessione.Close();
                    return corso;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    connessione.Close();
                    return null;
                }

            }
        }

        public bool insert(Corso g)
        {
            using (SqlConnection connessione = new SqlConnection(stringaConnessione))
            {
                string query = "INSERT INTO Corso(titolo, codice, crediti) VALUES (@varTitolo, @varCodice, @varCrediti);";
                SqlCommand comando = new SqlCommand();
                comando.CommandText = query;
                comando.Parameters.AddWithValue("@varTitolo", g.Titolo);
                comando.Parameters.AddWithValue("@varCodice", g.Codice);
                comando.Parameters.AddWithValue("@varCrediti", g.Crediti);
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
                string query = "DELETE FROM Corso WHERE corsoID = @varId";
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


        public bool update(Corso g)
        {
            using (SqlConnection connessione = new SqlConnection(stringaConnessione))
            {
                string query = $"UPDATE Corso SET " +
                                    $"Titolo = @varTitolo, " +
                                    $"Codice = @varCodice, " +
                                    $"Crediti = @varCrediti " +
                                $"WHERE nazioniID = @varId";
                SqlCommand comando = new SqlCommand();
                comando.CommandText = query;
                comando.Parameters.AddWithValue("@varTitolo", g.Titolo);
                comando.Parameters.AddWithValue("@varCodice", g.Codice);
                comando.Parameters.AddWithValue("@varCrediti", g.Crediti);
                comando.Parameters.AddWithValue("@varId", g.Id);
                comando.Connection = connessione;
                connessione.Open();

                int affRows = comando.ExecuteNonQuery();

                if (affRows > 0)
                    return true;

                return false;
            }
        }

        List<Corso> IDal<Corso>.FindAll()
        {
            throw new NotImplementedException();
        }
    }
}
