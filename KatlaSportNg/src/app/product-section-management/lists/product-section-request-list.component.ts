import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductToSectionRequestsService } from '../services/product-section-request.service';
import { ProductToSectionRequestsListItem} from '../models/product-section-request-list-item'

@Component({
  selector: 'app-product-section-request-list',
  templateUrl: './product-section-request-list.component.html',
  styleUrls: ['./product-section-request-list.component.css']
})
export class ProductToSectionRequestListComponent implements OnInit {

  productToSectionRequests: ProductToSectionRequestsListItem[];

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private productToSectionRequestsService: ProductToSectionRequestsService
  ) { }

  ngOnInit() {
    this.route.params.subscribe(p => {
      this.productToSectionRequestsService.getProductToSectionRequests().subscribe(p => this.productToSectionRequests = p);
    });
  }
}
