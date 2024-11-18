import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
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

  getUserInfo() {
    return this.http.get<any>(`api/User/user`)
      .pipe(
        catchError(this.handleError)
      );
  }

  updateUserInfo(userData: any) {
    return this.http.put<any>(`api/User/update`, userData)
      .pipe(
        catchError(this.handleError)
      );
  }

  private handleError(error: HttpErrorResponse) {
    let errorMessage = 'An error occurred';

    if (error.error instanceof ErrorEvent) {
      // Client-side error
      errorMessage = error.error.message;
    } else if (error.error?.Errors) {
      // Server-side validation errors
      errorMessage = Array.isArray(error.error.Errors) 
        ? error.error.Errors.join(', ') 
        : error.error.Errors;
    } else if (error.error?.message) {
      // Server-side error with message
      errorMessage = error.error.message;
    } else if (error.status === 401) {
      errorMessage = 'Please login to continue';
    } else if (error.status === 404) {
      errorMessage = 'Resource not found';
    }

    console.error('API Error:', error);
    return throwError(() => errorMessage);
  }
  
}
