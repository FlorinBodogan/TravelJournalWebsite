import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { first, catchError, tap } from 'rxjs/operators';
import { User } from '../models/User';
import { ErrorHandlerService } from './error-handler.service';
import { Router } from '@angular/router';
import jwt_decode from 'jwt-decode';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private url = 'https://localhost:7291/api/Users/PostUser';
  private url2 = 'https://localhost:7291/api/Users/Login';

  isUserLogged$ = new BehaviorSubject<boolean>(false);

  userId: string | null | undefined;

  httpOptions: { headers: HttpHeaders } = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  };

  constructor(
    private http: HttpClient,
    private errorHandlerService: ErrorHandlerService,
    private router: Router
  ) {}

  register(user: Omit<User, 'id'>): Observable<User> {
    return this.http
      .post<User>(`${this.url}`, user, this.httpOptions)
      .pipe(
        first(),
        catchError(this.errorHandlerService.handleError<User>('register'))
      );
  }

  login({
    email,
    password,
  }: {
    email: Pick<User, 'email'>;
    password: Pick<User, 'password'>;
  }): Observable<{ userId: Pick<User, 'id'>; user: User }> {
    return this.http
      .post(`${this.url2}`, { email, password }, this.httpOptions)
      .pipe(
        first(Object),
        tap((response) => {
          localStorage.setItem('userId', JSON.stringify(response.id));
          this.isUserLogged$.next(true);
          this.router.navigate(['home']);
        }),
        catchError(
          this.errorHandlerService.handleError<{
            userId: Pick<User, 'id'>;
            user: User;
          }>('login')
        )
      );
  }
}
