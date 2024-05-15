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

  constructor(private router: Router, 
              private authService: AuthService,
              private userService: UserService) {
    this.isLoggedIn = this.authService.isLoggedIn();
    console.log(this.isLoggedIn);
    if(this.isLoggedIn) {
      this.getUserName();
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

  onSearch() {
    if (this.searchInput.trim() !== '') {
      this.router.navigate(['/search-results'], { queryParams: { query: this.searchInput } });
    }
    this.closeDialog();
  }

}
