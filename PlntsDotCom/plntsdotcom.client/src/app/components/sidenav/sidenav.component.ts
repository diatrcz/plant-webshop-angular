import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../../services/user-service/user.service';
import { AuthService } from '../../services/auth-service/auth.service';

@Component({
  selector: 'app-sidenav',
  templateUrl: './sidenav.component.html',
  styleUrl: './sidenav.component.css'
})
export class SidenavComponent {
  
  constructor(
    private userService: UserService,
    private authService: AuthService,
    private router: Router
  ) {}

  logout() {
    this.userService.logout().subscribe(
      response => {
        this.authService.clearLoggedInUser();
        this.router.navigate(['/main']);
      },
      error => {
        console.error('Logout failed:', error);
      }
    );
  }
}
