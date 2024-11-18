import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private apiBase = `https://localhost:44356/`;

  constructor(private http: HttpClient) { }
  get(url: Array<string | number>): Observable<any> {
   
    return this.http.get(this.apiBase + url);
  }
  post(url: Array<string | number>, bodyParams: any): Observable<any> {
    return this.http.post(this.apiBase + url, bodyParams);
   
  }
}