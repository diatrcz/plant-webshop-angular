import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserService } from '../../services/user-service/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  /*email!: string;
  password!: string;
  firstName!: string;
  lastName!: string;
  registrationError: string | null = null;*/
  registerForm: FormGroup;

  constructor(
    private userService: UserService, 
    private router: Router,
    private fb: FormBuilder,
  ) {
    this.registerForm = this.fb.group({
      firstName: ['', [Validators.required]],
      lastName: ['', [Validators.required]],
      email: ['', [Validators.required, Validators.email]], 
      password: ['', [
        Validators.required,
        Validators.minLength(6),
        Validators.pattern('^(?=.*\\d)(?=.*\\W).+$')
      ]]
    });
  }

  get firstName() {
    return this.registerForm.get('firstName');
  }
  get lastName() {
    return this.registerForm.get('lastName');
  }
  get email() {
    return this.registerForm.get('email');
  }
  get password() {
    return this.registerForm.get('password');
  }

  register() {
    if (this.registerForm.valid) {
      const { email, password, firstName, lastName } = this.registerForm.value;
      this.userService
        .register(email, password, firstName, lastName)
        .subscribe(
          (response) => {
            console.log('Registration successful:', response);
            this.router.navigate(['/main']);
          },
          (error) => {
            console.error('Registration failed:', error);
          }
        );
    } else {
      this.registerForm.markAllAsTouched();
    }
  }
}
