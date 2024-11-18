import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Category } from 'src/app/entity/Category';
import { CategoriesService } from 'src/app/services/categories.service';

@Component({
  selector: 'app-add-category',
  templateUrl: './add-category.component.html',
  styleUrls: ['./add-category.component.css']
})
export class AddCategoryComponent {
  constructor(private categoryService: CategoriesService){}
  async ngOnInit() {
  }
  addCategory(newForm: NgForm) {
    let category: Category = newForm.value;
    this.categoryService.addCategory(category).subscribe(newCategory =>{
      newCategory = category;
    });
  } 
}
