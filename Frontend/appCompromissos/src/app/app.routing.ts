import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";

import { LoginComponent } from "./login/login.component";
import { RegisterComponent } from "./register/register.component";
import { CadastroCompromissoComponent } from "./cadastro-compromisso/cadastro-compromisso.component";
import { ConsultaCompromissoComponent } from "./consulta-compromisso/consulta-compromisso.component";

//mapear as rotas (URLs) para cada componente
const routes: Routes = [
    { path: 'login', component: LoginComponent },
    { path: 'register', component: RegisterComponent },
    { path: 'cadastro-compromisso', component: CadastroCompromissoComponent },
    { path: 'consulta-compromisso', component: ConsultaCompromissoComponent },
]

//registrando as rotas
@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})

export class AppRoutingModule { }