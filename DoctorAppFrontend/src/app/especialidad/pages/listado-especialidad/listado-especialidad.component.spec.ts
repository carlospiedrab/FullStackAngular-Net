import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListadoEspecialidadComponent } from './listado-especialidad.component';

describe('ListadoEspecialidadComponent', () => {
  let component: ListadoEspecialidadComponent;
  let fixture: ComponentFixture<ListadoEspecialidadComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ListadoEspecialidadComponent]
    });
    fixture = TestBed.createComponent(ListadoEspecialidadComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
