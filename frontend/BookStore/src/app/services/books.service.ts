import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Book } from '../entity/Book';
import { ApiService } from './http/api.service';
import { HttpClient, HttpParams } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class BooksService {

  constructor(private apiService: ApiService, private http: HttpClient) { }
  private apiBase = `https://localhost:44356/`;
  getBooks(): Observable<Book[]>{
    return this.apiService.get(['GetBooks']);  
  }
  addBook(book: Book): Observable<any> {
    return this.apiService.post(['AddBook'], book);
  }
  searchBooks(keyword: string | null): Observable<Book[]>{
    return this.http.get<Book[]>(`${this.apiBase}SearchBooks/${keyword}`); 
   
  } 
}
