import { Injectable } from '@angular/core';
import { CartItem } from '../../models/cartitem.type';

@Injectable({
  providedIn: 'root'
})
export class ShoppingCartService {
  constructor() { }

   saveCartToLocalStorage(cartItems: CartItem[]): void {
    try {
      localStorage.setItem('cartItems', JSON.stringify(cartItems));
    } catch (e) {
      console.error('Error saving to localStorage', e);
    }
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

  clearCart(): void {
    try {
      localStorage.removeItem('cartItems');
      console.log('Cart cleared successfully');
    } catch (e) {
      console.error('Error clearing cart from localStorage', e);
    }
  }
}
