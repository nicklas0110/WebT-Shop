import { Component, OnInit } from '@angular/core';
import {HttpService} from "../../services/http.service";
import {customAxios} from "../app.component";
import {FormControl, Validators} from "@angular/forms";
import {MatButtonToggleModule} from '@angular/material/button-toggle';
import {Category} from "../adminpage/admincatgory/CategoryDto";
import {Option} from "../adminpage/andminoption/OptionDto";


@Component({
  selector: 'app-userpage',
  templateUrl: './userpage.component.html',
  styleUrls: ['./userpage.component.scss']
})

export class UserpageComponent implements OnInit {
  formModel : Option = new Option(); // Sets formModel = to the Box class
  option: any;
  optionGroups: any[] = [];
  options: Option[] = [];
  items: any[] = [];
  categories: any[] = [];
  selectedCategoryId: number = 0;
  selectedOptions: any = {};

  optionsControl = new FormControl<number[]>([]);

  constructor(private http : HttpService) { }

  async ngOnInit(){
    const optionGroups = await this.http.getOptionGroupsWithOptions();
    const categories = await this.http.getCategorys();
    this.categories = categories;
    this.optionGroups = optionGroups;
    for(let i = 0; i < optionGroups.length; i++){
      let og = optionGroups[i];
      this.options = this.options.concat(og.options);
    }
    await this.getItems();
  }


  selectCard(option: Option) {
    this.formModel = {...option};
  }

  selectCategory(categoryId: number){
    this.selectedCategoryId = categoryId;
    this.getItems();
  }

  optionsChanged() {
    this.getItems();
  }

  async getItems(){
    console.log(this.selectedOptions);
    let optionsList : any[] = [];
    for(const [key, value] of Object.entries(this.selectedOptions)){
      optionsList.push(value);
    }
    this.items = await this.http.getItemsWithFilter(this.selectedCategoryId, optionsList);
  }
}