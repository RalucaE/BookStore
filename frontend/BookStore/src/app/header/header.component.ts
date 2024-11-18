import { Component, ElementRef, EventEmitter, HostListener, OnInit, Output, ViewChild } from '@angular/core';
import { MatMenu } from '@angular/material/menu';
import { Category } from '../entity/Category';
import { CategoriesService } from '../services/categories.service';
import { AuthService } from '../services/auth.service';
import { BooksService } from '../services/books.service';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
})
export class HeaderComponent implements OnInit{
  
  @ViewChild('menu') menu!: MatMenu;
  isClicked = false;
  categories: Category[] = [];
  isAuthenticated: boolean = false;
  role: string | null = "User";
  isAdmin: boolean = false;
  username: string | null = " ";
 
  constructor(
    private elementRef: ElementRef, 
    private categoriesService: CategoriesService, 
    private authService: AuthService,
    private booksService: BooksService,
    private router: Router
    ) {}

  handleClick() {
    this.isClicked = true;
  }
  @HostListener('document:click', ['$event.target'])
  onClickOutside(targetElement: any) {
    const isClickedOutside = !this.elementRef.nativeElement.contains(targetElement);

    if (isClickedOutside) {
      this.isClicked = false;
    }
  }
  ngOnInit(): void {   
    this.isAuthenticated = this.authService.isAuthenticated();
    this.role = this.authService.getRole();
    if(this.isAuthenticated == true)
    { 
      this.username = this.authService.getUserName();
    }
    if(this.isAuthenticated == true && this.role=="Admin")
    {
      this.isAdmin = true;  
    } 
    this.categoriesService.getCategories().subscribe((category) =>{
      this.categories = category;
      this.categories = [...this.categories].sort((a, b) => a.category_name.localeCompare(b.category_name));
    }); 

  }
  keyword: string | null = '';
  logout() {
    this.authService.logout();
    window.location.href="/login";
  }
 
  searchBooks(newForm: NgForm) { 
    let keyword: string = newForm.value;
    this.redirectTo('/books', keyword);
  }

  redirectTo(uri: string, keyword:string) {
    this.router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
      this.router.navigate([uri, keyword])});
  }
}