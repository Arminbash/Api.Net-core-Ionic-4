using Microsoft.EntityFrameworkCore;
using NoticiasWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NoticiasWebApi.Services
{
    public class NoticiaServices
    {
        public readonly NoticiasDBContext _noticiaDB;
        public NoticiaServices(NoticiasDBContext noticiaDB)
        {
            _noticiaDB = noticiaDB;
        }

        public List< Noticia> verListadoTodasLasNoticias()
        {
            var noticiaBuscada = _noticiaDB.Noticia.Include(x => x.Autor).OrderByDescending(x => x.NoticiaID).ToList();
            return noticiaBuscada;
        }

        public bool Agregar(Noticia NoticiaAgregar)
        {
            try
            {
                _noticiaDB.Noticia.Add(NoticiaAgregar);
                _noticiaDB.SaveChanges();
                return true;
            }
            catch(Exception error)
            {
                return false;
            }
        }
        public bool Editar(Noticia NoticiaEditar)
        {
            try
            {
                var noticia = _noticiaDB.Noticia.FirstOrDefault(x => x.NoticiaID == NoticiaEditar.NoticiaID);
                noticia.Titulo = NoticiaEditar.Titulo;
                noticia.Descripcion = NoticiaEditar.Descripcion;
                noticia.Contenido = NoticiaEditar.Contenido;
                noticia.Fecha = NoticiaEditar.Fecha;
                noticia.AutorID = NoticiaEditar.AutorID;
                _noticiaDB.SaveChanges();
                return true;
            }
            catch (Exception error)
            {
                return false;
            }
        }

        public bool Eliminar(int idNoticia)
        {
            try
            {
                var noticiaEliminar = _noticiaDB.Noticia.FirstOrDefault(x => x.NoticiaID == idNoticia);
                _noticiaDB.Noticia.Remove(noticiaEliminar);
                _noticiaDB.SaveChanges();
                return true;
            }
            catch (Exception error)
            {
                return false;
            }
        }

        public List<Autor> listadoDeAutores()
        {
            try
            {
                var autores = _noticiaDB.Autor.ToList();
                return autores;
            }
            catch (Exception error)
            {
                return new List<Autor>();
            }
        }
    }
}
