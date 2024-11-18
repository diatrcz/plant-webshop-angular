import { Component, OnInit } from '@angular/core';
import { Order } from '../../models/order.type';
import { ActivatedRoute, Router } from '@angular/router';
import { OrderService } from '../../services/order-service/order.service';

@Component({
  selector: 'app-order-details',
  templateUrl: './order-details.component.html',
  styleUrl: './order-details.component.css'
})
export class OrderDetailsComponent implements OnInit {
  order: Order | null = null;

  constructor(
    private route: ActivatedRoute,
    private orderService: OrderService,
    private router: Router
  ) {}

  ngOnInit() {
    const orderId = this.route.snapshot.paramMap.get('id');
    if (orderId) {
      this.orderService.getOrder(parseInt(orderId))
        .subscribe({
          next: (order) => {
            this.order = order;
          },
          error: (error) => {
            console.error('Error fetching order:', error);
          }
        });
    }
  }

  goBack() {
    this.router.navigate(['/orders']);
  }
}
