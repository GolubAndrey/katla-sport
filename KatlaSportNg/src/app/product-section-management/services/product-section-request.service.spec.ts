import { TestBed, inject } from '@angular/core/testing';

import { ProductToSectionRequestsService } from './product-section-request.service';

describe('HiveSectionService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ProductToSectionRequestsService]
    });
  });

  it('should be created', inject([ProductToSectionRequestsService], (service: ProductToSectionRequestsService) => {
    expect(service).toBeTruthy();
  }));
});