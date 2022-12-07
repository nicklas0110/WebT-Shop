import { Component } from '@angular/core';
import {HttpService} from "../services/http.service";
import {async} from "@angular/core/testing";


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  formModel : Option = new Option(); // Sets formModel = to the Box class
  option: any;
  options: Array<Option> = []; // an array of boxes

  constructor(private http : HttpService) {

  }

  async ngOnInit(){
  const optionData = await this.http.GetAllOptions();
  this.options = optionData;
  this.option = optionData;
  }

  async postForm(){
  if(this.formModel.id === 0){
    await this.createNewOption(); // if the id = 0 no box needs to be editet so we know you want to crate
  } else {
    await this.UpdateOption(this.formModel.id); // Sets the id of the box class to be edits
  }
  }

  async createNewOption(){
  const result = await this.http.createNewOption(this.formModel as OptionDto);
  this.options.push(result);
  this.formModel = new Option();
  }

  async DeleteUpdateOption(id:any) {
  const box = await this.http.DeleteUpdateOption(id);
  this.options = this.options.filter((b: { id: any; }) => b.id != box.id)
  }

  async UpdateOption(id: any) {
  const box = await this.http.UpdateOption(id, this.formModel);
  let indexToEdit = this.options.findIndex(b => b.id == id); // Sets the id of the box class for the url
  this.options[indexToEdit] = box;
  this.formModel = new Option();
  }

  selectCard(option : Option){
    this.formModel = {...option}; // creates a copy of box and sets it to the form - done to prevent 2 way binding
  }

  clearForm(){
    this.formModel = new Option(); // sets the info to the base value we have whits is blank for txt fields and id is 0
  }
}




// is in change of the 1 txt fields information storing when creating or edit
class OptionDto {
  optionName: string = "";
}
// Sets the id when it is needed
class Option extends OptionDto{
  id: number = 0;
}
