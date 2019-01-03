/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { FeatureService } from './feature.service';

describe('Service: Feature', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [FeatureService]
    });
  });

  it('should ...', inject([FeatureService], (service: FeatureService) => {
    expect(service).toBeTruthy();
  }));
});
