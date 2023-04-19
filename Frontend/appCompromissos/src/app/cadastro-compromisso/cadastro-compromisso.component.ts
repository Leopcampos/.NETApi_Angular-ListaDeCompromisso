import { Component } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment.development';
import * as services from 'src/auth/authServices'

@Component({
  selector: 'app-cadastro-compromisso',
  templateUrl: './cadastro-compromisso.component.html',
  styleUrls: ['./cadastro-compromisso.component.css']
})
export class CadastroCompromissoComponent {

  mensagens = {
    sucesso: '',
    erro: ''
  }

  validacoes = {
    nome: [], data: [], hora: [], descricao: []
  }

  httpHeaders!: HttpHeaders;

  constructor(private httpClient: HttpClient) { }

  ngOnInit(): void {
    //ler o TOKEN do usuario autenticado
    this.httpHeaders = new HttpHeaders()
      .set('Authorization', 'Bearer ' + services.getAccessToken())
  }

  cadastrarCompromisso(formCadastro: any): void {

    this.mensagens.sucesso = '';
    this.mensagens.erro = '';

    this.validacoes.nome = [];
    this.validacoes.data = [];
    this.validacoes.hora = [];
    this.validacoes.descricao = [];

    //enviando uma requisição POST para a API
    this.httpClient.post(environment.apiUrl + '/compromissos',
      formCadastro.form.value,
      { responseType: 'text', headers: this.httpHeaders })
      .subscribe(
        data => {
          this.mensagens.sucesso = data;
          formCadastro.form.reset();
        },
        e => {
          var error = JSON.parse(e.error);

          switch (e.status) {
            case 400: //Bad Request
              this.validacoes.nome = error.errors.Nome;
              this.validacoes.data = error.errors.Data;
              this.validacoes.hora = error.errors.Hora;
              this.validacoes.descricao = error.errors.Descricao;
              break;
            case 401: services.redirectToLoginPage();
              break; case 500: //Internal Server Error 
              this.mensagens.erro = error; break;
          }
        })
  }
}