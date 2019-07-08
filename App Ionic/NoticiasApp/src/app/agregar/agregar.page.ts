import { Component, OnInit } from '@angular/core';
import { NoticiasService } from '../Services/noticia-service/noticias.service';
import { Autor } from '../models/autor.models';
import { Noticia } from '../models/noticia.models';
import { LoadingController, ToastController } from '@ionic/angular';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-agregar',
  templateUrl: './agregar.page.html',
  styleUrls: ['./agregar.page.scss'],
})
export class AgregarPage implements OnInit {
  autores : Autor[] = new Array <Autor>();
  noticia:Noticia = new Noticia();

  esEditable : boolean = false;
  constructor(private noticiaServicio: NoticiasService,public loadingController: LoadingController,
    public toastController: ToastController,private activatedRoute :ActivatedRoute) { }

  ngOnInit() {
    if(this.activatedRoute.snapshot.params.noticiaEditar != undefined)
    {
      this.noticia = new Noticia(JSON.parse( this.activatedRoute.snapshot.params.noticiaEditar));
      this.esEditable = true;
    }

    this.noticiaServicio.listadoDeAutores().subscribe((listadoAutores)=> {
      this.autores = listadoAutores
      console.log(this.autores);
    },error =>
    console.log(error));
  }

  async guardar(){

    const loading = await this.loadingController.create({
      message: 'Guardando Noticia'
    });
    await loading.present();

    this.noticiaServicio.agregarNoticia(this.noticia).subscribe(()=>{
      this.noticia = new Noticia(null)
      loading.dismiss();
      this.MostrarMensaje("Se guardo correctamente");
    },error=>{
    loading.dismiss();
    this.MostrarMensaje("Ocurrio un error al guardar")});
  }

  async MostrarMensaje(mensaje: string)
  {
    const toast = await this.toastController.create({
      message: mensaje,
      duration: 2000
    });
    toast.present();
  }
  async editar(){

    const loading = await this.loadingController.create({
      message: 'Editando la Noticia'
    });
    await loading.present();

    this.noticiaServicio.editarNoticia(this.noticia).subscribe(()=>{
      loading.dismiss();
      this.MostrarMensaje("Se edito correctamente");
    },error=>{
    loading.dismiss();
    this.MostrarMensaje("Ocurrio un error al editar")});
  }
}
