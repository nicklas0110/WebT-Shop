import {Component, OnInit} from "@angular/core";
import {HttpService} from "../../services/http.service";
import {Option} from "./andminoption/OptionDto";
import {FormControl, Validators} from "@angular/forms";


@Component({
  selector: 'app-adminpage',
  templateUrl: './adminpage.component.html',
  styleUrls: ['./adminpage.component.scss']
})

export class AdminpageComponent implements OnInit {
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
    console.log(option);
  }
  clearForm(){
    this.formModel = new Option(); // sets the info to the base value we have whits is blank for txt fields and id is 0
  }

  async editOption(id: any) {
    let dto = {
      name: this.formModel.name,
      optionGroupId: this.formModel.optionGroupId
    }
    const option = await this.http.editOption(id,dto);
    let indexToEdit = this.options.findIndex(o => o.id == id); // Sets the id of the box class for the url
    console.log(indexToEdit);
    this.options[indexToEdit] = option;
    this.clearForm();
  }
}
