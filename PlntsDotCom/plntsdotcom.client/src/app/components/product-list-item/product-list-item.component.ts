import { Component, Input } from '@angular/core';
import { Category } from '../../models/category.type';
import { AuthService } from '../../services/auth-service/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-product-list-item',
  templateUrl: './product-list-item.component.html',
  styleUrl: './product-list-item.component.css'
})
export class ProductListItemComponent {
  @Input() productId!: number; 
  @Input() name!: string;
  @Input() imageUrl?: string | null;
  @Input() price!: number;
  @Input() category?: string | null;
  isButtonRed: boolean = false;
  isLoggedIn: boolean;

  constructor(private authService: AuthService, private router: Router) {
    this.isLoggedIn = this.authService.isLoggedIn();
   }

  toggleClick() {
    if(this.isLoggedIn) {
      this.isButtonRed = !this.isButtonRed;
    }
    else {
      this.router.navigate(['/login-user']);
    }
  }
}
