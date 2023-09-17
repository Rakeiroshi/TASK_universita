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
    internal class IscrizioneController
    {
        private IConfiguration? configurazione;

        private static IscrizioneController? istanza;
        public static IscrizioneController getIstanza()
        {
            if (istanza == null)
            {
                istanza = new IscrizioneController();

                ConfigurationBuilder builder = new ConfigurationBuilder();
                builder.SetBasePath(Directory.GetCurrentDirectory());
                builder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: false);

                istanza.configurazione = builder.Build();
            }
            return istanza;
        }
        private IscrizioneController()
        {
            /* serve per non essere bucati  */
        }
        public void IscriviStudente(int varStuId, int varCorId)
        {
            IscrizioneDAL iscStu = new IscrizioneDAL(configurazione);

            Iscrizione isc = new Iscrizione()
            {
                StudenteRIF = varStuId,
                CorsoRIF = varCorId
            }; 

            if (iscStu.insert(isc))
                Console.WriteLine("Studente iscritto correttamente");
            else
                Console.WriteLine("Porca pupazza, qualcosa è andato storto");
        }
    }
}