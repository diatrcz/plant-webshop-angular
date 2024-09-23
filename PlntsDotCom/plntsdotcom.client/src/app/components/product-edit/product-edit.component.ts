import { Component, OnInit } from '@angular/core';
import { Product } from '../../models/product.type';
import { Category } from '../../models/category.type';
import { ProductService } from '../../services/product-service/product.service';
import { CategoryService } from '../../services/category-service/category.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-product-edit',
  templateUrl: './product-edit.component.html',
  styleUrl: './product-edit.component.css'
})
export class ProductEditComponent implements OnInit {
  productId!: string;
  product!: Product;
  parentCategories!: Category[];
  //childrenCategories!: Category;

  constructor(
    private route: ActivatedRoute, 
    private productService: ProductService,
    private categoryService: CategoryService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.loadRoute();
    this.loadProductDetails();
    this.loadParentCategories();
  }

  loadRoute() {
    this.route.paramMap.subscribe(params => {
      const id = params.get('id');
      if (id !== null) {
        this.productId = id; 
      }
    });
  }

  loadProductDetails() {
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
  
  loadParentCategories() {
    this.categoryService.fetchParentCategories()
    .subscribe(parentCategories => {
      this.parentCategories = parentCategories;
    }, error => {
      console.error('Error fetching Parentcategory data:', error);
    });
  }

  updateProduct() {
    this.productService.updateProduct(this.product).subscribe(response => {
      if (response) {
        console.log("Product update OK");
      } else {
        console.error("Error during product update");
      }
    });

    this.router.navigate(['/product', this.productId]);
  }
}

