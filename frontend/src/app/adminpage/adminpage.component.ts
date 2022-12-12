import {Component, OnInit} from "@angular/core";


@Component({
  selector: 'app-adminpage',
  templateUrl: './adminpage.component.html',
  styleUrls: ['./adminpage.component.scss']
})
// @ts-ignore
export class AdminpageComponent implements OnInit {
  optionName: string = '';
  optionGroupId: Number = 1;

  constructor() { }

  ngOnInit(): void {
  }

  createOption() {

  }
}
