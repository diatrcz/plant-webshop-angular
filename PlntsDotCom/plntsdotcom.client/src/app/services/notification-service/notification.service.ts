import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {

  private notificationSubject = new Subject<string>();

  notification$ = this.notificationSubject.asObservable();

  constructor() { }

  showSuccess(message: string) {
    this.notificationSubject.next(message);
  }
}
