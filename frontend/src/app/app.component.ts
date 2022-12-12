import {Component, OnInit} from '@angular/core';
import {HttpService} from "../services/http.service";
import axios from "axios";

export const customAxios = axios.create({
  baseURL: 'http://localhost:5111'
})



@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
// @ts-ignore
export class AppComponent{




}
