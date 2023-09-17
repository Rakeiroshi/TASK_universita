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
    internal class IscrizioneDAL : IDal<Iscrizione>
    {
        private string? stringaConnessione;

        public IscrizioneDAL(IConfiguration? configurazione)
        {
            if (configurazione != null)
                stringaConnessione = configurazione.GetConnectionString("DatabaseLocale");
        }

        public bool delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Iscrizione> FindAll()
        {
            throw new NotImplementedException();
        }

        public Iscrizione? findById(int id)
        {
            throw new NotImplementedException();
        }

        public bool insert(Iscrizione g)
        {
            throw new NotImplementedException();
        }

        public bool update(Iscrizione g)
        {
            throw new NotImplementedException();
        }
        public bool IscriviStudente(int studenteId, int corsoId)
        {
            using (SqlConnection connessione = new SqlConnection(stringaConnessione))
            {
                string query = "INSERT INTO Studente_Corso(StudenteRIF, CorsoRIF) VALUES (@varStuId, @varCorId);";
                SqlCommand comando = new SqlCommand();
                comando.CommandText = query;
                comando.Parameters.AddWithValue("@varStuId", studenteId);
                comando.Parameters.AddWithValue("@varCorId", corsoId);
                comando.Connection = connessione;
                connessione.Open();

                int affRows = comando.ExecuteNonQuery();

                if (affRows > 0)
                    return true;

                return false;
            }
        }
    }
}

