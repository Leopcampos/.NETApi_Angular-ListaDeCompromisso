import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment.development';
import * as services from 'src/auth/authServices';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  //atributos..
  mensagens = { erro: '' }
  validacoes = { email: [], senha: [] }

  constructor(private httpClient: HttpClient) { }

  ngOnInit(): void {
  }

  autenticarUsuario(formLogin: any): void {

    this.limparMensagens();

    this.httpClient.post(environment.apiUrl + "/login", formLogin.form.value)
      .subscribe( //promisse (retorno obtido da API)
        (data: any) => { //sucesso!
          
          //gravar o token em sessão..
          services.addAccessToken(data.accessToken);

          //redirecionamento..
          services.redirectToAdminPage();
        },
        (e: any) => { //erro!
          switch (e.status) {
            case 400: //Bad Request
              this.validacoes.email = e.error.errors.Email;
              this.validacoes.senha = e.error.errors.Senha;
              break;

            case 401: //Unauthorized
              this.mensagens.erro = e.error.message;
              break;
              
            case 500: //Internal Server Error
              this.mensagens.erro = e.error;
              break;
          }
        }
      );

  }

  //função para limpar todas as mensagens do componente..
  limparMensagens(): void {
    this.mensagens.erro = '';

    this.validacoes.email = [];
    this.validacoes.senha = [];
  }
}
