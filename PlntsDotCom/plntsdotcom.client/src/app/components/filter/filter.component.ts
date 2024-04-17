import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Filter } from '../../models/filter.type';
import { Category } from '../../models/category.type';
import { CategoryService } from '../../services/category-service/category.service';
import { subscribeOn } from 'rxjs';

@Component({
  selector: 'app-filter',
  templateUrl: './filter.component.html',
  styleUrl: './filter.component.css'
})
export class FilterComponent {
  @Input() productType!: string;
  @Input() filter!: Filter;
  @Output() submit: EventEmitter<void> = new EventEmitter<void>(); 
  categories: Category[] = [];

  constructor(private categoryService: CategoryService) {}

  ngOnInit(): void {
    this.loadCategories();
  }

  loadCategories(): void {
    this.categoryService.fetchChildrenCategories(this.productType)
    .subscribe(categories => {
        this.categories = categories;
    }, error => {
      console.error('Error fetching category data:', error);
    });
  }

  
}
