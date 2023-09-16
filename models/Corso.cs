using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 CREATE TABLE Corso(
	corsoID INTEGER PRIMARY KEY IDENTITY(1,1),
	titolo VARCHAR(250) NOT NULL,
	codice VARCHAR(10) NOT NULL,
	crediti INTEGER DEFAULT 1
);
 */
namespace TASK_universita.models
{
    public class Corso
    {
		public int Id { get; set; }
		public string? Titolo { get; set; }
		public string? Codice { get; set; }
		public int Crediti { get; set; }
		public override string ToString()
		{
			return $"{Id} {Titolo} {Codice} {Crediti}";
		}
    }
}
