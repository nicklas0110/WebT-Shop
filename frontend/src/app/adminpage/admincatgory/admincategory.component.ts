import { Component, OnInit } from '@angular/core';
import {HttpService} from "../../../services/http.service";
import {Category, CategoryDto} from "./CategoryDto";

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
    // @ts-ignore
    /*  const result = await this.http.createOption(this.formModel as OptionDto);
      this.options.push(result);
      this.formModel = new Option();*/
    let dto : CategoryDto= {
      name: this.formModel.name,
    }
    const result = await this.http.createCategory(dto);
    console.log(result);
    this.categorys.push(result);
    this.clearForm();
  }

  selectCard(option: Category) {
    this.formModel = {...option};
    console.log(option);
  }
  clearForm(){
    this.formModel = new Category(); // sets the info to the base value we have whits is blank for txt fields and id is 0
  }

  async editCategory(id: any) {
    let dto : Category = {
      id : id,
      name: this.formModel.name,
    }
    const option : Category = await this.http.editCategory(id,dto);
    let indexToEdit = this.categorys.findIndex(c => c.id == id); // Sets the id of the box class for the url
    console.log(indexToEdit);
    this.categorys[indexToEdit] = option;
    this.clearForm();
  }
}


