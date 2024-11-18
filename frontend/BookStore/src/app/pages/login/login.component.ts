import { Component, Input, SimpleChanges } from '@angular/core';
import { NgForm } from '@angular/forms';
import { LoginRequest } from 'src/app/entity/LoginRequest';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  constructor(private authService: AuthService){}

  login(newForm: NgForm) {
    let loginRequest: LoginRequest = newForm.value;
    this.authService.login(loginRequest).subscribe((response) => {
      console.log("User is logged in");      
      localStorage.setItem('token', response.token);
      localStorage.setItem('role', response.role);
      localStorage.setItem('username', response.user.username);    
      window.location.href="/home";          
    }); 
  }
}