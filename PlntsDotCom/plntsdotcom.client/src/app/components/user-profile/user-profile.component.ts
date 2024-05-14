import { Component } from '@angular/core';
import { AuthService } from '../../services/auth-service/auth.service';
import { UserService } from '../../services/user-service/user.service';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrl: './user-profile.component.css'
})
export class UserProfileComponent {

  constructor(private authService: AuthService, private userService: UserService) { }

  logout() {
    this.userService.logout().subscribe(
      response => {
        this.authService.clearLoggedInUser();
      }, 
      error => {
        console.error('Logout failed:', error);
      }
    );
  }
}
