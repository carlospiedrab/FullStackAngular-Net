import { TestBed } from '@angular/core/testing';

import { EspecialidadService } from './especialidad.service';

describe('EspecialidadService', () => {
  let service: EspecialidadService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EspecialidadService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
