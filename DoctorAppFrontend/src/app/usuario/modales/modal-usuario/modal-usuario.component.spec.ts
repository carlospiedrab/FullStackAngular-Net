import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ModalUsuarioComponent } from './modal-usuario.component';

describe('ModalUsuarioComponent', () => {
  let component: ModalUsuarioComponent;
  let fixture: ComponentFixture<ModalUsuarioComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ModalUsuarioComponent]
    });
    fixture = TestBed.createComponent(ModalUsuarioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
