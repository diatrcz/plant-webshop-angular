import { Component, OnInit } from '@angular/core';
import { Product } from '../../models/product.type';
import { ProductService } from '../../services/product-service/product.service';

@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrl: './main-page.component.css'
})
export class MainPageComponent implements OnInit {
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
}
