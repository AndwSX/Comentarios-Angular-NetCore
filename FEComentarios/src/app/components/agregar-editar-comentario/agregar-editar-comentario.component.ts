import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { Comentario } from '../../interfaces/Comentario';

@Component({
  selector: 'app-agregar-editar-comentario',
  imports: [RouterModule, ReactiveFormsModule, CommonModule],
  templateUrl: './agregar-editar-comentario.component.html',
  styleUrl: './agregar-editar-comentario.component.css'
})
export class AgregarEditarComentarioComponent {
  agregarComentario: FormGroup;

  constructor(private fb: FormBuilder){
    this.agregarComentario = this.fb.group({
      titulo: ['', Validators.required],
      creador: ['', Validators.required],
      texto: ['', Validators.required]
    })
  }

  agregar(){
    console.log(this.agregarComentario);

    const comentario: Comentario = {
      titulo: this.agregarComentario.get('titulo')?.value,
      creador: this.agregarComentario.get('creador')?.value,
      texto: this.agregarComentario.get('texto')?.value,
      fechaCreacion: new Date
    }
    console.log(comentario);
  }


}
