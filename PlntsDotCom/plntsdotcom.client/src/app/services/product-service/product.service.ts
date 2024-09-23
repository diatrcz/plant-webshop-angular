import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Product } from '../../models/product.type';
import { Filter } from '../../models/filter.type';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private http: HttpClient) { }

  fetchProductData(): Observable<Product[]> {
    return this.http.get<Product[]>('api/products');
  }

  fetchProductDetails(productId: string): Observable<Product> {
    return this.http.get<Product>('api/products/details/' + productId);
  }

  fetchProductsByCategory(categoryName: string, filter: Filter): Observable<Product[]> {
    return this.http.get<Product[]>('api/products/shop/' + categoryName,
    { params: new HttpParams({ fromObject: <any>filter }) }
    );
  }

  searchProducts(queryString: string): Observable<Product[]> {
    return this.http.get<Product[]>('api/products/search/' + queryString);
  }
  
  updateProduct(product: Product): Observable<any> {
    return this.http.put<any>('api/product/' + product.id, product);
  }
}
