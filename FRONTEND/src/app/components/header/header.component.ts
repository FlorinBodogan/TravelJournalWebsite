import { Component, HostListener } from '@angular/core';
import {
  faBars,
  faXmark,
  faRightFromBracket,
} from '@fortawesome/free-solid-svg-icons';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
})
export class HeaderComponent {
  sticky: boolean = false;
  faToggleOn = faBars;
  faToggleOff = faXmark;
  faRightFromBracket = faRightFromBracket;

  @HostListener('window:scroll', ['$event'])
  onScroll(event: Event) {
    this.sticky = window.pageYOffset >= 10;
  }

  public isMenuOpen: boolean = false;
  public menuClass: string = '';

  public toggleMenu(): void {
    this.isMenuOpen = !this.isMenuOpen;
    if (this.isMenuOpen) {
      this.menuClass = 'nav-open';
    } else {
      this.menuClass = '';
    }
  }

  public selectPage(): void {
    this.isMenuOpen = false;
    this.menuClass = '';
  }

  //auth
  isAuthenticated = false;

  constructor(private authService: AuthService, private router: Router) {}

  ngOnInit(): void {
    this.authService.isUserLogged$.subscribe((isLogged) => {
      this.isAuthenticated = isLogged;
    });
  }

  logout(): void {
    localStorage.removeItem('userId');
    this.authService.isUserLogged$.next(false);
    this.router.navigate(['home']);
  }
}
