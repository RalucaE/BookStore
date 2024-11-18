import { Component, OnInit} from '@angular/core';
import { Router } from '@angular/router';
import { Author } from 'src/app/entity/Author';
import { Book } from 'src/app/entity/Book';
import { BookModel } from 'src/app/entity/BookModel';
import { Category } from 'src/app/entity/Category';
import { AuthorsService } from 'src/app/services/authors.service';
import { BooksService } from 'src/app/services/books.service';
import { CategoriesService } from 'src/app/services/categories.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit{
  topBooks: BookModel[] = [];
  books: Book[] = [];
  authors: Author[] = [];
  categories: Category[] = [];
  constructor(
    private booksService: BooksService, 
    private authorsService: AuthorsService, 
    private categoriesService: CategoriesService,
    private router: Router
   )
    {}
  ngOnInit(): void {
    this.booksService.getBooks().subscribe((book) =>{
      this.books = book; 
    });
    console.log(this.books);

    this.authorsService.getAuthors().subscribe((author) =>{
      this.authors = author;  
    });  

    this.categoriesService.getCategories().subscribe((category) =>{
      this.categories = category;
    }); 

    
    setTimeout(() => {
      this.createModelBooks();
      console.log(this.topBooks);
    }, 300);

  }

  onDivClick(book:BookModel): void {
    console.log('Div was clicked!');
    console.log(book.title);
    this.router.navigate(['/book-description'],{ queryParams: { title: book.title, author: book.author, category: book.category,
      page_number: book.page_number, description: book.description, availability: book.availability, 
      release_date: book.release_date, review: book.review, cover: book.cover}});

   
  }
  createModelBooks() {
    this.books.forEach(book => {
      let model: BookModel = {
        id: book.id,
        title: book.title,
        page_number: book.page_number,
        description: book.description,
        availability: book.availability,
        release_date: book.release_date,
        cover: book.cover,
        review: '',
        author: '',
        category: '',
      };
      this.authors.forEach(author => {
        if (book.author_id == author.id) {
          model.author = author.author_name;
        }
      });
  
      this.categories.forEach(category => {
        if (book.category_id == category.id) {
          model.category = category.category_name;
        }
      });
      this.topBooks.push(model);
    });
  }
}
