import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map, ReplaySubject } from 'rxjs';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
 
  private readonly route = 'auth';

  private isAuthenticatedSubject = new ReplaySubject<boolean>(1);
  public isAuthenticated = this.isAuthenticatedSubject.asObservable();

  constructor(private readonly apiService: ApiService, private http: HttpClient) { }

  updateAuthenticationStatus() {
    this.isAuthenticatedSubject.next(true);
  }

  login(userCredentials: any) {
    return this.apiService.post<any>(this.route + '/login', userCredentials).pipe(
      map((response: any) => {
        if (response) {
          localStorage.setItem('jwtToken', response.token);
          this.isAuthenticatedSubject.next(true);
        }
      })
    );
  }

  signup(registerInfo: any) {
    return this.apiService.post<any>(this.route + '/signup', registerInfo);
  }

  isLoggedIn() {
    const token = localStorage.getItem('jwtToken');
    return token != null;
  }

  logout() {
    localStorage.removeItem('jwtToken');
    this.isAuthenticatedSubject.next(false);
  }
  isAdmin(): Observable<boolean> {

    return this.http.get<boolean>('https://localhost:7034/api/auth/is-admin');
  }
  
}
