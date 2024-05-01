import { Injectable } from '@angular/core';
import { CartItem } from '../../models/cartitem.type';

@Injectable({
  providedIn: 'root'
})
export class ShoppingCartService {
  constructor() { }

   saveCartToLocalStorage(cartItems: CartItem[]): void {
    localStorage.setItem('cartItems', JSON.stringify(cartItems));
  }

  getCartFromLocalStorage(): CartItem[] {
    const cartItemsJSON = localStorage.getItem('cartItems');
    return cartItemsJSON ? JSON.parse(cartItemsJSON) : [];
  }

  addToCart(cartItem: CartItem): void {
    let cartItems = this.getCartFromLocalStorage();
    const existingItemIndex = cartItems.findIndex(item => item.id === cartItem.id);

    if (existingItemIndex !== -1) {
      cartItems[existingItemIndex].quantity += cartItem.quantity;
    } else {
      cartItems.push(cartItem);
    }

    this.saveCartToLocalStorage(cartItems);
  }
}
