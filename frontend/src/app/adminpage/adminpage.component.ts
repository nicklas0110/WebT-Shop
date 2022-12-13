import {Component, OnInit} from "@angular/core";
import {HttpService} from "../../services/http.service";
import {Option} from "./OptionDto";


@Component({
  selector: 'app-adminpage',
  templateUrl: './adminpage.component.html',
  styleUrls: ['./adminpage.component.scss']
})

export class AdminpageComponent implements OnInit {
  formModel : Option = new Option(); // Sets formModel = to the Box class
  option: any;
  options: any[] = [];

  constructor(private http : HttpService) { }

  async ngOnInit(){
    const options = await this.http.getOption();
    this.options = options;
    this.option = options;
  }

  async createOption() {
    // @ts-ignore
  /*  const result = await this.http.createOption(this.formModel as OptionDto);
    this.options.push(result);
    this.formModel = new Option();*/
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
