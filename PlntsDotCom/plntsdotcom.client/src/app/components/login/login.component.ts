import { Component } from '@angular/core';
import { UserService } from '../../services/user-service/user.service';
import { AuthService } from '../../services/auth-service/auth.service';
import { Router } from '@angular/router';
import { NotificationService } from '../../services/notification-service/notification.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  email: string = '';
  password: string = '';
  errorMessage: string = '';

  constructor(
    private userService: UserService,
    private authService: AuthService,
    private notificationService: NotificationService,
    private router: Router
  ) {}

  login() {
    this.userService.login(this.email, this.password)
      .subscribe(
        response => {
          const { userId, accessToken, refreshToken } = response;
          this.authService.setLoggedInUser(userId, accessToken, refreshToken);
          console.log(response);
          this.router.navigate(['/main']);
          this.notificationService.showSuccess('Login successful');
        },
        error => {
          console.error('Login failed:', error);
          this.errorMessage = 'Invalid email or password';
        }
      );
  }
}
