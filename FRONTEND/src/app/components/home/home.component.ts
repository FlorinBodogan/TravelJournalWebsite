import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { Observable } from 'rxjs';
import { User } from 'src/app/models/User';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  isAuthenticated = true;

  constructor(private authService: AuthService) {}

  ngOnInit(): void {
    this.authService.isUserLogged$.subscribe((isLogged) => {
      this.isAuthenticated = isLogged;
    });
  }
}
