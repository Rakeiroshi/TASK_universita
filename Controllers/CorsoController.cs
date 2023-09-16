using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TASK_universita.DAL;
using TASK_universita.models;

namespace TASK_universita.Controllers
{
    internal class CorsoController
    {
        private IConfiguration? configurazione;

        private static CorsoController? istanza;
        public static CorsoController getIstanza()
        {
            if (istanza == null)
            {
                istanza = new CorsoController();

                ConfigurationBuilder builder = new ConfigurationBuilder();
                builder.SetBasePath(Directory.GetCurrentDirectory());
                builder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: false);

                istanza.configurazione = builder.Build();
            }
            return istanza;
        }
        private CorsoController()
        {
            /* serve per non essere bucati  */
        }
        public void stampaCorso()
        {
            CorsoDAL corDal = new CorsoDAL(configurazione);
            List<Corso> elenco = corDal.findAll();

            foreach (Corso oggetto in elenco)
            {
                Console.WriteLine(oggetto);
            }
        }
        public void cercaCorso(int varId)
        {
            CorsoDAL corDal = new CorsoDAL(configurazione);

            Console.WriteLine(corDal.findById(varId));
        }
        public void inserisciCorso(string varTitolo, string varCodice, int varCrediti)
        {
            CorsoDAL corDal = new CorsoDAL(configurazione);

            Corso cor = new Corso()
            {
                Titolo = varTitolo,
                Codice = varCodice,
                Crediti = varCrediti
            };

            if (corDal.insert(cor))
                Console.WriteLine("Corso inserito correttamente");
            else
                Console.WriteLine("Porca pupazza, qualcosa è andato storto");
        }
        public void eliminaCorso(int corsoId)
        {
            CorsoDAL corDal = new CorsoDAL(configurazione);

            if (corDal.delete(corsoId))
                Console.WriteLine("Corso eliminato correttamente");
            else
                Console.WriteLine("Porca pupazza, qualcosa è andato storto");
        }
    }
}
