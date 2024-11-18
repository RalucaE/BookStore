import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, tap } from "rxjs";
import { AuthService } from "../services/auth.service";
import { JwtHelperService } from '@auth0/angular-jwt';
import { Router } from "@angular/router";

@Injectable()
export class TokenInterceptor implements HttpInterceptor{
    constructor(private authService: AuthService, private jwtHelper: JwtHelperService, private router: Router) {}
    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        if(this.jwtHelper.isTokenExpired(this.authService.getToken())  && this.authService.isAuthenticated())
        {
            setTimeout(() => {

                this.authService.logout(); 
              }, 300);
              console.log("token has expired");
              this.router.navigate(['/login']);  
           this.redirectTo('/login');
            return next.handle(request);    
        }
        if(this.authService.isAuthenticated())
        { 
            console.log("User autentificat");
            request = request.clone({
                setHeaders: {
                    Authorization: `Bearer ${this.authService.getToken()}`
                }
            });          
        }    
        return next.handle(request).pipe( tap(() => {},
        (err: any) => {
            if(err instanceof HttpErrorResponse){
                if (err.status !== 401){
                    return;
                }
                localStorage.removeItem('token');
                localStorage.removeItem('role');
                localStorage.removeItem('username');
               this.router.navigate(['/login']);
            }
        }));
        }
        redirectTo(uri: string) {
            this.router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
              this.router.navigate([uri])});
          }
}