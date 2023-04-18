import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { CadastroCompromissoComponent } from './cadastro-compromisso/cadastro-compromisso.component';
import { ConsultaCompromissoComponent } from './consulta-compromisso/consulta-compromisso.component';

import { AppRoutingModule } from './app.routing';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import{ HttpClientModule } from '@angular/common/http';
import { AdminComponent } from './admin/admin.component';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    CadastroCompromissoComponent,
    ConsultaCompromissoComponent,
    AdminComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule, //registrando a configuração de rotas
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
