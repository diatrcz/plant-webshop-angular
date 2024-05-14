import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth-service/auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent {
  dialogVisible: boolean = false;
  searchInput: string = '';
  isLoggedIn: boolean;

  constructor(private router: Router, 
              private authService: AuthService) {
    this.isLoggedIn = this.authService.isLoggedIn();
    console.log(this.isLoggedIn);
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
