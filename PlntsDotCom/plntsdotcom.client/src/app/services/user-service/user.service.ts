import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  register(email: string, password: string, firstName: string, lastName: string) {
    return this.http.post<any>('api/User/register', { email, password, firstName, lastName })
      .pipe(
        catchError(error => {
          const errorMessage = error.error.Errors ? error.error.Errors.join(', ') : 'Registration failed. Please try again.';
          return throwError(errorMessage);
        })
      );
  }

  login(email: string, password: string) {
    return this.http.post<any>('login', { email, password });
  }

  logout() {
    return this.http.post<any>('api/User/logout', {}); 
  }

  getUserName() {
    return this.http.get<any>('api/User/name');
  }

  getUserType(): Observable<number> {
    return this.http.get<{ userType: number }>('api/User/type').pipe(
      map(response => response.userType)
    );
  }

  getUserInfo(): Observable<any> {
    return this.http.get<any>('api/User/user');
  }
  
}
