import { TestBed } from '@angular/core/testing';

import { SearchFilmsService } from './search-films.service';

describe('SearchFilmsService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: SearchFilmsService = TestBed.get(SearchFilmsService);
    expect(service).toBeTruthy();
  });
});
