import { Component, Input, OnInit } from '@angular/core';
import { Category } from '../../models/category.type';
import { AuthService } from '../../services/auth-service/auth.service';
import { Router } from '@angular/router';
import { UserService } from '../../services/user-service/user.service';

@Component({
  selector: 'app-product-list-item',
  templateUrl: './product-list-item.component.html',
  styleUrl: './product-list-item.component.css'
})
export class ProductListItemComponent implements OnInit {
  @Input() productId!: number; 
  @Input() name!: string;
  @Input() imageUrl?: string | null;
  @Input() price!: number;
  @Input() category?: string | null;
  isInWishlist: boolean = false;
  isLoggedIn: boolean;
  isLoading: boolean = false;

  constructor(
    private authService: AuthService,
    private userService: UserService,
    private router: Router
  ) {
    this.isLoggedIn = this.authService.isLoggedIn();
  }

  ngOnInit() {
    if (this.isLoggedIn) {
      this.checkWishlistStatus();
    }
  }

  private checkWishlistStatus() {
    this.userService.checkWishlistItem(this.productId).subscribe({
      next: (response) => {
        this.isInWishlist = response.isInWishlist;
      },
      error: (error) => {
        console.error('Error checking wishlist status:', error);
      }
    });
  }

  toggleWishlist() {
    if (!this.isLoggedIn) {
      this.router.navigate(['/login-user']);
      return;
    }

    this.isLoading = true;

    if (this.isInWishlist) {
      this.userService.removeFromWishlist(this.productId).subscribe({
        next: () => {
          this.isInWishlist = false;
          this.isLoading = false;
        },
        error: (error) => {
          console.error('Error removing from wishlist:', error);
          this.isLoading = false;
        }
      });
    } else {
      this.userService.addToWishlist(this.productId).subscribe({
        next: () => {
          this.isInWishlist = true;
          this.isLoading = false;
        },
        error: (error) => {
          console.error('Error adding to wishlist:', error);
          this.isLoading = false;
        }
      });
    }
  }
}