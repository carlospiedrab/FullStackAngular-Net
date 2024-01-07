import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CompartidoModule } from '../compartido/compartido.module';
import { UsuarioService } from './servicios/usuario.service';
import { LoginComponent } from './login/login.component';
import { MaterialModule } from '../material/material.module';
import { ListadoUsuarioComponent } from './pages/listado-usuario/listado-usuario.component';
import { ModalUsuarioComponent } from './modales/modal-usuario/modal-usuario.component';



@NgModule({
  declarations: [
    LoginComponent,
    ListadoUsuarioComponent,
    ModalUsuarioComponent
  ],
  imports: [
    CommonModule,
    CompartidoModule,
    MaterialModule
  ],
  exports: [
    LoginComponent
  ],
  providers: [
    UsuarioService
  ]
})
export class UsuarioModule { }
