
IF DB_ID('EventoJa') IS  NULL
CREATE DATABASE EventoJa;
ELSE
print 'DATABASE JÁ EXISTE'
go
use EventoJa;

IF (EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'Categoria')) 
   print 'TABELA CATEGORIA JÁ EXISTE'
ELSE
CREATE TABLE Categoria(
	Id int not null primary key identity,
	Nome varchar(50) not null
)