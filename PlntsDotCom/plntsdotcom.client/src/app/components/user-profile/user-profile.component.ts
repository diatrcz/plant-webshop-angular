import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/auth-service/auth.service';
import { UserService } from '../../services/user-service/user.service';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { User } from '../../models/user.type';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrl: './user-profile.component.css'
})
export class UserProfileComponent implements OnInit {
  user: User | null = null;
  isEditing = false;
  isLoading = true;
  error: string | null = null;
  profileForm: FormGroup;

  constructor(
    private authService: AuthService,
    private userService: UserService,
    private router: Router,
    private fb: FormBuilder
  ) {
    this.profileForm = this.fb.group({
      firstName: ['', Validators.required],
      lastName: [''],
      phoneNumber: [''],
      address: ['']
    });
  }

  ngOnInit(): void {
    this.loadUserInfo();
  }

  loadUserInfo(): void {
    this.isLoading = true;
    this.userService.getUserInfo().subscribe({
      next: (response) => {
        this.user = response.user;
        if (this.user) {
          this.profileForm.patchValue({
            firstName: this.user.firstName,
            lastName: this.user.lastName,
            phoneNumber: this.user.phoneNumber,
            address: this.user.address
          });
        }
        this.isLoading = false;
      },
      error: (error) => {
        console.error('Error loading user info:', error);
        this.error = 'Failed to load user information';
        this.isLoading = false;
      }
    });
  }

  toggleEdit(): void {
    this.isEditing = !this.isEditing;
    if (!this.isEditing && this.user) {
      this.profileForm.patchValue({
        firstName: this.user.firstName,
        lastName: this.user.lastName,
        phoneNumber: this.user.phoneNumber,
        address: this.user.address
      });
    }
  }

  onSubmit(): void {
    if (this.profileForm.valid && this.user) {
      const updatedData = this.profileForm.value;
      this.userService.updateUserInfo(updatedData).subscribe({
        next: () => {
          if (this.user) {
            this.user = { ...this.user, ...updatedData };
          }
          this.isEditing = false;
        },
        error: (error) => {
          console.error('Error updating profile:', error);
        }
      });
    }
  }
}