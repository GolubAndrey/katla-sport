import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductToSectionRequestsService } from '../services/product-section-request.service';
import { ProductToSectionRequest } from '../models/product-section-request';

@Component({
  selector: 'app-product-section-request-form',
  templateUrl: './product-section-request-form.component.html',
  styleUrls: ['./product-section-request-form.component.css']
})
export class ProductToSectionRequestFormComponent implements OnInit {

  request = new ProductToSectionRequest(0,0,0,0,false);
  productId: number;
  hiveSectionId: number;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private requestService: ProductToSectionRequestsService
  ) { }

  ngOnInit() {
    this.route.params.subscribe(r => {
      this.productId = r['productId'],
      this.hiveSectionId = r['hiveSectionId'],
      this.request.productId = this.productId;
      this.request.hiveSectionId = this.hiveSectionId;
    });
  }

  navigateToProductsFromSection() {    
    this.router.navigate([`/sectionProducts/${this.hiveSectionId}`]);
  }

  onCancel() {
    this.navigateToProductsFromSection();
  }

  onSubmit() {
    this.requestService.createRequest(this.request).subscribe(s => {      
      this.navigateToProductsFromSection();
    }); 
}
