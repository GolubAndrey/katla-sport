import { TestBed, inject } from '@angular/core/testing';

import { HiveSectionProductsService } from './hive-section-products.service';

describe('HiveSectionService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [HiveSectionProductsService]
    });
  });

  it('should be created', inject([HiveSectionProductsService], (service: HiveSectionProductsService) => {
    expect(service).toBeTruthy();
  }));
});