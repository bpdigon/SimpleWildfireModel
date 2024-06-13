import { TestBed } from '@angular/core/testing';

import { WildFireService } from './wild-fire-service.service';

describe('WildFireServiceService', () => {
  let service: WildFireService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(WildFireService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
