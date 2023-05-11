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
  userId: Pick<Post, 'id'> | undefined;

  private url = 'https://localhost:7291/api/Users/PostHoliday';

  httpOptions: { headers: HttpHeaders } = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  };

  constructor(
    private http: HttpClient,
    private errorHandlerService: ErrorHandlerService,
    private router: Router
  ) {}

  postHoliday(post: Omit<Post, 'id'>): Observable<Post> {
    return this.http
      .post<Post>(`${this.url}`, post, this.httpOptions)
      .pipe(
        first(),
        catchError(this.errorHandlerService.handleError<Post>('postHoliday'))
      );
  }
}
