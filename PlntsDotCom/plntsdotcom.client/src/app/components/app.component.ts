import { Component, OnInit } from '@angular/core';
import { Product } from '../models/product.type';
import { ProductService } from '../services/product-service/product.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  public products: Product[] = [];

  constructor(private productService: ProductService) {}

  ngOnInit() {
    this.getProducts();
    
  }

  getProducts() {
    this.productService.fetchProductData()
      .subscribe(products => {
        this.products = products;
      }, error => {
        console.error('Error fetching product data:', error);
      });
      console.log(this.products)
  }

  title = 'plntsdotcom.client';
  
}
