import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { LayoutComponent } from './layout/layout.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ListadoEspecialidadComponent } from '../especialidad/pages/listado-especialidad/listado-especialidad.component';
import { } from '../especialidad/especialidad.module';
import { } from '../medico/medico.module';
import { ListadoMedicoComponent } from '../medico/pages/listado-medico/listado-medico.component';
import { authGuard } from '../_guards/auth.guard';

const routes: Routes = [
  {
    path: '',
    component: LayoutComponent,
    runGuardsAndResolvers: 'always',
    canActivate: [authGuard],
    children: [
      { path: 'dashboard', component: DashboardComponent, pathMatch: 'full',  },
      {
        path: 'especialidades', component: ListadoEspecialidadComponent,   pathMatch: 'full',
      },
      {
        path: 'medicos', component: ListadoMedicoComponent,   pathMatch: 'full',
      },
      { path: '**', redirectTo: '', pathMatch: 'full' },
    ],
  },
];

@NgModule({
  declarations: [],
  imports: [CommonModule, RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class LayoutRoutingModule {}
