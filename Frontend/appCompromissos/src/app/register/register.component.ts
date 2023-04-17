import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment.development';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {

  //atributos
  mensagens = { sucesso: '', erro: '' }
  validacoes = { nome: [], email: [], senha: [], senhaConfirmacao: [] }

  constructor(private httpClient: HttpClient) { }

  ngOnInit(): void { }

  //evento SUBMIT do formulário
  cadastrarUsuario(formRegister: any): void {

    this.limparMensagens();

    this.httpClient.post(environment.apiUrl + "/account", formRegister.form.value)
      .subscribe( //promisse(retorno obtido da API)
        (data: any) => {//sucesso
          this.mensagens.sucesso = data.message;
          formRegister.form.reset
        },
        (e: any) => {//erro!
          switch (e.status) {
            case 400: //Bad Request

              this.validacoes.nome = e.error.errors.Nome;
              this.validacoes.email = e.error.errors.Email;
              this.validacoes.senha = e.error.errors.Senha;
              this.validacoes.senhaConfirmacao = e.error.errors.SenhaConfirmacao;

              break;

            case 403: //Forbidden
              this.mensagens.erro = e.error.message;
              break;

            case 500: //Internal Server Error
              this.mensagens.erro = e.error;
              break;
          }
        }
      );
  }

  //função para limpar todas as mensagens do componente
  limparMensagens(): void {
    this.mensagens.sucesso = '';
    this.mensagens.erro = '';

    this.validacoes.nome = [];
    this.validacoes.email = [];
    this.validacoes.senha = [];
    this.validacoes.senhaConfirmacao = [];
  }
}