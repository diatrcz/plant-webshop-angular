import { Component } from '@angular/core';
import { UserService } from '../../services/user-service/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  email!: string;
  password!: string;
  firstName!: string;
  lastName!: string;

  constructor(private userService: UserService, private router: Router) {}

  register() {
    this.userService.register(this.email, this.password, this.firstName, this.lastName)
      .subscribe(
        response => {
          console.log('Registration successful:', response);
          this.router.navigate(['/main']);
        },
        error => {
          console.error('Registration failed:', error);
        }
      );
  }
}
