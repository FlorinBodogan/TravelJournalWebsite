import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { PostService } from 'src/app/services/post.service';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css'],
})
export class PostComponent implements OnInit {
  postForm: FormGroup = new FormGroup({});

  ngOnInit(): void {
    this.postForm = this.createFormGroup();
  }

  constructor(private postService: PostService) {}

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
    this.postService
      .postHoliday(this.postForm.value)
      .subscribe((message) => console.log(message));
  }
}
