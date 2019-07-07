create database Noticias
go
use Noticias
Go
create table autor(
AutorID int identity primary key,
Nombre varchar(50),
Apellido varchar(50)
)
Go
create table noticia(
NoticiaID int identity primary key,
Titulo varchar(50),
Descripcion	varchar(100),
Contenido varchar(MAX),
Fecha datetime,
AutorID int foreign key references autor(AutorID)
)
Go