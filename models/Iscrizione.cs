using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
CREATE TABLE Studente_Corso(
	studenteRIF INTEGER NOT NULL,
	corsoRIF INTEGER NOT NULL,
	FOREIGN KEY (StudenteRIF) REFERENCES Studente(StudenteID) ON DELETE CASCADE,
	FOREIGN KEY (CorsoRIF) REFERENCES Corso(CorsoID) ON DELETE CASCADE,
	PRIMARY KEY (StudenteRIF, CorsoRIF)
);
 */
namespace TASK_universita.models
{
    internal class Iscrizione
    {
		int StudenteRIF { get; set; }
		int CorsoRIF { get; set; }

        public override string ToString()
        {
            return $"{StudenteRIF} {CorsoRIF}";
        }
    }
}
