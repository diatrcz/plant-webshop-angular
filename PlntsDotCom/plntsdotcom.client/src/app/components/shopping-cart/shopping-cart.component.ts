import { Component, OnInit } from '@angular/core';
import { ShoppingCartService } from '../../services/shoppingcart-service/shopping-cart.service';
import { CartItem } from '../../models/cartitem.type';
import { Product } from '../../models/product.type';
import { ProductService } from '../../services/product-service/product.service';
import { AuthService } from '../../services/auth-service/auth.service';
import { Router } from '@angular/router';

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
    private authService: AuthService,
    private router: Router
  ) {
    this.isLoggedIn = authService.isLoggedIn();
  }

  ngOnInit(): void {
    this.loadCartItems(); 
  }

  loadCartItems(): void {
    this.cartItems = this.cartService.getCartFromLocalStorage();
    this.cartItems.forEach((item) => {
      this.productService.fetchProductDetails(item.id.toString())
      .subscribe(product => {
        product.quantity = item.quantity;
        this.products.push(product);
        this.total += product.quantity! * product.price;
      });
    });
  }

  removeItem(index: number): void {
    this.cartItems.splice(index, 1);
    this.cartService.saveCartToLocalStorage(this.cartItems); 
  }

  updateQuantity(change: number, productId: number): void {
    const index = this.products.findIndex(product => product.id === productId);
    if (index !== -1) {
      const updatedQuantity = this.products[index].quantity! + change;
      if (updatedQuantity >= 0 && updatedQuantity <= this.products[index].stock!) {
        this.products[index].quantity = updatedQuantity;
        this.total += this.products[index].price * change;
      }
    }
  }

  placeOrder() {
    if(this.isLoggedIn) {
      console.log("Ok");
    }
    else {
      this.router.navigate(['/login-user']);
    }
  }

}
