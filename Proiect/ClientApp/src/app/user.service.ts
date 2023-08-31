import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { UserAuthRequestDto } from './UserAuthRequestDto.model';
import { UserAuthResponseDto } from './UserAuthResponseDto.model';
import { User } from './user.model';
import { AuthService } from './auth.service';
import { tap } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class UserService {
  private readonly baseUrl = 'https://localhost:7034/api/auth';

  constructor(private http: HttpClient, private authService: AuthService) { }

  authenticate(email: string, password: string): Observable<UserAuthResponseDto> {
    const user = { email: email, password: password };
    return this.http.post<UserAuthResponseDto>(`${this.baseUrl}/login-user`, user).pipe(
      tap((response: any) => {
        if (response) {
          localStorage.setItem('jwtToken', response.jwtToken);
          this.authService.updateAuthenticationStatus(); // Update authentication status
        }
      })
    );
  }

  create(user: UserAuthRequestDto): Observable<User> {
    return this.http.post<User>(`${this.baseUrl}/create-user`, user);
  }


  getAll(): Observable<User[]> {
    return this.http.get<User[]>(`${this.baseUrl}/user`);
  }


  getById(id: string): Observable<User> {
    return this.http.get<User>(`${this.baseUrl}/${id}`);
  }
}
