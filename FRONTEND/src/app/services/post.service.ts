import { Injectable } from '@angular/core';
import { Post } from '../models/Post';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { first, catchError, tap } from 'rxjs/operators';
import { Router } from '@angular/router';
import { ErrorHandlerService } from './error-handler.service';

@Injectable({
  providedIn: 'root',
})
export class PostService {
  userId = localStorage.getItem('userId')!.replace(/"/g, '');

  private url = 'https://localhost:7291/api/Users/PostHoliday';
  private url2 = 'https://localhost:7291/api/Users/GetHoliday';

  httpOptions: { headers: HttpHeaders } = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  };

  constructor(
    private http: HttpClient,
    private errorHandlerService: ErrorHandlerService,
    private router: Router
  ) {}

  postHoliday(post: Omit<Post, 'id'>, userId: string): Observable<Post> {
    const postWithUserId = { ...post, userId: this.userId };
    return this.http
      .post<Post>(this.url, postWithUserId, this.httpOptions)
      .pipe(
        first(),
        catchError(this.errorHandlerService.handleError<Post>('postHoliday'))
      );
  }

  fetchHoliday(userId: string): Observable<Post[]> {
    const urlWithParams = `${this.url2}?userId=${userId}`;
    return this.http
      .get<Post[]>(urlWithParams, { responseType: 'json' })
      .pipe(
        catchError(this.errorHandlerService.handleError<Post[]>('holidays', []))
      );
  }
}
