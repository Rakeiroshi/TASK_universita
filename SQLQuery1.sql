--Creo la tabella degli studenti
CREATE TABLE Studente(
	studenteID INTEGER PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(250) NOT NULL,
	cognome VARCHAR(250) NOT NULL,
	matricola VARCHAR(10) NOT NULL UNIQUE

);

--Creo la tabella dei corsi
CREATE TABLE Corso(
	corsoID INTEGER PRIMARY KEY IDENTITY(1,1),
	titolo VARCHAR(250) NOT NULL,
	codice VARCHAR(10) NOT NULL,
	crediti INTEGER DEFAULT 1
);

--Creo la tabella di riferimento Studente/corso
CREATE TABLE Studente_Corso(
	studenteRIF INTEGER NOT NULL,
	corsoRIF INTEGER NOT NULL,
	FOREIGN KEY (StudenteRIF) REFERENCES Studente(StudenteID) ON DELETE CASCADE,
	FOREIGN KEY (CorsoRIF) REFERENCES Corso(CorsoID) ON DELETE CASCADE,
	PRIMARY KEY (StudenteRIF, CorsoRIF)
);

--popolo studente
INSERT INTO Studente(nome, cognome, matricola) VALUES
	('Michael', 'Shumacher', 'MAT0170000'),
	('Garrosh', 'Malogrido', 'MAT5740000'),
	('Giancarlo', 'Fisichella', 'MAT1111000'),
	('Mihawk', 'Drakul', 'MAT5400000');

	--SELECT * FROM Studente;
	
--popolo corso
INSERT INTO Corso(titolo, codice, crediti) VALUES
	('Pilota', 'PILF1', 7),
	('Spadaccino', 'SEN6', 10),
	('Capoguerra', 'ORDA', 5);

	--SELECT * FROM Corso;

--Popolo i riferimenti
INSERT INTO Studente_Corso(StudenteRIF, CorsoRIF) VALUES
	(1,1),
	(2,3),
	(3,1),
	(4,2);

--interrogo il db
SELECT nome, cognome, matricola, titolo, codice, crediti
	FROM Studente
	JOIN Studente_Corso ON Studente.studenteID = Studente_Corso.studenteRIF
	JOIN Corso ON Studente_Corso.corsoRIF = Corso.corsoID;


--query da copiare su vs
--stampare gli studenti
SELECT studenteID,nome, cognome, matricola FROM studente;

SELECT studenteID,nome, cognome, matricola FROM Studente WHERE studenteID = 1 --su vs sostituire il numero con @varId;

SELECT * FROM Studente;


SELECT corsoID, titolo, codice, crediti FROM corso;
SELECT corsoID, titolo, codice, crediti FROM corso WHERE corsoID = @varId

