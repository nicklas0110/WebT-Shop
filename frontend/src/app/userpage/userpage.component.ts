import { Component, OnInit } from '@angular/core';
import {HttpService} from "../../services/http.service";
import {customAxios} from "../app.component";


@Component({
  selector: 'app-userpage',
  templateUrl: './userpage.component.html',
  styleUrls: ['./userpage.component.scss']
})

export class UserpageComponent implements OnInit {
  formModel : Option = new Option(); // Sets formModel = to the Box class
  option: any;
  options: any[] = [];

  constructor(private http : HttpService) { }

  async ngOnInit(){
    const options = await this.http.getOption();
    this.options = options;
    this.option = options;
  }


  selectCard(option: Option) {
    this.formModel = {...option};
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