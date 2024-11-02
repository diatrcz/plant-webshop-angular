import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Product } from '../../models/product.type';
import { ProductService } from '../../services/product-service/product.service';
import { CategoryService } from '../../services/category-service/category.service';
import { Category } from '../../models/category.type';
import { ShoppingCartService } from '../../services/shoppingcart-service/shopping-cart.service';
import { CartItem } from '../../models/cartitem.type';
import { AuthService } from '../../services/auth-service/auth.service';
import { UserService } from '../../services/user-service/user.service';

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
  isLoggedIn!: boolean;
  userType!: number;
  isDeleteDialogOpen = false;

  constructor(
    private route: ActivatedRoute, 
    private productService: ProductService,
    private categoryService: CategoryService,
    private cartService: ShoppingCartService,
    private authService: AuthService,
    private userService: UserService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.loadData();
  }

  async loadData(): Promise<void> {
    await this.loadRoute();
    await this.loadUserInfo();
    await this.loadProduct();

    console.log(this.isLoggedIn);
    console.log(this.userType);
  }

  loadUserInfo(): Promise<void> {
    return new Promise((resolve) => {
      this.isLoggedIn = this.authService.isLoggedIn();
      if (this.isLoggedIn) {
        this.userService.getUserType().subscribe(userType => {
          this.userType = userType.valueOf();
          resolve(); 
        });
      } else {
        this.userType = 2;
        resolve(); 
      }
    });
  }

  loadRoute(): Promise<void> {
    return new Promise((resolve) => {
      this.route.paramMap.subscribe(params => {
        const id = params.get('id');
        if (id !== null) {
          this.productId = id; 
        }
        resolve(); 
      });
    });
  }

  loadProduct(): Promise<void> {
    return new Promise((resolve, reject) => {
      this.productService.fetchProductDetails(this.productId)
        .subscribe(product => {
          this.product = product;
          this.loadCategory(product.categoryId);
          resolve(); // Resolve after the product is loaded
        }, error => {
          console.error('Error fetching product data:', error);
          reject(error); // Reject the promise on error
        });
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
    if(this.isLoggedIn) {
      this.isButtonRed = !this.isButtonRed;
    }
    else {
      this.router.navigate(['/login-user']);
    }
  }

  addToCart(): void {
    if (!this.product) return;
    const cartItem: CartItem = {
      id: this.product.id,
      quantity: this.quantity
    };
    this.cartService.addToCart(cartItem);
    this.quantity = 1;
  }

  openDeleteDialog() {
    this.isDeleteDialogOpen = true;
  }

  closeDeleteDialog() {
    this.isDeleteDialogOpen = false;
  }

  deleteProduct() {
    this.productService.deleteProduct(this.product.id).subscribe(
      () => {
        alert('Product deleted successfully');
        this.router.navigate(['/products']);
      },
      (error) => console.error('Error deleting product', error)
    );

    this.router.navigate(['/main']);
  }

}
