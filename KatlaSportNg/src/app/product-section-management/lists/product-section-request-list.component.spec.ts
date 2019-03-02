import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductToSectionRequestListComponent } from './product-section-request-list.component';

describe('HiveSectionProductListComponent', () => {
  let component: ProductToSectionRequestListComponent;
  let fixture: ComponentFixture<ProductToSectionRequestListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProductToSectionRequestListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProductToSectionRequestListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
