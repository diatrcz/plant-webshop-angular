import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  register(email: string, password: string, firstName: string, lastName: string, role = 1) {
    return this.http.post<any>('register', { email, password, firstName, lastName, role });
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
}
