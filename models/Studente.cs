using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
	CREATE TABLE Studente(
	studenteID INTEGER PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(250) NOT NULL,
	cognome VARCHAR(250) NOT NULL,
	matricola VARCHAR(10) NOT NULL UNIQUE

);
 */
namespace TASK_universita.models
{
    public class Studente
    {
		public int Id { get; set; }
		public string? Nome { get; set; }
		public string? Cognome { get; set; }
		public string? Matricola { get; set; }
        public override string ToString()
        {
            return $"{Id} {Nome} {Cognome} {Matricola}";
        }

    }
}
