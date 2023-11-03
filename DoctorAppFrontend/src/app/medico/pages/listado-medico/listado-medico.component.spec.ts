import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListadoMedicoComponent } from './listado-medico.component';

describe('ListadoMedicoComponent', () => {
  let component: ListadoMedicoComponent;
  let fixture: ComponentFixture<ListadoMedicoComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ListadoMedicoComponent]
    });
    fixture = TestBed.createComponent(ListadoMedicoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
