import { Component, OnInit } from '@angular/core';
import { ShoppingCartService } from '../../services/shoppingcart-service/shopping-cart.service';
import { CartItem } from '../../models/cartitem.type';
import { Product } from '../../models/product.type';
import { ProductService } from '../../services/product-service/product.service';
import { AuthService } from '../../services/auth-service/auth.service';
import { Router } from '@angular/router';
import { forkJoin } from 'rxjs';
import { map } from 'rxjs/operators';
import { OrderService } from '../../services/order-service/order.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-shopping-cart',
  templateUrl: './shopping-cart.component.html',
  styleUrl: './shopping-cart.component.css'
})
export class ShoppingCartComponent implements OnInit {
  cartItems: CartItem[] = [];
  products: Product [] = [];
  total: number = 0;
  isLoggedIn: boolean;

  constructor(
    private cartService: ShoppingCartService,
    private productService: ProductService,
    private orderService: OrderService,
    private authService: AuthService,
    private router: Router,
    private snackBar: MatSnackBar
  ) {
    this.isLoggedIn = authService.isLoggedIn();
  }

  ngOnInit(): void {
    this.loadCartItems(); 
  }

  loadCartItems(): void {
    // Load cart items from local storage
    this.cartItems = this.cartService.getCartFromLocalStorage();

    // Create an array of observables to fetch product details for each cart item
    const productObservables = this.cartItems.map((item) =>
      this.productService.fetchProductDetails(item.id.toString()).pipe(
        map((product: Product) => ({
          ...product,
          quantity: item.quantity
        }))
      )
    );

    // Use forkJoin to wait until all product details are fetched
    forkJoin<Product[]>(productObservables).subscribe((products) => {
      // Set fetched products, sort by ID, and calculate the total
      this.products = products.sort((a, b) => a.id - b.id);
      this.total = this.products.reduce((sum, product) => sum + (product.quantity! * product.price), 0);
    });
  }

  removeItem(productId: number): void {
    const index = this.products.findIndex(product => product.id === productId);
    this.cartItems.splice(index, 1);
    this.cartService.saveCartToLocalStorage(this.cartItems);
    window.location.reload();
  }

  updateQuantity(change: number, productId: number): void {
    const index = this.products.findIndex(product => product.id === productId);
    if (index !== -1) {
      const updatedQuantity = this.products[index].quantity! + change;
      if (updatedQuantity >= 0 && updatedQuantity <= this.products[index].stock!) {
        this.products[index].quantity = updatedQuantity;
        this.total += this.products[index].price * change;

        const cartItemIndex = this.cartItems.findIndex(item => item.id === productId);
        if (cartItemIndex !== -1) {
          this.cartItems[cartItemIndex].quantity = updatedQuantity;
        }

        if(this.products[index].quantity === 0) {
          this.removeItem(productId);
        }
        else {
          this.cartService.saveCartToLocalStorage(this.cartItems);
        }
        
      }
    }
  }

  placeOrder() {
    if (!this.isLoggedIn) {
      this.router.navigate(['/login']);
      return;
    }

    this.orderService.placeOrder(this.cartItems).subscribe({
      next: (response) => {
        this.snackBar.open('Order placed successfully!', 'Close', { 
          duration: 3000,
          horizontalPosition: 'center',
          verticalPosition: 'top'
        });
        this.router.navigate(['/order', response.orderId]);
      },
      error: (error) => {
        this.snackBar.open('Failed to place order: ' + error.message, 'Close', { 
          duration: 3000,
          horizontalPosition: 'center',
          verticalPosition: 'top'
        });
      }
    });
  }

}
