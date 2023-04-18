import { Component } from '@angular/core';
import * as services from 'src/auth/authServices'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  //atributo
  usuarioAutenticado = false;

  //função executada quando o componente é renderizado
  ngOnInit(): void {
    this.usuarioAutenticado = services.getAccessToken() != null;
  }

  //função para realizar o logout do usuario
  logout(): void {
    if (window.confirm('Deseja realmente sair do sistema?')) {
      services.removeAccessToken();
      services.redirectToLoginPage();
    }
  }
}
