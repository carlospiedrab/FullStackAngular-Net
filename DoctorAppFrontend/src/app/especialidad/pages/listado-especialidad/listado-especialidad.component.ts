import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { Especialidad } from '../../interfaces/especialidad';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { EspecialidadService } from '../../servicios/especialidad.service';
import { CompartidoService } from 'src/app/compartido/compartido.service';
import { MatDialog } from '@angular/material/dialog';
import { ModalEspecialidadComponent } from '../../modales/modal-especialidad/modal-especialidad.component';
import Swal from 'sweetalert2';
import { filter } from 'rxjs';

@Component({
  selector: 'app-listado-especialidad',
  templateUrl: './listado-especialidad.component.html',
  styleUrls: ['./listado-especialidad.component.css'],
})
export class ListadoEspecialidadComponent implements OnInit, AfterViewInit {
  displayedColumns: string[] = [
    'nombreEspecialidad',
    'descripcion',
    'estado',
    'acciones',
  ];
  dataInicial: Especialidad[] = [];
  dataSource = new MatTableDataSource(this.dataInicial);
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(
    private _especialidadServicio: EspecialidadService,
    private _compartidoService: CompartidoService,
    private dialog: MatDialog
  ) {}

  nuevoEspecialidad() {
    this.dialog
      .open(ModalEspecialidadComponent, { disableClose: true, width: '400px' })
      .afterClosed()
      .subscribe((resultado) => {
        if (resultado === 'true') this.obtenerEspecialidades();
      });
  }

  editarEspecialidad(especialidad: Especialidad) {
    this.dialog
      .open(ModalEspecialidadComponent, {
        disableClose: true,
        width: '400px',
        data: especialidad,
      })
      .afterClosed()
      .subscribe((resultado) => {
        if (resultado === 'true') this.obtenerEspecialidades();
      });
  }

  obtenerEspecialidades() {
    this._especialidadServicio.lista().subscribe({
      next: (data) => {
        if (data.isExitoso) {
          this.dataSource = new MatTableDataSource(data.resultado);
          this.dataSource.paginator = this.paginator;
        } else
          this._compartidoService.mostrarAlerta(
            'No se encontraron datos',
            'Advertencia!'
          );
      },
      error: (e) => {
        this._compartidoService.mostrarAlerta(e.error.mensaje, 'Error!');
      },
    });
  }

  removerEspecialidad(especialidad: Especialidad) {
    Swal.fire({
      title: 'Desea Eliminar la Especialidad?',
      text: especialidad.nombreEspecialidad,
      icon: 'warning',
      confirmButtonColor: '#3085d6',
      confirmButtonText: 'Sí, eliminar',
      showCancelButton: true,
      cancelButtonColor: '#d33',
      cancelButtonText: 'No',
    }).then((resultado) => {
      if (resultado.isConfirmed) {
        this._especialidadServicio.eliminar(especialidad.id).subscribe({
          next: (data) => {
            if (data.isExitoso) {
              this._compartidoService.mostrarAlerta(
                'La especialidad fue eliminada',
                'Completo'
              );
              this.obtenerEspecialidades();
            } else {
              this._compartidoService.mostrarAlerta(
                'No se pudo eliminar la especialidad',
                'Error!'
              );
            }
          },
          error: (e) => {
             this._compartidoService.mostrarAlerta(e.error.mensaje, 'Error!');
          },
        });
      }
    });
  }

  aplicarFiltroListado(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  ngOnInit(): void {
    this.obtenerEspecialidades();
  }
  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }
}
