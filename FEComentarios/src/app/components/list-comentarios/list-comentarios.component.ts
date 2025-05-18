import { Component } from '@angular/core';
import { Comentario } from '../../interfaces/Comentario';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-list-comentarios',
  imports: [CommonModule, RouterModule],
  templateUrl: './list-comentarios.component.html',
  styleUrl: './list-comentarios.component.css'
})
export class ListComentariosComponent {
  listComentarios: Comentario[] = [
    {titulo: 'Blanco', creador: 'Yo', fechaCreacion: new Date(), texto: 'Hola xd'},
    {titulo: 'Negro', creador: 'Zoe', fechaCreacion: new Date(), texto: 'Hola mi amor'}
    
  ]

}
