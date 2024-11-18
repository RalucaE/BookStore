import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Category } from '../entity/Category';
import { ApiService } from './http/api.service';

@Injectable({
  providedIn: 'root'
})
export class CategoriesService {

  constructor(private apiService: ApiService) { }

  getCategories(): Observable<Category[]>{
    return this.apiService.get(['GetCategories']);  
  }
  addCategory(category: Category): Observable<any> {
    return this.apiService.post(['AddCategory'], category);
  }
}