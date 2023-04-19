import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";

import { LoginComponent } from "./login/login.component";
import { RegisterComponent } from "./register/register.component";
import { CadastroCompromissoComponent } from "./cadastro-compromisso/cadastro-compromisso.component";
import { ConsultaCompromissoComponent } from "./consulta-compromisso/consulta-compromisso.component";
import { AdminComponent } from "./admin/admin.component";

//mapear as rotas (URLs) para cada componente
const routes: Routes = [
    //Colocando a página inicial como /login
    { path: '', redirectTo: '/login', pathMatch: 'full' },
    
    { path: 'login', component: LoginComponent },
    { path: 'register', component: RegisterComponent },
    { path: 'admin', component: AdminComponent },
    { path: 'cadastro-compromisso', component: CadastroCompromissoComponent },
    { path: 'consulta-compromisso', component: ConsultaCompromissoComponent },
]

//registrando as rotas
@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})

export class AppRoutingModule { }