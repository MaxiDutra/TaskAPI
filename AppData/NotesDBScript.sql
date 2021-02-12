USE Master
GO
If EXISTS (select * from sys.databases where name = 'NotesDB')
begin
	DROP DATABASE NotesDB
end
GO
CREATE DATABASE NotesDB
ON (
	NAME = NotesDB,
	FILENAME='D:\SQLRepos\NotesDB.mdf'
	)
GO
USE NotesDB

CREATE TABLE Users (
	
	UserID Int Identity(1,1),
	UserName varchar(50),
	UserPassword varchar(50) Not null,
	UserEmail varchar(50)
	Primary Key(UserID)
)

CREATE TABLE Notes (
	
	NotesID int Identity(1,1),
	NotesName varchar(50),
	NoteDescription varchar(1000),
	Tag varchar(50),
	NoteColor varchar(100),
	UserID int FOREIGN KEY REFERENCES Users(UserID)
	Primary key (NotesID)

)

INSERT INTO Users VALUES ('Mario', 'ma123','msilva@gmail.com')
INSERT INTO Users VALUES ('Richard', 'rich1221','rife@gmail.com')
INSERT INTO Users VALUES ('Valentina','vr4321','valero@gmail.com')
INSERT INTO Users VALUES ('Maria','Ramos123','mariarome2@gmail.com')

SELECT * FROM Users

INSERT INTO Notes VALUES ('Ideas de Mario','descripcion de las notas de mario','ideas','#FF5733',1)
INSERT INTO Notes VALUES ('Compras','pan, queso, agua','','#742716',2)
INSERT INTO Notes VALUES ('Canciones','The Notorious B.I.G, Ice Cube - It Was A Good Day','Covers','#9B7067',3)

SELECT * FROM Notes