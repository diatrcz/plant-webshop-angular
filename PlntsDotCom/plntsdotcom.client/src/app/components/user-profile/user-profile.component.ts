import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/auth-service/auth.service';
import { UserService } from '../../services/user-service/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrl: './user-profile.component.css'
})
export class UserProfileComponent implements OnInit{
  userInfo: any;

  constructor(private authService: AuthService, 
              private userService: UserService,
              private router: Router
  ) { }

  async ngOnInit(): Promise<void> {
    await this.loadUserInfo();
  }

  async loadUserInfo(): Promise<void> {
    try {
      this.userInfo = await this.userService.getUserInfo().toPromise();
      console.log('User info:', this.userInfo);
    } catch (error) {
      console.error('Error fetching user info:', error);
    }
  }

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
