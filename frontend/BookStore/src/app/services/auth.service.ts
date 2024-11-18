import { Injectable } from '@angular/core';
import { ApiService } from './http/api.service';
import { Observable, Subject } from 'rxjs';
import { User } from '../entity/User';
import { LoginRequest } from '../entity/LoginRequest';
import { RegisterRequest } from '../entity/RegisterRequest';
import { LoginResponse } from '../entity/LoginResponse';
import {JwtHelperService} from '@auth0/angular-jwt';


@Injectable({
  providedIn: 'root'
})
export class AuthService {
  constructor(private apiService: ApiService, private jwtHelper: JwtHelperService) { }
  
  getUsers(): Observable<User[]>{
    return this.apiService.get(['GetUsers']);  
  }
  register(registerRequest: RegisterRequest): Observable<any> {
    return this.apiService.post(['Register'], registerRequest);
  }
  login(loginRequest: LoginRequest): Observable<LoginResponse> { 
     return this.apiService.post(['Login'], loginRequest);
  } 
  getToken(): string | null{
    return localStorage.getItem('token');
  }
  getRole(): string | null{
    return localStorage.getItem('role');
  }
  getUserName(): string | null{
    return localStorage.getItem('username');
  }
  isAuthenticated(): boolean {
    const token = this.getToken();
    if (token == null) 
    {
      return false; 
    }
    if(this.jwtHelper.isTokenExpired(token))
      {
        console.log("Token expirat");
        localStorage.removeItem('token');
        localStorage.removeItem('role');
        localStorage.removeItem('username');
        return false;
      } 
    return true;
  }
  logout() {
    localStorage.removeItem('token');
    localStorage.removeItem('role');
    localStorage.removeItem('username');
    
  }
  getTokenExpirationTimeInSeconds(token: string): number | null {
    const decodedToken = this.jwtHelper.decodeToken(token);
    var claims = decodedToken.claims;
    if (decodedToken.exp === undefined) {        
        return null;
    }
    const currentTimeInSeconds = Math.floor(Date.now() / 1000);   
    const timeUntilExpirationInSeconds = decodedToken.exp - currentTimeInSeconds;
    return timeUntilExpirationInSeconds;
  }
}