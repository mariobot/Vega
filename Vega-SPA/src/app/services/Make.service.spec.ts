/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { MakeService } from './Make.service';

describe('Service: Make', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [MakeService]
    });
  });

  it('should ...', inject([MakeService], (service: MakeService) => {
    expect(service).toBeTruthy();
  }));
});
