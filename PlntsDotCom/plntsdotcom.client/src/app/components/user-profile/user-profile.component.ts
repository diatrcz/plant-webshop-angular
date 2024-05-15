import { Component } from '@angular/core';
import { AuthService } from '../../services/auth-service/auth.service';
import { UserService } from '../../services/user-service/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrl: './user-profile.component.css'
})
export class UserProfileComponent {

  constructor(private authService: AuthService, 
              private userService: UserService,
              private router: Router
            ) { }

  logout() {
    this.userService.logout().subscribe(
      response => {
        this.authService.clearLoggedInUser();
        console.log("out");
        this.router.navigate(['/main']);

      }, 
      error => {
        console.error('Logout failed:', error);
      }
    );
  }
}
