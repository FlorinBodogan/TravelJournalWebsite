import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Post } from 'src/app/models/Post';
import { PostService } from 'src/app/services/post.service';

@Component({
  selector: 'app-holidays',
  templateUrl: './holidays.component.html',
  styleUrls: ['./holidays.component.css'],
})
export class HolidaysComponent implements OnInit {
  holidays$: Observable<Post[]> | undefined;

  constructor(private postService: PostService) {}

  ngOnInit(): void {
    this.holidays$ = this.fetchHolidays();
  }

  userId = '46401a0a-5653-45f8-8611-1e945ec14c46';
  //afisare vacante
  fetchHolidays(): Observable<Post[]> {
    return this.postService.fetchHoliday(this.userId);
  }
}
