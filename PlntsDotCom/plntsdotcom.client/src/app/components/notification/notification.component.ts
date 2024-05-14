import { Component, OnDestroy } from '@angular/core';
import { NotificationService } from '../../services/notification-service/notification.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-notification',
  templateUrl: './notification.component.html',
  styleUrl: './notification.component.css'
})
export class NotificationComponent {
  message: string = '';

  constructor(private notificationService: NotificationService) {
    this.notificationService.notification$.subscribe(message => {
      this.message = message;
    });
  }

  clearMessage() {
    this.message = '';
  }
}
