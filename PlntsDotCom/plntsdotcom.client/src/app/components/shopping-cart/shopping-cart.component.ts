import { Component, OnInit } from '@angular/core';
import { ShoppingCartService } from '../../services/shoppingcart-service/shopping-cart.service';
import { CartItem } from '../../models/cartitem.type';
import { Product } from '../../models/product.type';
import { ProductService } from '../../services/product-service/product.service';

@Component({
  selector: 'app-shopping-cart',
  templateUrl: './shopping-cart.component.html',
  styleUrl: './shopping-cart.component.css'
})
export class ShoppingCartComponent implements OnInit {
  cartItems: CartItem[] = [];
  products: Product [] = [];
  total: number = 0;

  constructor(
    private cartService: ShoppingCartService,
    private productService: ProductService
  ) {}

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

}
