import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
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
  balance: any;
  decodedToken: Token = new Token;

  constructor(private http: HttpService, private router: Router) { }

  ngOnInit(): void {
  }

  async login() {
    let dto = {
      email: this.email,
      password: this.password,
      balance: this.balance
    }
    var token = await this.http.login(dto);
   localStorage.setItem('token', token)
    let decodedToken = jwtDecode(token) as Token;
    if (decodedToken.role == 'Admin' || decodedToken.role == 'SuperAdmin'){
        this.router.navigateByUrl('/adminpage');
    }
    else{
        this.router.navigateByUrl('/');
    }
  }

}



export class Token {
  role?: string;
  email?: string;
  balance?: number;
}
