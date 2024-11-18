import { Component, OnInit } from '@angular/core';
import { UserService } from '../../services/user-service/user.service';
import { Router } from '@angular/router';
import { Product } from '../../models/product.type';

@Component({
  selector: 'app-wishlist',
  templateUrl: './wishlist.component.html',
  styleUrl: './wishlist.component.css'
})
export class WishlistComponent implements OnInit {
  wishlistItems: Product[] = [];
  isLoading = false;
  error: string | null = null;

  constructor(
    private userService: UserService,
    private router: Router
  ) {}

  ngOnInit() {
    this.loadWishlist();
  }

  loadWishlist() {
    this.isLoading = true;
    this.userService.getWishlist().subscribe({
      next: (items) => {
        this.wishlistItems = items;
        this.isLoading = false;
      },
      error: (error) => {
        this.error = error;
        this.isLoading = false;
      }
    });
  }

  navigateToProductList() {
    this.router.navigate(['/shop/plants']);
  }
}
