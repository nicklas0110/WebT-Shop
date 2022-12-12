import {Component, OnInit} from "@angular/core";
import {HttpService} from "../../services/http.service";


@Component({
  selector: 'app-adminpage',
  templateUrl: './adminpage.component.html',
  styleUrls: ['./adminpage.component.scss']
})
// @ts-ignore
export class AdminpageComponent implements OnInit {
  formModel : Option = new Option(); // Sets formModel = to the Box class
  option: any;
  options: Array<Option> = [];

  constructor(private http : HttpService) { }

  async ngOnInit(){
    const options = await this.http.getOption();
    this.options = options.data;
    this.option = options.data;
  }

  async createOption() {
    // @ts-ignore
  /*  const result = await this.http.createOption(this.formModel as OptionDto);
    this.options.push(result);
    this.formModel = new Option();*/
    let dto = {
      name: this.formModel.optionName,
      optionGroupId: this.formModel.optionGroupId
    }
    const result = await this.http.createOption(dto);
    console.log(result);
  }
}

class OptionDto {
  optionName: string = "";
  optionGroupId: Number = 1;
}
// Sets the id when it is needed
class Option extends OptionDto{
  id: number = 0;
}

