import { Component, OnInit } from '@angular/core';
import {HttpService} from "../../../services/http.service";

@Component({
  selector: 'app-admincatgory',
  templateUrl: './admincategory.component.html',
  styleUrls: ['./admincategory.component.scss']
})
export class AdmincategoryComponent implements OnInit {
  formModel : Category = new Category(); // Sets formModel = to the Box class
  category: any;
  categorys: any[] = [];

  constructor(private http : HttpService) { }

  async ngOnInit(){
    const categorys = await this.http.getCategorys();
    this.category = categorys;
    this.categorys = categorys;
  }

  async createCategory() {
    // @ts-ignore
    /*  const result = await this.http.createOption(this.formModel as OptionDto);
      this.options.push(result);
      this.formModel = new Option();*/
    let dto = {
      name: this.formModel.categoryName,
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
    let dto = {
      name: this.formModel.categoryName,
    }
    const option = await this.http.editCategory(id,dto);
    let indexToEdit = this.categorys.findIndex(c => c.id == id); // Sets the id of the box class for the url
    console.log(indexToEdit);
    this.categorys[indexToEdit] = option;
    this.clearForm();
  }
}

class CategoryDto {
  categoryName: string = "";

}
// Sets the id when it is needed
class Category extends CategoryDto{
  id: number = 0;
}



