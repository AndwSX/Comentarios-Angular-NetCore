import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ComentarioService } from '../../services/comentario.service';
import { Comentario } from '../../interfaces/Comentario';

@Component({
  selector: 'app-list-comentarios',
  standalone: true,
  imports: [
    CommonModule,
    RouterModule
  ],
  templateUrl: './list-comentarios.component.html',
  styleUrls: ['./list-comentarios.component.css']
})
export class ListComentariosComponent {

  listComentarios: Comentario[] = [];

  constructor(private _comentarioService: ComentarioService) {}

  ngOnInit(): void {
    this.getComentarios();
  }

  private getComentarios(): void {
    this._comentarioService.getListComentarios().subscribe({
      next: data  => { this.listComentarios = data; },
      error: err  => console.error(err),
      complete: () => console.log('Completado')
    });
  }

  eliminarComentario(id?: number): void {
    if (id == null) { return; }
  
    console.log('eliminando', id);   // ← comprueba que entra aquí
  
    this._comentarioService.deleteComentario(id).subscribe({
      next: () => this.getComentarios(),
      error: err => console.error('Error eliminando', err)
    });
  }
}

