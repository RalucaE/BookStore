import { Injectable } from '@angular/core';
import { Author } from '../entity/Author';
import { Observable } from 'rxjs';
import { ApiService } from './http/api.service';

@Injectable({
  providedIn: 'root'
})
export class AuthorsService {

  constructor(private apiService: ApiService) { }

  getAuthors(): Observable<Author[]>{
    return this.apiService.get(['GetAuthors']);  
  }
  addAuthor(author: Author): Observable<any> {
    console.log("author");
    return this.apiService.post(['AddAuthor'], author);
  }
}