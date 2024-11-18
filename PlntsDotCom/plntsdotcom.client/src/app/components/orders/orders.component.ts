import { Component, OnInit } from '@angular/core';
import { Order } from '../../models/order.type';
import { OrderService } from '../../services/order-service/order.service';
import { AuthService } from '../../services/auth-service/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrl: './orders.component.css'
})
export class OrdersComponent implements OnInit {
  orders: Order[] = [];
  isLoggedIn: boolean = false;
  isLoading: boolean = true;
  error: string | null = null;

  constructor(
    private orderService: OrderService,
    private authService: AuthService,
    private router: Router
  ) {
    this.isLoggedIn = this.authService.isLoggedIn();
  }

  ngOnInit() {
    if (this.isLoggedIn) {
      this.loadOrders();
    }
  }

  loadOrders() {
    this.isLoading = true;
    this.error = null;
    
    this.orderService.getAllOrders().subscribe({
      next: (orders) => {
        this.orders = orders;
        this.isLoading = false;
      },
      error: (error) => {
        console.error('Error fetching orders:', error);
        this.error = 'Failed to load orders. Please try again.';
        this.isLoading = false;
      }
    });
  }

  viewOrderDetails(orderId: number) {
    this.router.navigate(['/order', orderId]);
  }

  navigateToLogin() {
    this.router.navigate(['/login-user']);
  }

  navigateToProducts() {
    this.router.navigate(['/shop/plants']);
  }
}
