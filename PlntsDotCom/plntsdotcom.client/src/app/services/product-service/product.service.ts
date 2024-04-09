import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Product } from '../../models/product.type';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private http: HttpClient) { }

  fetchProductData(): Observable<Product[]> {
    return this.http.get<Product[]>('/api');
  }

  fetchProductDetails(productId: string): Observable<Product> {
    return this.http.get<Product>('/api/' + productId);
  }
}
