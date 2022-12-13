import {Component, OnInit} from "@angular/core";
import {HttpService} from "../../services/http.service";


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
      name: this.formModel.optionName,
      optionGroupId: this.formModel.optionGroupId
    }
    const result = await this.http.createOption(dto);
    console.log(result);
    this.options.push(result);

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

