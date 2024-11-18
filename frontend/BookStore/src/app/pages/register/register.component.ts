import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { RegisterRequest } from 'src/app/entity/RegisterRequest';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  constructor(private authService: AuthService){}

  register(newForm: NgForm) {
    let registerRequest: RegisterRequest = newForm.value;
    this.authService.register(registerRequest).subscribe();
  }
}