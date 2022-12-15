import { Component, OnInit } from '@angular/core';
import {HttpService} from "../../services/http.service";
import {customAxios} from "../app.component";
import {FormControl, Validators} from "@angular/forms";
import {MatButtonToggleModule} from '@angular/material/button-toggle';
import {Category} from "../adminpage/admincatgory/CategoryDto";


@Component({
  selector: 'app-userpage',
  templateUrl: './userpage.component.html',
  styleUrls: ['./userpage.component.scss']
})

export class UserpageComponent implements OnInit {
  formModel : Option = new Option(); // Sets formModel = to the Box class
  option: any;
  optionGroups: any[] = [];
  items: any[] = [];
  categories: any[] = [];

  optionsControl = new FormControl<number[]>([]);

  constructor(private http : HttpService) { }

  async ngOnInit(){
    const optionGroups = await this.http.getOptionGroupsWithOptions();
    const categories = await this.http.getCategorys();
    // const items = await this.http.getItems();
    // this.items = items;
    this.categories = categories;
    this.optionGroups = optionGroups;
  }


  selectCard(option: Option) {
    this.formModel = {...option};
  }

  selectCategory(category: Category){

  }

  ColorId(id: number) {
    id = 1
  }
}

class OptionDto {
  optionName: string = "";
  optionGroupId: number = 1;
}
// Sets the id when it is needed
class Option extends OptionDto{
  id: number = 0;
}