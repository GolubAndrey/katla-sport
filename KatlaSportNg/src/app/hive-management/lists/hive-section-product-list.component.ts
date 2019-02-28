import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HiveSectionProductsService } from '../services/hive-section-products.service';
import { HiveSectionProductsListItem} from '../models/hive-section-products-list-item'

@Component({
  selector: 'app-hive-section-product-list',
  templateUrl: './hive-section-product-list.component.html',
  styleUrls: ['./hive-section-product-list.component.css']
})
export class HiveSectionProductListComponent implements OnInit {

  sectionId: number;
  products: HiveSectionProductsListItem[];

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private hiveSectionProductsService: HiveSectionProductsService
  ) { }

  ngOnInit() {
    this.route.params.subscribe(p => {
      this.sectionId = p['id'];
      this.hiveSectionProductsService.getSectionProducts(p['id']).subscribe(p => this.products = p);
    });
  }
}
