import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { User } from '../models/User';
import { ErrorHandlerService } from './error-handler.service';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private url = 'https://localhost:7291/api/Users/GetUserStatus';

  userId = localStorage.getItem('userId')!.replace(/"/g, '');

  httpOptions: { headers: HttpHeaders } = {
    headers: new HttpHeaders({ 'Content-Type': 'multipart/form-data' }),
  };

  constructor(
    private http: HttpClient,
    private errorHandlerService: ErrorHandlerService,
    private router: Router
  ) {}

  //curent user info
  fetchUser(userId: string): Observable<User> {
    const urlWithParams = `${this.url}?userId=${userId}`;
    return this.http
      .get<{ userStatus: string }>(urlWithParams, { responseType: 'json' })
      .pipe(
        map(
          (response) =>
            ({ ...response, status: response.userStatus } as unknown as User)
        ),
        catchError(this.errorHandlerService.handleError<User>('fetchUser'))
      );
  }

  //edit user info

  //curent user photo
  // fetchUserPhoto(): Observable<Images[]>{
  //   return this.http.get<Images[]>(`${this.url}/images`, {responseType: "json"}).pipe(catchError(this.errorHandlerService.handleError<Images[]>("fetchUserPhoto", [])));
  // }

  // uploadPhoto(uploadFormData: Partial<Images>, userId: Pick<User, "id"> ): Observable<Images>{
  //   return this.http
  //   .post<Images>(`${this.url}/images`, {image: uploadFormData.image, user: userId}, this.httpOptions)
  //   .pipe(
  //     catchError(this.errorHandlerService.handleError<Images>("uploadPhoto"))
  //   );
  // }
}
