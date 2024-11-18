import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BookModel } from 'src/app/entity/BookModel';

@Component({
  selector: 'app-book-description',
  templateUrl: './book-description.component.html',
  styleUrls: ['./book-description.component.css'],
})
export class BookDescriptionComponent implements OnInit{
  book!: BookModel;
  title: string | null = '';
  author: string | null = '';
  category: string | null = '';
  page_number: string | null = '';
  description: string | null = '';
  availability: string | null = '';
  release_date: string | null = '';
  review: string | null = '';
  cover: string | null = '';
  constructor(
    private route: ActivatedRoute,
   )
    {}
  async ngOnInit() {
    this.route.queryParamMap.subscribe(params =>{
      this.title = params.get("title") ;
      this.author = params.get("author");
      this.category = params.get("category");
      this.page_number = params.get("page_number") ;
      this.description = params.get("description");
      this.availability = params.get("availability");
      this.release_date = params.get("release_date") ;
      this.review = params.get("review");
      this.cover = params.get("cover");
    });
  }
}
