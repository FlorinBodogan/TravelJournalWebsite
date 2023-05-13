import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
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
        Validators.minLength(3),
      ]),
      location: new FormControl('', [
        Validators.required,
        Validators.minLength(3),
      ]),
      description: new FormControl('', [
        Validators.required,
        Validators.minLength(3),
      ]),
      startDate: new FormControl('', [
        Validators.required,
        Validators.minLength(3),
      ]),
      endDate: new FormControl('', [
        Validators.required,
        Validators.minLength(3),
      ]),
    });
  }

  postHoliday(): void {
    const userId = '46401a0a-5653-45f8-8611-1e945ec14c46';
    this.postService
      .postHoliday(this.postForm.value, userId)
      .subscribe((message) => console.log(message));
  }

  userId = '46401a0a-5653-45f8-8611-1e945ec14c46';
  //afisare categorie user
  fetchUser(): Observable<User> {
    return this.userService.fetchUser(this.userId);
  }
}
