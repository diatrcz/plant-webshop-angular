import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProductService } from '../../services/product-service/product.service';
import { CategoryService } from '../../services/category-service/category.service';
import { Category } from '../../models/category.type';
import { lastValueFrom } from 'rxjs';
import { Product } from '../../models/product.type';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent implements OnInit {
  addType!: string;
  parentCategories: Category[] = [];
  childrenCategories: Category[] = [];
  selectedParentCategory!: Category;
  product: Product = {
    id: 0,
    name: '',
    price: 0,
    stock: null,
    description: '',
    categoryId: 0,
    orderedItems: [],
    imageUrl: '',
    quantity: null
  };

  constructor(
    private route: ActivatedRoute,
    private productService: ProductService,
    private categoryService: CategoryService
  ) {}

  ngOnInit(): void {
    this.loadRoute();
    this.loadCategories();
  }

  loadRoute(): void {
    this.route.paramMap.subscribe(params => {
      const addType = params.get('type');
      if (addType !== null) this.addType = addType;
    });
  }

  loadCategories(): void {
    this.loadParentCategories();
  }

  async loadParentCategories(): Promise<void> {
    try {
      const parentCategories = await lastValueFrom(this.categoryService.fetchParentCategories());
      this.parentCategories = parentCategories ?? [];
    } catch (error) {
      console.error('Error fetching Parentcategory data:', error);
    }
  }

  async onParentCategoryChange(event: Event): Promise<void> {
    const parentId = (event.target as HTMLSelectElement).value;
    console.log(parentId);
    this.selectedParentCategory = this.parentCategories[Number(parentId) - 1];

    try {
      this.childrenCategories = await this.fetchChildrenCategories(this.selectedParentCategory.name);
      console.log(this.childrenCategories);
    } catch (error) {
      console.error('Error fetching child categories:', error);
    }
  }

  async fetchChildrenCategories(parentId: string): Promise<Category[]> {
    try {
      return await lastValueFrom(this.categoryService.fetchChildrenCategories(parentId));
    } catch (error) {
      console.error('Error fetching child categories:', error);
      return [];
    }
  }

  addProduct(): void {
    this.productService.addProduct(this.product).subscribe(
      (response) => {
        //this.toastr.success('Product added successfully!'); 
        console.log('Product added:', response);
      },
      (error) => {
        //this.toastr.error('Failed to add product.'); 
        console.error('Error adding product:', error);
      }
    );
    console.log('Product data:', this.product);
  }
}
