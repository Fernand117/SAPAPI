import { Routes } from '@angular/router';
import { LoginComponent } from './pages/login/login.component';
import { InicioComponent } from './pages/inicio/inicio.component';

export const routes: Routes = [
    {
        path: 'login', component: LoginComponent
    },
    {
        path: 'inicio', component: InicioComponent
    },
    {
        path: '**', pathMatch: 'full', redirectTo: 'inicio'
    }
];
