import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductToSectionRequestFormComponent } from './product-section-request-form.component';

describe('HiveFormComponent', () => {
  let component: ProductToSectionRequestFormComponent;
  let fixture: ComponentFixture<ProductToSectionRequestFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProductToSectionRequestFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProductToSectionRequestFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
