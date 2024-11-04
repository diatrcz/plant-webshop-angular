import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth-service/auth.service';
import { UserService } from '../../services/user-service/user.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent {
  dialogVisible: boolean = false;
  searchInput: string = '';
  isLoggedIn: boolean;
  username: string = '';
  dropdownOpen = false;
  userType!: number;
  addProduct: string = "product";
  addCategory: string = "category";

  constructor(private router: Router, 
              private authService: AuthService,
              private userService: UserService
  ) {
    this.isLoggedIn = this.authService.isLoggedIn();
    console.log(this.isLoggedIn);
    if(this.isLoggedIn) {
      this.getUserName();
      this.userService.getUserType().subscribe(userType => {
        this.userType = userType.valueOf();
      });
    }
  }

  getUserName() {
    this.userService.getUserName().subscribe(
      response => {
        this.username = response.userName;
      },
      error => {
        console.error('Get username failed:', error);
      }
    );
  }

  navigateToRoot() {
    this.router.navigate(['/']);
  }

  openDialog() {
    this.dialogVisible = true;
    console.log('open dialog');
  }

  closeDialog() {
    this.dialogVisible = false;
  }

  toggleDropdown() {
    this.dropdownOpen = !this.dropdownOpen;
  }

  onSearch() {
    if (this.searchInput.trim() !== '') {
      this.router.navigate(['/search-results'], { queryParams: { query: this.searchInput } });
    }
    this.closeDialog();
  }

}
