import { TestBed } from '@angular/core/testing';

import { ApplicantsService } from './applicants.service';

describe('ApplicantsService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ApplicantsService = TestBed.get(ApplicantsService);
    expect(service).toBeTruthy();
  });
});
