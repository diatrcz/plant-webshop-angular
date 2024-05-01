import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProductService } from '../../services/product-service/product.service';
import { Product } from '../../models/product.type';
import { Filter } from '../../models/filter.type';

@Component({
  selector: 'app-plants-list',
  templateUrl: './plants-list.component.html',
  styleUrl: './plants-list.component.css'
})
export class PlantsListComponent implements OnInit{
  public products: Product[] = [];
  filter: Filter = new Filter();
  categoryName!: string;

  constructor(
    private route: ActivatedRoute, 
    private productService: ProductService
  ) {}

  ngOnInit(): void {
    this.loadRoute();
  }

  loadRoute(): void {
    this.route.paramMap.subscribe(params => {
      const categoryName = params.get('categoryName');
      if(categoryName != null) {
        this.categoryName = categoryName;
        this.loadProducts();
      }
    });
  }

  loadProducts(): void {
    this.productService.fetchProductsByCategory(this.categoryName, this.filter)
    .subscribe(products => {
      this.products = products;
    }, error => {
      console.error('Error fetching product data:', error);
    });
  }

}
