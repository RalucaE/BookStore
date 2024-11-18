import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Author } from 'src/app/entity/Author';
import { AuthorsService } from 'src/app/services/authors.service';

@Component({
  selector: 'app-add-author',
  templateUrl: './add-author.component.html',
  styleUrls: ['./add-author.component.css']
})
export class AddAuthorComponent implements OnInit {
  constructor(private authorsService: AuthorsService){}
  async ngOnInit() {
  }
  addAuthor(newForm: NgForm) {
    let author: Author = newForm.value;
    this.authorsService.addAuthor(author).subscribe(newAuthor =>{
      newAuthor = author;
    });
  }
}
