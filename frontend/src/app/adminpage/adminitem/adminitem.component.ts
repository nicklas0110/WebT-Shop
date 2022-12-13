import { Component, OnInit } from '@angular/core';
import {HttpService} from "../../../services/http.service";

@Component({
  selector: 'app-adminitem',
  templateUrl: './adminitem.component.html',
  styleUrls: ['./adminitem.component.scss']
})
export class AdminitemComponent implements OnInit {

  formModel : Item = new Item(); // Sets formModel = to the Box class
  item: any;
  items: any[] = [];

  constructor(private http : HttpService) { }

  async ngOnInit(){
    const items = await this.http.getItems();
    this.items = items;
    this.item = items;
  }

  async createItem() {
    // @ts-ignore
    /*  const result = await this.http.createOption(this.formModel as OptionDto);
      this.options.push(result);
      this.formModel = new Option();*/
    let dto = {
      name: this.formModel.itemName,
      price: this.formModel.price,
      itemCategoryId: this.formModel.itemCategoryId,
    }
    const result = await this.http.createItem(dto);
    console.log(result);
    this.items.push(result);
    this.clearForm();
  }

  selectCard(option: Item) {
    this.formModel = {...option};
    console.log(option);
  }
  clearForm(){
    this.formModel = new Item(); // sets the info to the base value we have whits is blank for txt fields and id is 0
  }

  async editItem(id: any) {
    let dto = {
      name: this.formModel.itemName,
      price: this.formModel.price,
      itemCategoryId: this.formModel.itemCategoryId,
    }
    const option = await this.http.editOptionGroup(id,dto);
    let indexToEdit = this.items.findIndex(i => i.id == id); // Sets the id of the box class for the url
    console.log(indexToEdit);
    this.items[indexToEdit] = option;
    this.clearForm();
  }
}

class ItemDto {
  itemName: string = "";
  price: number = 0;
  itemCategoryId: number = 0;
}
// Sets the id when it is needed
class Item extends ItemDto{
  id: number = 0;
}




