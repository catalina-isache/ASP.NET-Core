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
  private readonly baseUrl = 'https://localhost:7034/api/user';

  constructor(private http: HttpClient, private authService: AuthService) { }

  authenticate(email: string, password: string): Observable<UserAuthResponseDto> {
    const user = { email: email, password: password };
    return this.http.post<UserAuthResponseDto>(`${this.baseUrl}/Login`, user).pipe(
      tap((response: any) => {
        if (response) {
          localStorage.setItem('jwtToken', response.tokenString);
          this.authService.updateAuthenticationStatus(); 
        }
      })
    );
  }

  create(user: UserAuthRequestDto): Observable<User> {
    return this.http.post<User>(`${this.baseUrl}/Register`, user);
  }


  getAll(): Observable<User[]> {
    return this.http.get<User[]>(`https://localhost:7034/api/auth/user`);
  }


  getById(id: string): Observable<User> {
    return this.http.get<User>(`https://localhost:7034/api/auth/${id}`);
  }
}
