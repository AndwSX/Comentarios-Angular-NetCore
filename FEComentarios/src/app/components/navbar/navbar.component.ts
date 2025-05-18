import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-navbar',
  imports: [RouterModule],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent {
  img = 'https://i.pinimg.com/736x/c4/9e/7d/c49e7d21acc584220a3ac5ddc2975845.jpg';

}
