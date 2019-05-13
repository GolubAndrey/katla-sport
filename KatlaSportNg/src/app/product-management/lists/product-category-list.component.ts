import { Component, OnInit } from '@angular/core';
import { ProductCategoryListItem } from '../models/product-category-list-item';
import { ProductCategoryService } from '../services/product-category.service';
import { UserService } from 'app/login-managment/services/login.service';

@Component({
  selector: 'app-product-category-list',
  templateUrl: './product-category-list.component.html',
  styleUrls: ['./product-category-list.component.css']
})
export class ProductCategoryListComponent implements OnInit {

  selectedProductCategory: ProductCategoryListItem;
  productCategories: ProductCategoryListItem[];

  constructor(
    private productCategoryService: ProductCategoryService,
    private userService: UserService) { }

  ngOnInit() {
    this.getProductCategories();
  }

  onSelect(productCategory: ProductCategoryListItem): void {
    this.selectedProductCategory = productCategory;
  }

  getProductCategories(): void {
    this.productCategoryService.getProductCategories().subscribe(c => this.productCategories = c);
  }

  enableProductCategory(): void {
  }

  disableProductCategory(): void {
  }
}
