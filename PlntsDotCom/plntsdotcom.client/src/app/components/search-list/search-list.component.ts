import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Product } from '../../models/product.type';
import { ProductService } from '../../services/product-service/product.service';

@Component({
  selector: 'app-search-list',
  templateUrl: './search-list.component.html',
  styleUrl: './search-list.component.css'
})
export class SearchListComponent {
  searchQuery: string = '';
  products: Product[] = [];

  constructor(
    private route: ActivatedRoute,
    private productService: ProductService
    ) {}

  ngOnInit() {
    this.fetchSearchResults();
  }

  fetchSearchResults() {
    this.route.queryParams.subscribe(params => {
      this.searchQuery = params['query'] || '';
      console.log('Search query:', this.searchQuery);
      this.fetchProducts();
    });
  }

  fetchProducts() {
    this.productService.searchProducts(this.searchQuery)
    .subscribe(products => {
       this.products = products;
     }, error => {
      console.error('Error fetching product data:', error);
    });
  }
}
