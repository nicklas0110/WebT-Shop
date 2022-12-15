import { Component, OnInit } from '@angular/core';
import {HttpService} from "../../../services/http.service";
import {Item, ItemDto} from "./ItemDto";
import {Category, CategoryDto} from "../admincatgory/CategoryDto";
import {FormControl, Validators} from "@angular/forms";
import {Option} from "../andminoption/OptionDto";

@Component({
  selector: 'app-adminitem',
  templateUrl: './adminitem.component.html',
  styleUrls: ['./adminitem.component.scss']
})
export class AdminitemComponent implements OnInit {

  formModel : Item = new Item(); // Sets formModel = to the Box class
  item: any;
  items: any[] = [];
  categories : any[] = [];
  options : any[] = [];
  categoryControl = new FormControl<number | null>(null, Validators.required);
  optionsControl = new FormControl<number[]>([]);
  selectFormControl = new FormControl('', Validators.required);

  constructor(private http : HttpService) { }

  async ngOnInit(){
    const categories = await this.http.getCategorys();
    const items = await this.http.getItems();
    const options = await this.http.getOption();
    this.categories = categories;
    this.items = items;
    this.options = options;
    this.item = items;
  }

  async createItem() {
    let dto : ItemDto= {
      name: this.formModel.name,
      price: this.formModel.price,
      itemCategoryId: this.categoryControl.getRawValue() || 0,
      optionIds: this.optionsControl.getRawValue() || []
    };
    const result = await this.http.createItem(dto);
    console.log(result);
    this.items.push(result);
    this.clearForm();
  }

  selectCard(item: Item) {
    this.formModel = {...item};
    this.optionsControl.setValue(item.optionIds);
    this.categoryControl.setValue(item.itemCategoryId);
  }
  clearForm(){
    this.formModel = new Item(); // sets the info to the base value we have whits is blank for txt fields and id is 0
    this.optionsControl.reset();
    this.categoryControl.reset();
  }

  async editItem(id: any) {
    let dto : Item = {
      id: id,
      name: this.formModel.name,
      price: this.formModel.price,
      itemCategoryId: this.formModel.itemCategoryId,
      optionIds: this.formModel.optionIds
    }
    const option = await this.http.editItem(id,dto);
    let indexToEdit = this.items.findIndex(i => i.id == id); // Sets the id of the box class for the url
    console.log(indexToEdit);
    if(indexToEdit > -1) this.items.splice(indexToEdit, 1);
    this.clearForm();
  }

  async deleteEditItem(id: number) {
    const item : Item = await this.http.deleteEditItem(id);
    let indexToEdit = this.items.findIndex(i => i.id == id); // Sets the id of the box class for the url
    console.log(indexToEdit);
    if(indexToEdit > -1) this.items.splice(indexToEdit, 1);
    this.clearForm();
  }

  getCategory(id : number) : Category {
    return this.categories.find(c => c.id == id);
  }

  getOption(id : number) : Option {
    return this.options.find(c => c.id == id);
  }

}





