using TASK_universita.Controllers;

namespace TASK_universita
    /* 
    CR - Studente
    CR - Corso
    CR - Iscrizioni
    inviare a: g.pace@braintech.app
     */
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* STUDENTI */
            //Stampare gli studenti
            Console.WriteLine("**************************************************");
            Console.WriteLine("Studenti presenti nel Database");
            Console.WriteLine("**************************************************");
            StudenteController.getIstanza().stampaStudenti();
            Console.WriteLine("**************************************************\n");

            //Inserire uno studente
            //StudenteController.getIstanza().inserisciStudente("nome", "Cognome", "Matricola"); 

            /* CORSI */
            Console.WriteLine("**************************************************");
            Console.WriteLine("Corsi presenti nel Database");
            Console.WriteLine("**************************************************");
            CorsoController.getIstanza().stampaCorso();
            Console.WriteLine("**************************************************");
            //CorsoController.getIstanza().inserisciCorso("Titolo", "Codice", 2);
            //CorsoController.getIstanza().eliminaCorso(5);
        }
    }
}