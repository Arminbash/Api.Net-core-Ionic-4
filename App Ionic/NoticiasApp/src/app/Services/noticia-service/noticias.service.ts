import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Noticia } from 'src/app/models/noticia.models';
import { Autor } from 'src/app/models/autor.models';

@Injectable({
  providedIn: 'root'
})
export class NoticiasService {

  constructor(public http: HttpClient) { }

    verNoticias() : Observable<Noticia[]> {
      return this.http.get<Noticia[]>('https://localhost:44320/api/noticias/vernoticias');
  }
  porNoticiaID(noticiaID : number): Observable<Noticia>{
    return this.http.get<Noticia>('https://localhost:44320/api/noticias/PorNoticiaID/'  + noticiaID);
  }
    eliminarNoticia(noticiaID : number): Observable<boolean>{
      return this.http.get<boolean>('https://localhost:44320/api/noticias/eliminar/'  + noticiaID);
    }
    listadoDeAutores(): Observable<Autor[]>{
      return this.http.get<Autor[]>('https://localhost:44320/api/noticias/ListadoAutores/');
    }
    agregarNoticia(noticia: Noticia): Observable<boolean>{
      return this.http.post<boolean>('https://localhost:44320/api/noticias/Agregar/',noticia);
    }
    editarNoticia(noticia: Noticia): Observable<boolean>{
      return this.http.put<boolean>('https://localhost:44320/api/noticias/Editar/',noticia);
    }
}
