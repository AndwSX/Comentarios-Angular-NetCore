import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ComentarioService } from '../../services/comentario.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-ver-comentario',
  imports: [CommonModule],
  templateUrl: './ver-comentario.component.html',
  styleUrl: './ver-comentario.component.css'
})
export class VerComentarioComponent {

  id: number;
  comentario: any;

  constructor(private aRoute: ActivatedRoute, private _comentarioService: ComentarioService){ 
    this.aRoute.snapshot.paramMap.get('id');
    this.id = +this.aRoute.snapshot.paramMap.get('id')!;
  }

  ngOnInit(): void {
    this.getComentario();
  }

  getComentario(){
    this._comentarioService.getComentario(this.id).subscribe(data =>{
      this.comentario = data;
    })
  }


}
