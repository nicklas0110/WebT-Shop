import { Component, OnInit } from '@angular/core';
import {HttpService} from "../../services/http.service";
import {customAxios} from "../app.component";
import {FormControl, Validators} from "@angular/forms";
import {MatButtonToggleModule} from '@angular/material/button-toggle';


@Component({
  selector: 'app-userpage',
  templateUrl: './userpage.component.html',
  styleUrls: ['./userpage.component.scss']
})

export class UserpageComponent implements OnInit {
  formModel : Option = new Option(); // Sets formModel = to the Box class
  option: any;
  options: any[] = [];
  optionGroupId: any[] =[];

  optionsControl = new FormControl<number[]>([]);

  constructor(private http : HttpService) { }

  async ngOnInit(){
    const options = await this.http.getOption();
    const optionGroupId = await this.http.getOptionGroupId();
    this.options = options;
    this.option = options;
    this.optionGroupId = optionGroupId;
  }


  selectCard(option: Option) {
    this.formModel = {...option};
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