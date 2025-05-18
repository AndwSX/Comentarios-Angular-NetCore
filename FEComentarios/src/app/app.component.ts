import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';

//Componentes
import { NavbarComponent } from './components/navbar/navbar.component';
import { ListComentariosComponent } from './components/list-comentarios/list-comentarios.component';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, NavbarComponent, ListComentariosComponent], //Sale error que no o estoy usando por que uso rutas, pero para 'incude' es asi
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'FEComentarios';
}
