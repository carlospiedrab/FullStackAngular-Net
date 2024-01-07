import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListadoUsuarioComponent } from './listado-usuario.component';

describe('ListadoUsuarioComponent', () => {
  let component: ListadoUsuarioComponent;
  let fixture: ComponentFixture<ListadoUsuarioComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ListadoUsuarioComponent]
    });
    fixture = TestBed.createComponent(ListadoUsuarioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
