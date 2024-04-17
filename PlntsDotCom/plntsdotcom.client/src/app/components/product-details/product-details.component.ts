import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Product } from '../../models/product.type';
import { ProductService } from '../../services/product-service/product.service';
import { CategoryService } from '../../services/category-service/category.service';
import { Category } from '../../models/category.type';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrl: './product-details.component.css'
})
export class ProductDetailsComponent implements OnInit {
  productId!: string;
  product!: Product;
  category!: Category;
  quantity: number = 1;
  isButtonRed: boolean = false;

  constructor(
    private route: ActivatedRoute, 
    private productService: ProductService,
    private categoryService: CategoryService
  ) { }

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
      this.loadCategory(product.categoryId);
    },error => {
      console.error('Error fetching product data:', error);
    });
  }

  loadCategory(id: number): void {
    this.categoryService.fetchCategoryDetails(id)
    .subscribe(category => {
      this.product.category = category;
    }, error => {
      console.error('Error fetching category data:', error);
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
