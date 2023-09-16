using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TASK_universita.DAL;
using TASK_universita.models;

namespace TASK_universita.Controllers
{
    internal class StudenteController
    {
        private IConfiguration? configurazione;

        private static StudenteController? istanza;
        public static StudenteController getIstanza()
        {
            if (istanza == null)
            {
                istanza = new StudenteController();

                ConfigurationBuilder builder = new ConfigurationBuilder();
                builder.SetBasePath(Directory.GetCurrentDirectory());
                builder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: false);

                istanza.configurazione = builder.Build();
            }
            return istanza;
        }
        private StudenteController()
        {
            /* serve per non essere bucati  */
        }
        public void stampaStudenti()
        {
            StudenteDAL stuDal = new StudenteDAL(configurazione);
            List<Studente> elenco = stuDal.findAll();

            foreach(Studente oggetto in elenco)
            {
                Console.WriteLine(oggetto);
            }
        }   
        public void cercaStudente(int varId)
        {
            StudenteDAL stuDal = new StudenteDAL(configurazione);

            Console.WriteLine(stuDal.findById(varId));
        }
        public void inserisciStudente(string varNome, string varCognome, string varMatricola)
        {
            StudenteDAL stuDal = new StudenteDAL(configurazione);

            Studente stu = new Studente()
            {
                Nome = varNome,
                Cognome = varCognome,
                Matricola = varMatricola
            };

            if (stuDal.insert(stu))
                Console.WriteLine("Studente inserito correttamente");
            else
                Console.WriteLine("Porca pupazza, qualcosa è andato storto");
        }
    }
}
