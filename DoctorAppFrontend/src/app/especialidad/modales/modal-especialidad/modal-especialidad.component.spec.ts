import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ModalEspecialidadComponent } from './modal-especialidad.component';

describe('ModalEspecialidadComponent', () => {
  let component: ModalEspecialidadComponent;
  let fixture: ComponentFixture<ModalEspecialidadComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ModalEspecialidadComponent]
    });
    fixture = TestBed.createComponent(ModalEspecialidadComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
