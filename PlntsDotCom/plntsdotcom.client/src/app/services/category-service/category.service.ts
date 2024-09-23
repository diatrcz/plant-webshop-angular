import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Category } from '../../models/category.type';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor(private http: HttpClient) { }

  fetchCategoryDetails(categoryId: number): Observable<Category> {
    return this.http.get<Category>('api/category/' + categoryId);
  }

  fetchChildrenCategories(parentCategoryName: string): Observable<Category[]> {
    return this.http.get<Category[]>('api/category/children/' + parentCategoryName);
  }

  fetchParentCategories(): Observable<Category[]> {
    return this.http.get<Category[]>('api/category/parentCategories');
  }
}
