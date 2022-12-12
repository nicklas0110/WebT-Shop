import { Component, OnInit } from '@angular/core';
import {HttpService} from "../../services/http.service";
import {customAxios} from "../app.component";

@Component({
  selector: 'app-userpage',
  templateUrl: './userpage.component.html',
  styleUrls: ['./userpage.component.scss']
})
// @ts-ignore
export class UserpageComponent implements OnInit {
  title = 'frontend';
  formModel: Option = new Option; // Sets formModel = to the Option class
  option: any;
  options: Array<Option> = []; // an array of Options

  constructor(private http : HttpService) {

  }

  async ngOnInit(){
    const optionData = await this.http.getOption();
    this.options = optionData;
    this.option = optionData;

  }


  async postForm() {
    if (this.formModel.id === 0) {
      await this.createOption(); // if the id = 0 no box needs to be editet so we know you want to crate
    } else {
      await this.editOption(this.formModel.id); // Sets the id of the box class to be edits
    }
  }


  async createOption() {
    const result = await this.http.createOption(this.formModel as OptionDto);
    this.options.push(result);
    this.formModel = new Option();
  }

  async editOption(id: any) {

  }
  selectCard(option1 : Option){
    this.formModel = {...option1}; // creates a copy of box and sets it to the form - done to prevent 2 way binding
  }

  clearForm() {
    this.formModel = new Option(); // sets the info to the base value we have whits is blank for txt fields and id is 0
  }

  async deleteOption(id: any, dto: {deletedAt: any;}) {
    const httpResponse = await customAxios.put('Option/Delete/' + id, dto)
    return httpResponse.data;
  }
}

// is in change of the 3 txt fields information storing when creating or edit
class OptionDto {
  name: string = "";
  deletedAt: string = ""
}
// Sets the id when it is needed
class Option extends OptionDto{
  id: number = 0;
}

