import { Component, OnInit } from '@angular/core';
import {HttpService} from "../../../services/http.service";
import {Category, CategoryDto} from "./CategoryDto";
import {timestamp} from "rxjs";

@Component({
  selector: 'app-admincatgory',
  templateUrl: './admincategory.component.html',
  styleUrls: ['./admincategory.component.scss']
})
export class AdmincategoryComponent implements OnInit {
  formModel : Category = new Category(); // Sets formModel = to the Box class
  category: any;
  categorys: Category[] = [];

  constructor(private http : HttpService) { }

  async ngOnInit(){
    const categorys : Category[] = await this.http.getCategorys();
    this.category = categorys;
    this.categorys = categorys;
  }

  async createCategory() {
    let dto : CategoryDto= {
      categoryName: this.formModel.categoryName,
    }
    const result = await this.http.createCategory(dto);
    console.log(result);
    this.categorys.push(result);
    this.clearForm();
  }

  selectCard(category: Category) {
    this.formModel = {...category}; // creates a copy of option and sets it to the form - done to prevent 2 way binding
  }
  clearForm(){
    this.formModel = new Category(); // sets the info to the base value we have whits is blank for txt fields and id is 0
  }

  async editCategory(id: any) {
    let dto : Category = {
      id : id,
      categoryName: this.formModel.categoryName,
    }
    const category : Category = await this.http.editCategory(id,dto);
    let indexToEdit = this.categorys.findIndex(c => c.id == id); // Sets the id of the box class for the url
    console.log(indexToEdit);
    this.categorys[indexToEdit] = category;
    this.clearForm();
  }
}


