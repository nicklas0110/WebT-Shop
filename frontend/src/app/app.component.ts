import {Component, OnInit} from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{
  title = 'frontend';
  formModel: Option = new Option; // Sets formModel = to the Option class
  option: any;
  options: Array<Option> = []; // an array of Options

  ngOnInit(): void {
  }
}

// is in change of the 3 txt fields information storing when creating or edit
class OptionDto {
  name: string = "";
}
// Sets the id when it is needed
class Option extends OptionDto{
  id: number = 0;
}
