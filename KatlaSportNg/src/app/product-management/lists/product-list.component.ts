import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductListItem } from '../models/product-list-item';
import { ProductService } from '../services/product.service';
import { UserService } from 'app/login-managment/services/login.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {

  products: ProductListItem[];

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private productService: ProductService,
    private userService: UserService
  ) { }

  ngOnInit() {
    this.productService.getProducts().subscribe(p => this.products = p);
  }
}
