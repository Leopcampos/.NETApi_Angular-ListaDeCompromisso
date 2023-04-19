import { Component } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment.development';
import * as services from 'src/auth/authServices';

interface Compromisso {
  nome: string;
  data: string;
  hora: string;
  descricao: string;
  idCompromisso: string;
}

@Component({
  selector: 'app-consulta-compromisso',
  templateUrl: './consulta-compromisso.component.html',
  styleUrls: ['./consulta-compromisso.component.css']
})

export class ConsultaCompromissoComponent {

  listagemCompromissos: Compromisso[] = [];

  mensagens = {
    sucesso: '',
    sucessoedicao: '',
    erro: '',
    erroedicao: ''
  }

  validacoes = {
    dataInicio: [], dataFim: [],
    nome: [], data: [], hora: [], descricao: []
  }

  compromissoEdicao = {
    idCompromisso: '',
    nome: '',
    data: '',
    hora: '',
    descricao: ''
  }

  httpHeaders!: HttpHeaders;

  constructor(private httpClient: HttpClient) { }

  ngOnInit(): void {
    //ler o TOKEN do usuario autenticado
    this.httpHeaders = new HttpHeaders()
      .set('Authorization', 'Bearer ' + services.getAccessToken())
  }

  pesquisarCompromissos(formConsulta: any): void {

    this.mensagens.sucesso = '';
    this.mensagens.erro = '';
    this.validacoes.dataInicio = [];
    this.validacoes.dataFim = [];

    var dataInicio = formConsulta.form.value.dataInicio;
    var dataFim = formConsulta.form.value.dataFim;

    //enviando uma requisição GET para a API 
    this.httpClient.get(environment.apiUrl + '/compromissos/' + dataInicio + "/" + dataFim,
      { headers: this.httpHeaders })
      .subscribe(
        (data: any) => {

          this.listagemCompromissos = data;

          if (this.listagemCompromissos.length > 0)
            this.mensagens.sucesso = this.listagemCompromissos.length + ' registro(s) obtidos';

          else
            this.mensagens.erro = "Nenhum compromisso foi encontrado para o periodo selecionado";
        },
        e => {
          var error = JSON.parse(e.error);

          switch (e.status) {
            case 400: //Bad Request 
              this.validacoes.dataInicio = error.errors.Nome;
              this.validacoes.dataFim = error.errors.Data;
              break;

            case 401:
              services.redirectToLoginPage();
              break;

            case 500: //Internal Server Error 
              this.mensagens.erro = error; break;
          }
        })
  }

  excluirCompromisso(idCompromisso: any): void {

    if (window.confirm('Deseja realmente excluir o compromisso selecionado?')) {

      this.httpClient.delete(environment.apiUrl + "/compromissos/" + idCompromisso,
        { responseType: 'text', headers: this.httpHeaders })
        .subscribe(
          data => {
            this.mensagens.sucesso = data;

            this.listagemCompromissos = this.listagemCompromissos
              .filter(item => item.idCompromisso != idCompromisso);

          },
          e => {
            var error = JSON.parse(e.error);
            this.mensagens.erro = error;
          })
    }
  }

  obterCompromisso(idCompromisso: any): void {
    this.mensagens.sucessoedicao = '';
    this.mensagens.erroedicao = '';

    this.validacoes.nome = [];
    this.validacoes.data = [];
    this.validacoes.hora = [];
    this.validacoes.descricao = [];

    this.httpClient.get(environment.apiUrl + "/compromissos/" + idCompromisso, { headers: this.httpHeaders }).subscribe((data: any) => { this.compromissoEdicao = data; }, e => { var error = JSON.parse(e.error); this.mensagens.erro = error; })
  }

  atualizarCompromisso(formEdicao: any): void {
    this.mensagens.sucessoedicao = '';
    this.mensagens.erroedicao = '';

    this.validacoes.nome = [];
    this.validacoes.data = [];
    this.validacoes.hora = [];
    this.validacoes.descricao = [];

    //enviando uma requisição POST para a API 
    this.httpClient.put(environment.apiUrl + '/compromissos',
      formEdicao.form.value,
      { responseType: 'text', headers: this.httpHeaders })
      .subscribe(
        data => {
          this.mensagens.sucessoedicao = data;

          var item = this.listagemCompromissos
            .find(c => c.idCompromisso == this.compromissoEdicao.idCompromisso);

            if (item) {
              item.nome = this.compromissoEdicao.nome;
              item.data = this.compromissoEdicao.data;
              item.hora = this.compromissoEdicao.hora;
              item.descricao = this.compromissoEdicao.descricao;
            }
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

            case 401:
              services.redirectToLoginPage();
              break;

            case 500: //Internal Server Error 
              this.mensagens.erroedicao = error;
              break;
          }
        })
  }
}