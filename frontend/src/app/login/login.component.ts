import { Component, OnInit } from '@angular/core';
import jwtDecode from 'jwt-decode';
import {HttpService} from "../../services/http.service";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})

export class LoginComponent implements OnInit {
  email: any;
  password: any;
  decodedToken: Token = new Token;

  constructor(private http: HttpService) { }

  ngOnInit(): void {
  }

  async login() {
    let dto = {
      email: this.email,
      password: this.password
    }
    var token = await this.http.login(dto);
   localStorage.setItem('token', token)
    let decodedToken = jwtDecode(token) as Token;
    if (decodedToken.role == 'Admin' || 'SuperAdmin'){
        location.href = 'http://localhost:4200/adminpage';
    }
    else{
        location.href = 'http://localhost:4200/userpage';
    }
  }

}



class Token {
  role?: string;
}
