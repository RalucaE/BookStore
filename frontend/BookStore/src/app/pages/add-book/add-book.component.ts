import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Book } from 'src/app/entity/Book';
import { AuthService } from 'src/app/services/auth.service';
import { BooksService } from 'src/app/services/books.service';

@Component({
  selector: 'app-add-book',
  templateUrl: './add-book.component.html',
  styleUrls: ['./add-book.component.css']
})
export class AddBookComponent implements OnInit{
  constructor(private booksService: BooksService, private authService: AuthService){}
  ngOnInit(): void {
    if(this.authService.isAuthenticated())
      console.log("User authenticated");
  }
 book: Book = new Book;
  addBook(newForm: NgForm) {
    let book: Book = newForm.value;
    newForm.value.cover = this.book.cover;
 
    if (newForm.value.review_id == "") {
      book.review_id = null;
    }

    this.booksService.addBook(book).subscribe(newBook=>{
      newBook = book;
      console.log(newBook.cover);
    });
    }

  onFileSelected(event: Event): void {
    const input = event.target as HTMLInputElement;
    if (input.files && input.files.length > 0) {
      let selectedFile = input.files[0];
      this.book.cover = selectedFile.name;
    }
  }
}