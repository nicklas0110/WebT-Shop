import { Component, OnInit } from '@angular/core';
import {HttpService} from "../../services/http.service";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})

export class LoginComponent implements OnInit {
    email: any;
  password: any;

  constructor(private http: HttpService) { }

  ngOnInit(): void {
  }

  login() {
    let dto = {
      email: this.email,
      password: this.password
    }
    var token = this.http.login(dto);
    console.log(token);
  }
}
