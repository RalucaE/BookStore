import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Author } from 'src/app/entity/Author';
import { Book } from 'src/app/entity/Book';
import { BookModel } from 'src/app/entity/BookModel';
import { Category } from 'src/app/entity/Category';
import { AuthorsService } from 'src/app/services/authors.service';
import { BooksService } from 'src/app/services/books.service';
import { CategoriesService } from 'src/app/services/categories.service';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.css']
})
export class BooksComponent implements OnInit{
  books: Book[] = [];
  bookModel: BookModel[] = [];
  filteredBooks: Book[] = [];
  authors: Author[] = [];
  categories: Category[] = [];
  keyword: string | null = '';

  constructor(
    private booksService: BooksService, 
    private authorsService: AuthorsService, 
    private categoriesService: CategoriesService,
    private route: ActivatedRoute,
    private router: Router)
    {}
    
  async ngOnInit() {
   
    this.keyword = this.route.snapshot.paramMap.get('keyword');
    console.log("keyword",this.keyword);
    

  if(this.keyword != null) {
   
    this.booksService.searchBooks(this.keyword).subscribe((filteredBook) =>{
      this.books = filteredBook;
    });
    console.log(this.books);
  } 
  else {
    this.booksService.getBooks().subscribe((book) =>{
      this.books = book; 
    });
  }
  
    this.authorsService.getAuthors().subscribe((author) =>{
      this.authors = author;  
    });  

    this.categoriesService.getCategories().subscribe((category) =>{
      this.categories = category;
    }); 

    setTimeout(() => {


      this.books.forEach(book => {
        
      });

      this.authors.forEach(author => {
       
      });

      this.categories.forEach(category => {
        
      });
      
      this.createModelBooks();
      this.bookModel = [...this.bookModel].sort((a, b) => a.title.localeCompare(b.title));
    console.log(this.bookModel);

    this.bookModel.forEach(model => {
      
    });
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
    this.bookModel.push(model);
  });
}
}