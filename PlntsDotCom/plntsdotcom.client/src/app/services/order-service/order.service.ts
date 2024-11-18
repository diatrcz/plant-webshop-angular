import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ShoppingCartService } from '../shoppingcart-service/shopping-cart.service';
import { CartItem } from '../../models/cartitem.type';
import { Observable } from 'rxjs';
import { tap } from 'rxjs';
import { Order } from '../../models/order.type';

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  private apiUrl = 'api/order';

  constructor(
    private http: HttpClient,
    private cartService: ShoppingCartService
  ) {}

  placeOrder(cartItems: CartItem[]): Observable<{ orderId: number }> {
    const orderDto = {
      items: cartItems.map(item => ({
        productId: item.id,
        quantity: item.quantity
      }))
    };

    return this.http.post<{ orderId: number }>(`${this.apiUrl}/place`, orderDto).pipe(
      tap(() => {
        this.cartService.clearCart();
      })
    );
  }

  getOrder(orderId: number): Observable<Order> {
    return this.http.get<Order>(`${this.apiUrl}/${orderId}`);
  }

  getAllOrders(): Observable<Order[]> {
    return this.http.get<Order[]>(this.apiUrl);
  }
}