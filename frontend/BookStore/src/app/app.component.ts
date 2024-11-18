import { Component, OnInit } from '@angular/core';
import { AuthService } from './services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit{
  title = 'BookStore';
  token: string | null = "";

  constructor(private authService: AuthService) {}

  ngOnInit(): void { 
    this.token = localStorage.getItem('token');
    if (this.token) {
      console.log(this.token);
        var exp = this.authService.getTokenExpirationTimeInSeconds(this.token);
        console.log(exp);
    } else {
        console.log("Token not found in localStorage");
    }
  }
}