import { Component, OnInit } from '@angular/core';
import {HttpService} from "../../services/http.service";
import {customAxios} from "../app.component";

@Component({
  selector: 'app-userpage',
  templateUrl: './userpage.component.html',
  styleUrls: ['./userpage.component.scss']
})
// @ts-ignore
export class UserpageComponent implements OnInit {


  constructor(private http: HttpService) {

  }

  async ngOnInit() {


  }


}
