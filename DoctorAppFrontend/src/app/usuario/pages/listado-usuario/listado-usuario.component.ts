import { Component, OnInit, AfterViewInit, ViewChild } from '@angular/core';
import { Usuario } from '../../interfaces/usuario';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { UsuarioService } from '../../servicios/usuario.service';
import { CompartidoService } from 'src/app/compartido/compartido.service';
import { MatDialog } from '@angular/material/dialog';
import { ModalUsuarioComponent } from '../../modales/modal-usuario/modal-usuario.component';

@Component({
  selector: 'app-listado-usuario',
  templateUrl: './listado-usuario.component.html',
  styleUrls: ['./listado-usuario.component.css']
})
export class ListadoUsuarioComponent implements OnInit, AfterViewInit{

  displayedColumns: string[] = [
    'username',
    'apellidos',
    'nombres',
    'email',
    'rol'
  ];
  dataInicial: Usuario[] = [];
  dataSource = new MatTableDataSource(this.dataInicial);
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(
    private _usuarioServicio: UsuarioService,
    private _compartidoServicio: CompartidoService,
    private dialog: MatDialog
  ) {}

  obtenerUsuarios(){
     this._usuarioServicio.lista().subscribe({
      next: (data) => {
        if(data.isExitoso)
        {
          this.dataSource = new MatTableDataSource(data.resultado);
          this.dataSource.paginator = this.paginator;
        }
        else {
          this._compartidoServicio.mostrarAlerta('No se encontraron datos','Advertencia!');
        }
      },
      error: (e) => {}
     })
  }

  nuevoUsuario() {
    this.dialog
      .open(ModalUsuarioComponent, {disableClose: true, width: '600px'})
      .afterClosed()
      .subscribe((resultado) => {
        if (resultado === 'true') this.obtenerUsuarios();
      })
  }

  aplicarFiltroListado(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
    if(this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  ngAfterViewInit(): void {
    this.dataSource.paginator = this.paginator;
  }
  ngOnInit(): void {
    this.obtenerUsuarios();
  }

}
