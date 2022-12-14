import { Component, OnInit } from '@angular/core';
import {HttpService} from "../../../services/http.service";
import {OptionGroup} from "./OptionGroupDto";

@Component({
  selector: 'app-adminoptiongroup',
  templateUrl: './adminoptiongroup.component.html',
  styleUrls: ['./adminoptiongroup.component.scss']
})
export class AdminoptiongroupComponent implements OnInit {

  formModel : OptionGroup = new OptionGroup(); // Sets formModel = to the Box class
  optiongroup: any;
  optiongroups: any[] = [];

  constructor(private http : HttpService) { }

  async ngOnInit(){
    const optiongroups = await this.http.getOptionGroups();
    this.optiongroups = optiongroups;
    this.optiongroup = optiongroups;
  }

  async createOptionGroup() {
    let dto = {
      name: this.formModel.name,
    }
    const result = await this.http.createOptionGroup(dto);
    console.log(result);
    this.optiongroups.push(result);
    this.clearForm();
  }

  selectCard(optionGroup: OptionGroup) {
    this.formModel = {...optionGroup};
  }
  clearForm(){
    this.formModel = new OptionGroup(); // sets the info to the base value we have whits is blank for txt fields and id is 0
  }

  async editOptionGroup(id: any) {
    let dto = {
      id : id,
      name: this.formModel.name,
    }
    const option = await this.http.editOptionGroup(id,dto);
    let indexToEdit = this.optiongroups.findIndex(og => og.id == id); // Sets the id of the box class for the url
    console.log(indexToEdit);
    this.optiongroups[indexToEdit] = option;
    this.clearForm();
  }
}




