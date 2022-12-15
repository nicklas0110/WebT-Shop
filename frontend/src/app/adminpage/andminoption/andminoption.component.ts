import { Component, OnInit } from '@angular/core';
import {Option, OptionDto} from "./OptionDto";
import {FormControl, Validators} from "@angular/forms";
import {HttpService} from "../../../services/http.service";
import {ItemDto} from "../adminitem/ItemDto";
import {Category} from "../admincatgory/CategoryDto";
import {OptionGroup} from "../adminoptiongroup/OptionGroupDto";

@Component({
  selector: 'app-andminoption',
  templateUrl: './andminoption.component.html',
  styleUrls: ['./andminoption.component.scss']
})
export class AndminoptionComponent implements OnInit {

  formModel : Option = new Option(); // Sets formModel = to the Box class
  option: any;
  options: any[] = [];
  optionGroups: any[] = [];
  optionGroupControl = new FormControl<number | null>(null, Validators.required);


  constructor(private http : HttpService) { }

  async ngOnInit(){
    const optionGroups = await this.http.getOptionGroups();
    const options = await this.http.getOption();
    this.optionGroups = optionGroups;
    this.options = options;
    this.option = options;
  }

  async createOption() {
    let dto = {
      name: this.formModel.name,
      optionGroupId: this.formModel.optionGroupId
    }
    const result = await this.http.createOption(dto);
    console.log(result);
    this.options.push(result);
    this.clearForm();
  }

  selectCard(option: Option) {
    this.formModel = {...option};
    this.optionGroupControl.setValue(this.formModel.optionGroupId);
  }

  clearForm(){
    this.formModel = new Option(); // sets the info to the base value we have whits is blank for txt fields and id is 0
    this.optionGroupControl.reset();
  }

  getOptionGroup(id: number){
    return this.optionGroups.find(og => og.id == id);
  }

  async editOption(id: any) {
    let dto = {
      id : id,
      name: this.formModel.name,
      optionGroupId: this.optionGroupControl.getRawValue() ?? 0
    }
    const option = await this.http.editOption(id,dto);
    let indexToEdit = this.options.findIndex(o => o.id == id); // Sets the id of the box class for the url
    console.log(indexToEdit);
    if(indexToEdit > -1) this.options.splice(indexToEdit, 1);
    this.clearForm();
  }

  async deleteEditOption(id: number) {
    const option : Option = await this.http.deleteEditOption(id);
    let indexToEdit = this.options.findIndex(i => i.id == id); // Sets the id of the box class for the url
    console.log(indexToEdit);
    if(indexToEdit > -1) this.options.splice(indexToEdit, 1);
    this.clearForm();
  }
}
