import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Product } from '../../models/product.type';
import { ProductService } from '../../services/product-service/product.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrl: './product-details.component.css'
})
export class ProductDetailsComponent implements OnInit {
  productId!: string;
  product!: Product;
  quantity: number = 1;
  isButtonRed: boolean = false;

  constructor(private route: ActivatedRoute, private productService: ProductService) { }

  ngOnInit(): void {
    this.loadRoute();
    this.loadProduct();
  }

  loadRoute(): void {
    this.route.paramMap.subscribe(params => {
      const id = params.get('id');
      if (id !== null) {
        this.productId = id; 
      }
    });
  }

  loadProduct(): void {
    this.productService.fetchProductDetails(this.productId)
    .subscribe(product => {
      this.product = product;
    },error => {
      console.error('Error fetching product data:', error);
    });
  }

  updateQuantity(change: number): void {
    if (!this.product) return;
    this.quantity += change;
    if (this.quantity < 1 && this.quantity <= this.product!.stock!) {
        this.quantity = 1;
    }
  }

  toggleClick() {
    this.isButtonRed = !this.isButtonRed;
  }
}
