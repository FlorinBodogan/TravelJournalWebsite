import { Component, OnInit } from '@angular/core';
import { AuthService } from './services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  title = 'TravelJournal';

  constructor(private authService: AuthService, private router: Router) {}

  ngOnInit() {
    const checkLogged = localStorage.getItem('userId');
    if (checkLogged !== null) {
      this.authService.isUserLogged$.next(true);
    } else {
      this.authService.isUserLogged$.next(false);
    }
  }
}
