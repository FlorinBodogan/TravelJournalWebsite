import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Observable, throwError } from 'rxjs';
import { User } from 'src/app/models/User';
import { PostService } from 'src/app/services/post.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css'],
})
export class PostComponent implements OnInit {
  postForm: FormGroup = new FormGroup({});

  userCategory$: Observable<User> | undefined;

  ngOnInit(): void {
    this.userId = localStorage.getItem('userId')!.replace(/"/g, '');
    this.postForm = this.createFormGroup();
    this.userCategory$ = this.fetchUser();
  }

  constructor(
    private postService: PostService,
    private userService: UserService
  ) {}

  createFormGroup(): FormGroup {
    return new FormGroup({
      title: new FormControl('', [
        Validators.required,
        Validators.minLength(1),
      ]),
      location: new FormControl('', [
        Validators.required,
        Validators.minLength(1),
      ]),
      description: new FormControl('', [
        Validators.required,
        Validators.minLength(1),
      ]),
      startDate: new FormControl('', [
        Validators.required,
        Validators.minLength(1),
      ]),
      endDate: new FormControl('', [
        Validators.required,
        Validators.minLength(1),
      ]),
    });
  }

  postHoliday(): void {
    const userId = localStorage.getItem('userId')!.replace(/"/g, '');
    if (userId !== null) {
      this.postService
        .postHoliday(this.postForm.value, userId)
        .subscribe((message) => console.log(message));
    } else {
      console.log('userId is null');
    }
  }

  userId = localStorage.getItem('userId')!.replace(/"/g, '');
  fetchUser(): Observable<User> {
    if (this.userId !== null) {
      return this.userService.fetchUser(this.userId);
    } else {
      return throwError('userId is null');
    }
  }
}
